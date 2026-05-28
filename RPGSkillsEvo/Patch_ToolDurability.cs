using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(GearItem), "Degrade")]
internal static class Patch_ToolDurability
{
	private static void Prefix(GearItem __instance, ref float hp)
	{
		if (hp <= 0f) return;
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		if (__instance == null) return;
		// Only apply to tools/weapons, not clothing or food items
		if (__instance.m_ClothingItem != null) return;
		if (__instance.m_FoodItem != null) return;
		float bonus = Status.GetToolDurability();
		if (bonus > 0f)
			hp *= 1f - bonus;
	}
}
