using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Freezing), "CalculateBodyTemperature")]
internal static class Patch_WarmthBonus
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			__result += WarmthManager.GetWarmthBonus();
		}
	}
}
