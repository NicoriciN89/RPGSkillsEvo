using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Fatigue), "UpdateFatigueStatusOnHUD")]
internal static class Patch_MaxFatigue_Vitality
{
	private static void Postfix(Fatigue __instance)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			MaxConditionManager.ApplyFatigue(__instance);
		}
	}
}
