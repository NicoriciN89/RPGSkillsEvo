using Il2Cpp;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace RPGSkillsEvo;

/// <summary>
/// Lightweight localization helper for RPG Skills Evo.
/// Reads strings from an embedded JSON resource (RPGSkillsEvo.localization.json).
/// User overrides can be placed at: UserData/RPGSkillsEvo/localization.json
/// </summary>
internal static class Loc
{
    private static Dictionary<string, Dictionary<string, string>> _data;

    private static Dictionary<string, Dictionary<string, string>> Data =>
        _data ?? (_data = Load());

    internal static void Reload() => _data = null;

    private const string EmbeddedResource = "RPG_Skills_Evo.localization.json";

    // Maps TLD/I2Localization language names → our JSON keys.
    // TLD uses I2Loc which can return names like "French (France)" or "Chinese (Simplified)".
    private static readonly Dictionary<string, string> _langAliases =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // French variants
        ["French (France)"]               = "French",
        ["French(France)"]                = "French",
        // German variants
        ["German (Germany)"]              = "German",
        ["German(Germany)"]               = "German",
        // Spanish variants
        ["Spanish (Latin America)"]       = "Spanish",
        ["Spanish(Latin America)"]        = "Spanish",
        ["Spanish (Spain)"]               = "Spanish",
        ["Spanish(Spain)"]                = "Spanish",
        // Portuguese / Brazilian
        ["Portuguese (Brazil)"]           = "Brazilian",
        ["Portuguese(Brazil)"]            = "Brazilian",
        ["Brazilian Portuguese"]          = "Brazilian",
        // bare "Portuguese" without qualifier → Portugal
        ["Portuguese"]                    = "Portuguese",
        // Chinese
        ["Chinese (Simplified)"]          = "ChineseSimplified",
        ["Chinese(Simplified)"]           = "ChineseSimplified",
        ["Simplified Chinese"]            = "ChineseSimplified",
        ["Chinese (Traditional)"]         = "ChineseTraditional",
        ["Chinese(Traditional)"]          = "ChineseTraditional",
        ["Traditional Chinese"]           = "ChineseTraditional",
        // Turkish
        ["Turkish (Turkey)"]              = "Turkish",
        ["Turkish(Turkey)"]               = "Turkish",
        // Italian
        ["Italian (Italy)"]               = "Italian",
        // Dutch
        ["Dutch (Netherlands)"]           = "Dutch",
        // Polish
        ["Polish (Poland)"]               = "Polish",
        // Czech
        ["Czech (Czech Republic)"]        = "Czech",
        // Korean
        ["Korean (Korea)"]                = "Korean",
        // Japanese
        ["Japanese (Japan)"]              = "Japanese",
        // Russian
        ["Russian (Russia)"]              = "Russian",
        // Ukrainian
        ["Ukrainian (Ukraine)"]           = "Ukrainian",
        ["Ukrainian(Ukraine)"]            = "Ukrainian",
        // Finnish
        ["Finnish (Finland)"]             = "Finnish",
        ["Finnish(Finland)"]              = "Finnish",
        // Norwegian
        ["Norwegian (Norway)"]            = "Norwegian",
        ["Norwegian(Norway)"]             = "Norwegian",
        ["Norwegian Bokmål"]              = "Norwegian",
        ["Norwegian Bokmaal"]             = "Norwegian",
        // Swedish
        ["Swedish (Sweden)"]              = "Swedish",
        ["Swedish(Sweden)"]               = "Swedish",
        // Portuguese - Portugal (separate from Brazilian)
        ["Portuguese (Portugal)"]         = "Portuguese",
        ["Portuguese(Portugal)"]          = "Portuguese",
        ["Portuguese - Portugal"]         = "Portuguese",
    };

    private static string NormalizeLang(string raw)
    {
        if (raw == null) return "English";
        if (_langAliases.TryGetValue(raw, out string mapped)) return mapped;
        return raw;
    }

    // ──────────────────────────────────────────────
    // Public API
    // ──────────────────────────────────────────────

    private static string _lastLoggedLang = null;

    /// <summary>Returns the localized string for <paramref name="key"/>.</summary>
    internal static string Get(string key)
    {
        string rawLang = Localization.Language;
        string lang = NormalizeLang(rawLang);
        if (_lastLoggedLang != lang)
        {
            _lastLoggedLang = lang;
            MelonLoader.MelonLogger.Msg("[RPGSkillsEvo] Language: raw='" + (rawLang ?? "null") + "' normalized='" + lang + "'");
        }
        var data = Data;
        if (data.TryGetValue(lang, out var dict) && dict.TryGetValue(key, out string val))
            return val;
        if (data.TryGetValue("English", out var en) && en.TryGetValue(key, out string enVal))
            return enVal;
        return key;
    }

    /// <summary>Returns the localized string, then formats it with <paramref name="args"/>.</summary>
    internal static string Get(string key, params object[] args)
    {
        string raw = Get(key);
        try { return string.Format(raw, args); }
        catch { return raw; }
    }

    // ──────────────────────────────────────────────
    // Loading
    // ──────────────────────────────────────────────

    private static Dictionary<string, Dictionary<string, string>> Load()
    {
        // 1. User override file
        string dllDir   = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
        string userPath = Path.Combine(
            Path.GetDirectoryName(dllDir) ?? dllDir,
            "UserData", "RPGSkillsEvo", "localization.json");

        if (File.Exists(userPath))
        {
            var fromFile = TryParse(File.ReadAllText(userPath, Encoding.UTF8));
            if (fromFile != null)
            {
                MelonLogger.Msg("[RPGSkillsEvo] Localization override loaded: " + userPath);
                return fromFile;
            }
        }

        // 2. Embedded resource
        var asm    = Assembly.GetExecutingAssembly();
        var stream = asm.GetManifestResourceStream(EmbeddedResource);
        if (stream != null)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);
            var fromEmbed    = TryParse(reader.ReadToEnd());
            if (fromEmbed != null) return fromEmbed;
        }
        else
        {
            MelonLogger.Warning("[RPGSkillsEvo] Embedded localization resource not found — using fallback.");
        }

        return Fallback;
    }

    private static Dictionary<string, Dictionary<string, string>> TryParse(string json)
    {
        try   { return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json); }
        catch (Exception ex)
        {
            MelonLogger.Warning("[RPGSkillsEvo] Localization JSON parse error: " + ex.Message);
            return null;
        }
    }

    // ──────────────────────────────────────────────
    // Fallback (English only)
    // ──────────────────────────────────────────────

    private static readonly Dictionary<string, Dictionary<string, string>> Fallback = new()
    {
        ["English"] = new()
        {
            // ── UI labels ───────────────────────────
            ["RPG.UI.SKILL_AWAKENING"]   = "Skill Awakening",
            ["RPG.UI.PLAYER_INTERFACE"]  = "Player Interface",
            ["RPG.UI.AUTO_LOOT_SETTINGS"]= "Auto Loot Settings",
            ["RPG.UI.SKILL_TREE"]        = "Skill Tree",
            ["RPG.UI.AUTO_LOOT"]         = "Auto Loot",
            ["RPG.UI.QUICKBAR"]          = "Quickbar",
            ["RPG.UI.LEVEL"]             = "Level",
            ["RPG.UI.EXP"]               = "EXP",
            ["RPG.UI.SP"]                = "SP",
            ["RPG.UI.STAT_WEIGHT"]       = "Weight\nUp",
            ["RPG.UI.STAT_WALK"]         = "Walk\nSpeed",
            ["RPG.UI.STAT_SPRINT"]       = "Sprint",
            ["RPG.UI.STAT_CROUCH"]       = "Crouch",
            ["RPG.UI.STAT_WIND"]         = "Wind\nResist",
            ["RPG.UI.STAT_WARMTH"]       = "Warmth",
            ["RPG.UI.STAT_FATIGUE"]      = "Fatigue",
            ["RPG.UI.STAT_HUNGER"]       = "Hunger",
            ["RPG.UI.STAT_SURVIVAL"]     = "Survival\nExpert",
            ["RPG.UI.STAT_PROTECTION"]   = "Protection",
            ["RPG.UI.STAT_DURABILITY"]   = "Durability",
            ["RPG.UI.STAT_BUFF"]         = "Buff\nAddiction",
            ["RPG.UI.STAT_VITALITY"]     = "Vitality",
            ["RPG.UI.STATS_DETAIL"]      = "STATS DETAIL",
            // ── Buttons ─────────────────────────────
            ["RPG.UI.BTN_BACK"]          = "Back",
            ["RPG.UI.BTN_MOVE_CORE"]     = "Move to Core",
            ["RPG.UI.BTN_RESET"]         = "Reset  (Stick x{0})",
            ["RPG.UI.BTN_APPLY"]         = "Apply",
            ["RPG.UI.BTN_APPLY_CHANGES"] = "APPLY\nCHANGES",
            ["RPG.UI.BTN_RESET_SHORT"]   = "Reset",
            // ── Hints ────────────────────────────────
            ["RPG.UI.RCLICK_HINT"]       = "RClick: Refund unconfirmed",
            ["RPG.UI.AVAILABLE_POINTS"]  = "AVAILABLE POINTS: {0} PT",
            ["RPG.UI.ITEM_ACQUIRED"]     = "Item Acquired",
            // ── Auto Loot status bar ─────────────────
            ["RPG.UI.AL_ON"]             = "Auto Loot ON",
            ["RPG.UI.AL_OFF"]            = "Auto Loot OFF",
            ["RPG.UI.AL_HOTKEY"]         = "Hotkey: {0}",
            ["RPG.UI.AL_WAITING"]        = "WAITING...",
            ["RPG.UI.AL_ACTIVE_SLOTS"]   = "Active Slots: {0} / {1}",
            ["RPG.UI.AL_RADIUS"]         = "Radius: {0}m",
            ["RPG.UI.AL_SCAN"]           = "Scan: {0}s",
            ["RPG.UI.AL_SLOT"]           = "Slot",
            ["RPG.UI.AL_CATEGORY"]       = "Category",
            ["RPG.UI.AL_ITEM"]           = "Item",
            ["RPG.UI.AL_STATUS"]         = "Status",
            // ── Categories ──────────────────────────
            ["RPG.CAT.ARROW"]            = "Arrow",
            ["RPG.CAT.WOOD"]             = "Wood",
            ["RPG.CAT.PLANT"]            = "Plant",
            ["RPG.CAT.AMMO"]             = "Ammo",
            ["RPG.CAT.HIDE"]             = "Hide",
            ["RPG.CAT.FIRE"]             = "Fire",
            ["RPG.CAT.MISC"]             = "Misc",
            ["RPG.CAT.CUSTOM"]           = "Custom",
            // ── Confirm windows ─────────────────────
            ["RPG.CONFIRM.CANCEL_BODY"]  = "Cancel changes?\nAll unconfirmed points will be refunded.",
            ["RPG.CONFIRM.OK"]           = "OK",
            ["RPG.CONFIRM.CANCEL"]       = "Cancel",
            ["RPG.CONFIRM.APPLY_BODY"]   = "Confirm applying changes?",
            ["RPG.CONFIRM.YES"]          = "YES",
            ["RPG.CONFIRM.NO"]           = "NO",
            ["RPG.CONFIRM.UNSAVED_BODY"] = "Unsaved changes detected.\nSave changes?",
            ["RPG.CONFIRM.SAVE"]         = "SAVE",
            ["RPG.CONFIRM.DISCARD"]      = "DISCARD",
            // ── Tooltip ─────────────────────────────
            ["RPG.TIP.LEVEL"]            = "Level: {0} / {1}",
            ["RPG.TIP.CURRENT"]          = "▶ Current: {0}",
            ["RPG.TIP.NEXT"]             = "▷ Next: {0}",
            ["RPG.TIP.COST"]             = "Required: {0} PT",
            ["RPG.TIP.MAX"]              = " (max)",
            ["RPG.TIP.COND_FAIL"]        = "✘ {0} — reach level {1} to invest",
            ["RPG.TIP.LIMIT"]            = "✘ {0} — raise its level to invest more",
            ["RPG.TIP.COND_OK"]          = "✔ Prerequisites met",
            // ── Node names ──────────────────────────
            ["RPG.NODE.CORE"]            = "Central Core",
            ["RPG.NODE.W6"]              = "Strength Awakening",
            ["RPG.NODE.W7"]              = "Carry Weight I",
            ["RPG.NODE.W7N1"]            = "Weight Penalty Reduce I",
            ["RPG.NODE.W8"]              = "Carry Weight II",
            ["RPG.NODE.W8N1"]            = "Weight Penalty Reduce II",
            ["RPG.NODE.W9"]              = "Carry Weight III",
            ["RPG.NODE.W9N1"]            = "Weight Penalty Reduce III",
            ["RPG.NODE.W10"]             = "Carry Weight Master",
            ["RPG.NODE.W6N1"]            = "Protection I",
            ["RPG.NODE.W6N2"]            = "Protection II",
            ["RPG.NODE.E6"]              = "Agility Awakening",
            ["RPG.NODE.E7"]              = "Walk Speed I",
            ["RPG.NODE.E7N1"]            = "Sprint Speed I",
            ["RPG.NODE.E7S1"]            = "Crouch Speed I",
            ["RPG.NODE.E8"]              = "Walk Speed II",
            ["RPG.NODE.E7N1E1"]          = "Sprint Speed II",
            ["RPG.NODE.E7S1E1"]          = "Crouch Speed II",
            ["RPG.NODE.E9"]              = "Walk Speed III",
            ["RPG.NODE.E7N1E2"]          = "Sprint Speed III",
            ["RPG.NODE.E7S1E2"]          = "Crouch Speed III",
            ["RPG.NODE.E6S1"]            = "Wind Resist Awakening",
            ["RPG.NODE.E6S2"]            = "Wind Resist I",
            ["RPG.NODE.E6S3"]            = "Wind Resist II",
            ["RPG.NODE.E6S4"]            = "Wind Resist III",
            ["RPG.NODE.S6"]              = "Exploration Awakening",
            ["RPG.NODE.S6W1"]            = "Auto Loot Awakening",
            ["RPG.NODE.S6W1S1"]          = "Loot Radius Expand I",
            ["RPG.NODE.S6W2"]            = "Loot Slot Expand I",
            ["RPG.NODE.S6W2S1"]          = "Loot Radius Expand II",
            ["RPG.NODE.S6W3"]            = "Loot Slot Expand II",
            ["RPG.NODE.S6W3S1"]          = "Loot Radius Expand III",
            ["RPG.NODE.S7"]              = "Map Track Awakening",
            ["RPG.NODE.S8"]              = "Track Arrow",
            ["RPG.NODE.S9"]              = "Track Altitude",
            ["RPG.NODE.N6"]              = "Combat Awakening",
            ["RPG.NODE.N6W1"]            = "Quickslot Awakening",
            ["RPG.NODE.N6W1N1"]          = "Preset Awakening",
            ["RPG.NODE.N6W1N1W1"]        = "Quickslot Expand",
            ["RPG.NODE.N6W1N2"]          = "Preset Expand",
            ["RPG.NODE.N6E1"]            = "Scope Awakening",
            ["RPG.NODE.N6E1N1"]          = "Rifle Scope",
            ["RPG.NODE.N6E1N2"]          = "Rifle Scope Range I",
            ["RPG.NODE.N6E1N3"]          = "Rifle Scope Range II",
            ["RPG.NODE.N6E1N1E1"]        = "Revolver Scope",
            ["RPG.NODE.N6E1N1E1N1"]      = "Revolver Scope Range",
            ["RPG.NODE.WS5"]             = "Survival Awakening",
            ["RPG.NODE.WS5S1"]           = "Warmth I",
            ["RPG.NODE.WS5S2"]           = "Warmth II",
            ["RPG.NODE.WS5W1"]           = "Fatigue Reduction I",
            ["RPG.NODE.WS5W2"]           = "Fatigue Reduction II",
            ["RPG.NODE.WS6"]             = "Hunger Reduction I",
            ["RPG.NODE.WS7"]             = "Hunger Reduction II",
            ["RPG.NODE.WS5WN1"]          = "Harsh Evolution I",
            ["RPG.NODE.WS5WN1W1"]        = "Harsh Evolution II",
            ["RPG.NODE.WS5WN1W2"]        = "Survival Expert",
            ["RPG.NODE.ES5"]             = "Management Awakening",
            ["RPG.NODE.ES5S1"]           = "Durability Efficiency I",
            ["RPG.NODE.ES5S2"]           = "Durability Efficiency II",
            ["RPG.NODE.ES6"]             = "Buff Duration I",
            ["RPG.NODE.ES7"]             = "Buff Duration II",
            ["RPG.NODE.ES8"]             = "Buff Addiction",
            // ── Descriptions ────────────────────────
            ["RPG.DESC.UNLOCK"]              = "Unlocks {0}.",
            ["RPG.DESC.UNLOCK_SURVIVAL"]     = "Unlocks {0}.\nDisplays numbers on the status HUD.",
            ["RPG.DESC.AUTO_LOOT_UNLOCK"]    = "Unlocks the ability to automatically loot items.",
            ["RPG.DESC.QUICKSLOT_UNLOCK"]    = "Unlocks the Quickslot feature.\nUse items quickly with keyboard shortcuts.",
            ["RPG.DESC.PRESET_UNLOCK"]       = "Unlocks the Clothing Preset feature.\nQuickly apply saved outfit sets.",
            ["RPG.DESC.WIND_RESIST_UNLOCK"]  = "Unlocks wind resistance.\nReduces movement speed loss from wind.",
            ["RPG.DESC.REVOLVER_AIM_MOVE"]   = "Allows movement while aiming a revolver.\nMovement speed is reduced by 10% while aiming.",
            ["RPG.DESC.RIFLE_ZOOM_UNLOCK"]   = "Mouse wheel zoom while aiming a rifle.\nDefault maximum: 5× zoom.",
            ["RPG.DESC.RIFLE_ZOOM_RANGE1"]   = "Increases max rifle zoom.\n+{0}× per point.",
            ["RPG.DESC.RIFLE_ZOOM_RANGE2"]   = "Greatly increases max rifle zoom.\n+{0}× per point.",
            ["RPG.DESC.REVOLVER_ZOOM_UNLOCK"]= "Mouse wheel zoom while aiming a revolver.\nDefault maximum: 2× zoom.",
            ["RPG.DESC.REVOLVER_ZOOM_RANGE"] = "Increases max revolver zoom.\n+{0}× per point. Max 5×.",
            ["RPG.DESC.WEIGHT_UP"]           = "Increases carry weight limit.\n+{0} kg per point.",
            ["RPG.DESC.SPEED_PENALTY_SUFFIX"]= "\n-{0}% speed per point.",
            ["RPG.DESC.SPEED_OFFSET"]        = "Offsets the speed penalty from weight.\n-{0}% penalty per point.",
            ["RPG.DESC.WALK_SPEED"]          = "Increases walk speed.\n+{0}% per point.",
            ["RPG.DESC.SPRINT_SPEED"]        = "Increases sprint speed.\n+{0}% per point.",
            ["RPG.DESC.CROUCH_SPEED"]        = "Increases crouch speed.\n+{0}% per point.",
            ["RPG.DESC.LOOT_SLOT"]           = "Increases auto-loot slots.\n+{0} slot per point.",
            ["RPG.DESC.LOOT_RADIUS"]         = "Increases auto-loot detection radius.\n+{0} m per point.",
            ["RPG.DESC.QUICKSLOT"]           = "Increases quickslot count.\n+{0} per point.",
            ["RPG.DESC.PRESET_SLOT"]         = "Increases clothing preset slots.\n+{0} per point.",
            ["RPG.DESC.MAP_TRACK_UNLOCK"]    = "Right-click a map icon to start tracking.\nName and distance shown at the top of screen.",
            ["RPG.DESC.MAP_TRACK_ARROW"]     = "Adds a direction arrow to the tracking HUD.",
            ["RPG.DESC.MAP_TRACK_HEIGHT"]    = "Adds height info to the tracking HUD.\nShows whether target is above or below.",
            ["RPG.DESC.WIND_RESIST"]         = "Reduces movement speed loss from wind.\n{0}% resistance per point.",
            ["RPG.DESC.WARMTH"]              = "Increases warmth bonus.\n+{0}°C per point.",
            ["RPG.DESC.FATIGUE_DOWN"]        = "Reduces fatigue drain from all actions.\n-{0}% per point.",
            ["RPG.DESC.HUNGER_DOWN"]         = "Reduces hunger drain from all actions.\n-{0}% per point.",
            ["RPG.DESC.VITALITY_UP"]         = "Increases max HP/Fatigue/Thirst.\n+{0} per point.",
            ["RPG.DESC.WEIGHT_PENALTY_SUFFIX"]= "\n-{0} kg max weight per point.",
            ["RPG.DESC.PROTECTION_UP"]       = "Reduces incoming damage.\n+{0}% protection per point.",
            ["RPG.DESC.VITALITY_PENALTY_SUFFIX"]= "\n-{0} max HP/Fatigue/Thirst per point.",
            ["RPG.DESC.DECAY_EFFICIENCY"]    = "Slows durability loss of food and clothing.\n+{0}% suppression per point.",
            ["RPG.DESC.BUFF_DURATION"]       = "Extends fatigue-reduce and weight-increase buff durations.\n+{0}% duration per point.",
            // ── Current-value strings ────────────────
            ["RPG.VAL.UNLOCKED"]         = "Unlocked",
            ["RPG.VAL.NOT_INVESTED"]     = "Not invested",
            ["RPG.VAL.WEIGHT"]           = "+{0}kg weight",
            ["RPG.VAL.SPEED_PENALTY"]    = " / -{0}% speed",
            ["RPG.VAL.SPEED_OFFSET"]     = "Penalty -{0}% offset",
            ["RPG.VAL.WALK"]             = "+{0}% walk",
            ["RPG.VAL.SPRINT"]           = "+{0}% sprint",
            ["RPG.VAL.CROUCH"]           = "+{0}% crouch",
            ["RPG.VAL.LOOT_SLOT"]        = "+{0} slot (total: {1})",
            ["RPG.VAL.LOOT_RADIUS"]      = "+{0}m radius (total: {1}m)",
            ["RPG.VAL.QUICKSLOT"]        = "+{0} slot (total: {1})",
            ["RPG.VAL.PRESET_SLOT"]      = "+{0} slot (total: {1})",
            ["RPG.VAL.WIND_RESIST"]      = "{0}% wind ignored",
            ["RPG.VAL.RIFLE_ZOOM"]       = "+{0}× rifle zoom (max: {1}×)",
            ["RPG.VAL.REVOLVER_ZOOM"]    = "+{0}× revolver zoom (max: {1}×)",
            ["RPG.VAL.WARMTH"]           = "+{0}°C warmth",
            ["RPG.VAL.FATIGUE"]          = "-{0}% fatigue drain",
            ["RPG.VAL.HUNGER"]           = "-{0}% hunger drain",
            ["RPG.VAL.VITALITY"]         = "+{0} max",
            ["RPG.VAL.WEIGHT_PENALTY"]   = " / -{0}kg weight",
            ["RPG.VAL.PROTECTION"]       = "+{0}% protection",
            ["RPG.VAL.VITALITY_PENALTY"] = " / -{0} max",
            ["RPG.VAL.DECAY"]            = "+{0}% suppressed (total: {1}%)",
            ["RPG.VAL.BUFF_DURATION"]    = "+{0}% duration (total: {1}%)",
            // ── Values: newer effects ────────────────
            ["RPG.VAL.CRAFT_SPEED"]      = "-{0}% time (total: -{1:F0}%)",
            ["RPG.VAL.BLEED_RESIST"]     = "+{0}% bleed (total: +{1:F0}%)",
            ["RPG.VAL.HARVEST_BONUS"]    = "+{0}% yield (total: +{1:F0}%)",
            ["RPG.VAL.THIRST_DOWN"]      = "-{0}% thirst (total: -{1:F0}%)",
            ["RPG.VAL.TOOL_DURABILITY"]  = "-{0}% wear (total: -{1:F0}%)",
            ["RPG.VAL.FISHING_BONUS"]    = "+{0}% fish (total: +{1:F0}%)",
            ["RPG.VAL.SPRINT_STAMINA"]   = "+{0}% stamina (total: +{1:F0}%)",
            // ── Descriptions: newer effects ──────────
            ["RPG.DESC.CRAFT_SPEED"]     = "Reduces repair and crafting time.\n-{0}% time per point.",
            ["RPG.DESC.BLEED_RESIST"]    = "Slows bleed-out rate.\n+{0}% bleed duration per point.",
            ["RPG.DESC.HARVEST_BONUS"]   = "Increases natural plant harvest yield.\n+{0}% extra items per point.",
            ["RPG.DESC.THIRST_DOWN"]     = "Reduces dehydration drain rate.\n-{0}% thirst per point.",
            ["RPG.DESC.TOOL_DURABILITY"] = "Reduces condition loss on tools and weapons.\n-{0}% wear per point.",
            ["RPG.DESC.FISHING_BONUS"]   = "Increases caught fish weight.\n+{0}% fish size per point.",
            ["RPG.DESC.SPRINT_STAMINA"]  = "Increases max sprint stamina.\n+{0}% stamina per point.",
            // ── Node names: newer nodes ──────────────
            ["RPG.NODE.WS5N1"]   = "Bleed Resist I",
            ["RPG.NODE.WS5N2"]   = "Bleed Resist II",
            ["RPG.NODE.WS5E1"]   = "Harvest Bonus I",
            ["RPG.NODE.WS5E2"]   = "Harvest Bonus II",
            ["RPG.NODE.WS7N1"]   = "Thirst Reduction I",
            ["RPG.NODE.WS7N2"]   = "Thirst Reduction II",
            ["RPG.NODE.ES5N1"]   = "Craft Speed I",
            ["RPG.NODE.ES5N2"]   = "Craft Speed II",
            ["RPG.NODE.ES5W1"]   = "Tool Durability I",
            ["RPG.NODE.ES5W2"]   = "Tool Durability II",
            ["RPG.NODE.S6E1"]    = "Fishing Bonus I",
            ["RPG.NODE.S6E2"]    = "Fishing Bonus II",
            ["RPG.NODE.E7N1E3"]  = "Sprint Stamina I",
            ["RPG.NODE.E7N1E4"]  = "Sprint Stamina II",
            // ── Settings labels ──────────────────────
            ["RPG.SET.SEC_XP"]              = "Experience",
            ["RPG.SET.XP_PER_SKILL"]        = "XP per skill increment",
            ["RPG.SET.XP_KILL_MULT"]        = "Kill XP multiplier",
            ["RPG.SET.SEC_POINTS"]          = "Skill Points",
            ["RPG.SET.START_POINTS"]        = "Starting skill points",
            ["RPG.SET.POINTS_PER_LEVEL"]    = "Skill points per level-up",
            ["RPG.SET.SEC_HUD"]             = "HUD",
            ["RPG.SET.SHOW_HUD_NUMBERS"]    = "Show HUD numbers",
            // ── Settings descriptions ────────────────
            ["RPG.SET.XP_PER_SKILL_DESC"]     = "XP awarded each time a vanilla skill (fire, fishing, repair, etc.) increments.",
            ["RPG.SET.XP_KILL_MULT_DESC"]     = "Multiplier for XP from killing animals. Base: rabbit=5, wolf=10, bear=20, moose=50.",
            ["RPG.SET.START_POINTS_DESC"]     = "Skill points given at the start of each new playthrough.",
            ["RPG.SET.POINTS_PER_LEVEL_DESC"] = "Skill points granted each time you level up.",
            ["RPG.SET.SHOW_HUD_NUMBERS_DESC"] = "Show numeric values (HP, temperature, fatigue, thirst, hunger) below the HUD stat icons.",
            // ── Misc ─────────────────────────────────
            ["RPG.TIP.IS_MAX"] = "MAX",
            // ── New nodes: names ─────────────────────
            ["RPG.NODE.WS5FM1"] = "Fire Duration I",
            ["RPG.NODE.WS5FM2"] = "Fire Duration II",
            ["RPG.NODE.WS5CA1"] = "Cold Adaptation I",
            ["RPG.NODE.WS5CA2"] = "Cold Adaptation II",
            ["RPG.NODE.WS5FO1"] = "Forager I",
            ["RPG.NODE.WS5FO2"] = "Forager II",
            ["RPG.NODE.N6AF1"]  = "Archery Focus I",
            ["RPG.NODE.N6AF2"]  = "Archery Focus II",
            // ── New nodes: descriptions ───────────────
            ["RPG.DESC.FIRE_START"]     = "Extends fire burn duration.\n+{0}% burn time per point.",
            ["RPG.DESC.COLD_ADAPT"]     = "Reduces damage taken from freezing.\n-{0}% cold damage per point.",
            ["RPG.DESC.BOW_STEADINESS"] = "Increases bow arrow damage.\n+{0}% damage per point.",
            ["RPG.DESC.CARCASS_HARVEST"]= "Increases yield from animal carcass harvesting.\n+{0}% yield per point.",
            // ── New nodes: values ─────────────────────
            ["RPG.VAL.FIRE_START"]      = "+{0}% burn time (total: +{1:F0}%)",
            ["RPG.VAL.COLD_ADAPT"]      = "-{0}% cold dmg (total: -{1:F0}%)",
            ["RPG.VAL.BOW_STEADINESS"]  = "+{0}% damage (total: +{1:F0}%)",
            ["RPG.VAL.CARCASS_HARVEST"] = "+{0}% yield (total: +{1:F0}%)",
        }
    };
}
