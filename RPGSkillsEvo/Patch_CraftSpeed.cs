using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Panel_Inventory_Examine), "GetModifiedRepairDuration")]
internal static class Patch_CraftSpeed
{
	private static void Postfix(ref int __result)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetCraftSpeed();
		if (bonus > 0f)
		{
			__result = (int)(__result * (1f - bonus));
			if (__result < 1) __result = 1;
		}
	}
}
