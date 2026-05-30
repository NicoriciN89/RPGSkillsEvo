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

		var stackable = pickupItem.m_StackableItem;
		if (stackable == null) return;

		var food = pickupItem.m_FoodItem;
		if (food == null) return;

		if (food.m_IsNatural)
		{
			// Berries, mushrooms, cattails, etc. — HarvestBonus nodes
			float bonus = Status.GetHarvestBonus();
			if (bonus > 0f)
			{
				int bonusUnits = Mathf.FloorToInt(stackable.m_Units * bonus);
				if (bonusUnits > 0) stackable.m_Units += bonusUnits;
			}
		}
		else
		{
			// Animal meat, fat, fish — Forager (CarcassHarvest) nodes
			float bonus = Status.GetCarcassHarvest();
			if (bonus > 0f)
			{
				int bonusUnits = Mathf.FloorToInt(stackable.m_Units * bonus);
				if (bonusUnits > 0) stackable.m_Units += bonusUnits;
			}
		}
	}
}
