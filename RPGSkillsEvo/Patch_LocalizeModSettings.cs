using HarmonyLib;
using Il2Cpp;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RPGSkillsEvo;

// Patch 1: runs once after ModSettings builds the GUI — walks labels/descriptions,
//          matches English originals, stores (object → locKey) pairs, applies once.
[HarmonyPatch(typeof(Panel_OptionsMenu), "InitializeAutosaveMenuItems")]
internal static class Patch_LocalizeModSettings_Build
{
    [HarmonyPriority(Priority.Low)]
    [HarmonyPostfix]
    private static void Postfix(Panel_OptionsMenu __instance)
    {
        Transform pages = ((Component)__instance).transform.Find("Pages");
        if (pages == null) return;

        Transform modTab = pages.Find("ModSettings");
        if (modTab == null) return;

        Patch_LocalizeModSettings_Refresh.BuildCache(modTab);
        Patch_LocalizeModSettings_Refresh.ApplyTranslations();
    }
}

// Patch 2: runs whenever TLD calls SetLanguage (AFTER Localization.Language is
//          updated to the new value) — re-applies from the cached maps.
//          RefreshLanguage fires BEFORE Localization.Language is committed, so
//          we hook SetLanguage instead which fires after the commit.
[HarmonyPatch(typeof(Panel_OptionsMenu), "SetLanguage")]
internal static class Patch_LocalizeModSettings_Refresh
{
    // label → localization key
    private static readonly List<LabelEntry> s_labels = new List<LabelEntry>();
    // DescriptionHolder component + reflection info → localization key
    private static readonly List<DescEntry> s_descs = new List<DescEntry>();

    private struct LabelEntry
    {
        public UILabel Label;
        public string Key;
    }

    private struct DescEntry
    {
        public Component Holder;
        public MethodInfo Setter;
        public string Key;
    }

    [HarmonyPostfix]
    private static void Postfix() => ApplyTranslations();

    internal static void BuildCache(Transform modTab)
    {
        s_labels.Clear();
        s_descs.Clear();

        // --- Labels ---
        UILabel[] labels = ((Component)modTab).GetComponentsInChildren<UILabel>(true);
        foreach (UILabel label in labels)
        {
            string key = LabelKey(label.text);
            if (key != null)
                s_labels.Add(new LabelEntry { Label = label, Key = key });
        }

        // --- DescriptionHolders ---
        Component[] all = ((Component)modTab).GetComponentsInChildren<Component>(true);
        foreach (Component comp in all)
        {
            if (comp == null) continue;
            System.Type t = comp.GetType();
            if (t.Name != "DescriptionHolder") continue;

            PropertyInfo prop = t.GetProperty("Text",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (prop == null) continue;

            string current = prop.GetValue(comp) as string;
            if (current == null) continue;

            string key = DescKey(current);
            if (key == null) continue;

            MethodInfo setter = prop.GetSetMethod(nonPublic: true);
            if (setter == null) continue;

            s_descs.Add(new DescEntry { Holder = comp, Setter = setter, Key = key });
        }
    }

    internal static void ApplyTranslations()
    {
        foreach (LabelEntry e in s_labels)
            if ((Object)(object)e.Label != (Object)null)
                e.Label.text = Loc.Get(e.Key);

        foreach (DescEntry e in s_descs)
            if ((Object)(object)e.Holder != (Object)null)
                e.Setter.Invoke(e.Holder, new object[] { Loc.Get(e.Key) });
    }

    // -----------------------------------------------------------------
    // English original → Loc key  (matched only once at build time)
    // -----------------------------------------------------------------
    // NGUI UILabel stores text in the case set by the caller, but ModSettings
    // internally uppercases section/setting titles before assigning them.
    // Normalise to upper-case so matching works regardless of how the string
    // was stored.
    private static string LabelKey(string english)
    {
        if (english == null) return null;
        return english.ToUpperInvariant() switch
        {
            "EXPERIENCE"                => "RPG.SET.SEC_XP",
            "XP PER SKILL INCREMENT"    => "RPG.SET.XP_PER_SKILL",
            "KILL XP MULTIPLIER"        => "RPG.SET.XP_KILL_MULT",
            "SKILL POINTS"              => "RPG.SET.SEC_POINTS",
            "STARTING SKILL POINTS"     => "RPG.SET.START_POINTS",
            "SKILL POINTS PER LEVEL-UP" => "RPG.SET.POINTS_PER_LEVEL",
            "HUD"                       => "RPG.SET.SEC_HUD",
            "SHOW HUD NUMBERS"          => "RPG.SET.SHOW_HUD_NUMBERS",
            _                           => null
        };
    }

    private static string DescKey(string english) => english switch
    {
        "XP awarded each time a vanilla skill (fire, fishing, repair, etc.) increments."
            => "RPG.SET.XP_PER_SKILL_DESC",
        "Multiplier for XP from killing animals. Base: rabbit=5, wolf=10, bear=20, moose=50."
            => "RPG.SET.XP_KILL_MULT_DESC",
        "Skill points given at the start of each new playthrough."
            => "RPG.SET.START_POINTS_DESC",
        "Skill points granted each time you level up."
            => "RPG.SET.POINTS_PER_LEVEL_DESC",
        "Show numeric values (HP, temperature, fatigue, thirst, hunger) below the HUD stat icons."
            => "RPG.SET.SHOW_HUD_NUMBERS_DESC",
        _ => null
    };
}
