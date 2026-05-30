using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

// Makes fires burn longer by FireStartBonus multiplier (up to +50% duration).
// Fire.GetModifiedBurnDurationHours controls how many hours a fire will last;
// multiplying by (1 + bonus) extends burn time.
[HarmonyPatch(typeof(Fire), "GetModifiedBurnDurationHours")]
internal static class Patch_FireStartBonus
{
	private static void Postfix(ref float __result)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetFireStartBonus();
		if (bonus > 0f)
			__result *= 1f + bonus;
	}
}
