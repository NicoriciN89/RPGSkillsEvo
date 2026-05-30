using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

// Secondary coverage for hide/pelt/gut items that don't have m_FoodItem
// and therefore don't pass through Patch_HarvestBonus.
// BodyHarvest.GetYieldKG controls how many kg of non-food items are available.
// If this method doesn't exist on the current TLD version, the patch silently no-ops.
[HarmonyPatch(typeof(BodyHarvest), "GetYieldKG")]
internal static class Patch_CarcassHarvest
{
	private static void Postfix(BodyHarvest __instance, ref float __result)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		// Skip food items — they're already handled by Patch_HarvestBonus
		if (__instance.m_GearItem != null && __instance.m_GearItem.m_FoodItem != null) return;
		float bonus = Status.GetCarcassHarvest();
		if (bonus > 0f)
			__result *= 1f + bonus;
	}
}
