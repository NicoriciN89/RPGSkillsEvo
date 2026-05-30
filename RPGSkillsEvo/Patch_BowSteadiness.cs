using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

// Increases bow arrow damage by BowSteadiness bonus (up to 50%).
// Better "focus" translates to more accurate, harder-hitting shots.
[HarmonyPatch(typeof(BowItem), "GetArrowDamage")]
internal static class Patch_BowSteadiness
{
	private static void Postfix(ref float __result)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetBowSteadiness();
		if (bonus > 0f)
			__result *= 1f + bonus;
	}
}
