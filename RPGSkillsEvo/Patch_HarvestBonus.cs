using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.ProcessPickupWithNoInspectScreen))]
internal static class Patch_HarvestBonus
{
	private static void Prefix(GearItem pickupItem)
	{
		if (pickupItem == null) return;
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;

		float bonus = Status.GetHarvestBonus();
		if (bonus <= 0f) return;

		var stackable = pickupItem.m_StackableItem;
		if (stackable == null) return;

		var food = pickupItem.m_FoodItem;
		if (food == null || !food.m_IsNatural) return;

		int bonusUnits = Mathf.FloorToInt(stackable.m_Units * bonus);
		if (bonusUnits <= 0) return;

		stackable.m_Units += bonusUnits;
	}
}
