using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Condition), "GetAdjustedMaxHPModifier")]
internal static class Patch_MaxHP_Vitality
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float num = MaxConditionManager.GetVitalityBonus() - MaxConditionManager.GetVitalityDownPenalty();
			__result += num;
		}
	}
}
