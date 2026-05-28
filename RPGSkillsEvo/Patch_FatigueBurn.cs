using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Fatigue), "CalculateFatigueIncrease")]
internal static class Patch_FatigueBurn
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			__result *= 1f - FatigueManager.GetFatigueReduction();
		}
	}
}
