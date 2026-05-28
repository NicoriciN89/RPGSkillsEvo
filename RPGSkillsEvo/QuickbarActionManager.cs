using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using UnityEngine;

namespace RPGSkillsEvo;

public static class QuickbarActionManager
{
	public static void ExecuteSlot(QuickSlotData slot)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (slot == null || string.IsNullOrEmpty(slot.ItemID) || slot.ItemID == "None")
		{
			return;
		}
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			return;
		}
		GearItem val = null;
		foreach (var current in inventoryComponent.m_Items)
		{
			GearItem gearItem = current.m_GearItem;
			if ((UnityEngine.Object)(object)gearItem == (UnityEngine.Object)null || ((UnityEngine.Object)gearItem).name != slot.ItemID)
			{
				continue;
			}
			if ((UnityEngine.Object)(object)gearItem.m_WaterSupply != (UnityEngine.Object)null)
			{
				ItemLiquidVolume volumeInLiters = gearItem.m_WaterSupply.m_VolumeInLiters;
				if (volumeInLiters.ToQuantity(1f) <= 0f)
				{
					continue;
				}
			}
			else
			{
				ItemWeight weightKG = gearItem.WeightKG;
				if (weightKG.ToQuantity(1f) <= 0f && (UnityEngine.Object)(object)gearItem.m_StackableItem == (UnityEngine.Object)null)
				{
					continue;
				}
			}
			if ((UnityEngine.Object)(object)val == (UnityEngine.Object)null)
			{
				val = gearItem;
			}
			else if (slot.Priority == "Low" && gearItem.m_CurrentHP < val.m_CurrentHP)
			{
				val = gearItem;
			}
			else if (slot.Priority == "High" && gearItem.m_CurrentHP > val.m_CurrentHP)
			{
				val = gearItem;
			}
		}
		if ((UnityEngine.Object)(object)val == (UnityEngine.Object)null)
		{
			return;
		}
		PlayerManager playerManagerComponent = GameManager.GetPlayerManagerComponent();
		if ((UnityEngine.Object)(object)playerManagerComponent != (UnityEngine.Object)null)
		{
			if ((UnityEngine.Object)(object)val.m_FoodItem != (UnityEngine.Object)null || (UnityEngine.Object)(object)val.m_WaterSupply != (UnityEngine.Object)null)
			{
				playerManagerComponent.UseInventoryItem(val, false);
			}
			else
			{
				playerManagerComponent.EquipItem(val, false);
			}
		}
	}

	public static Texture2D GetIcon(string itemID)
	{
		if (string.IsNullOrEmpty(itemID) || itemID == "None")
		{
			return null;
		}
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			return null;
		}
		foreach (var current in inventoryComponent.m_Items)
		{
			GearItem val = ((current != null) ? current.m_GearItem : null);
			if ((UnityEngine.Object)(object)val != (UnityEngine.Object)null && ((UnityEngine.Object)val).name == itemID)
			{
				return val.GetInventoryIconTexture();
			}
		}
		return null;
	}
}
