using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppTLD.Gear;
using UnityEngine;

namespace RPGSkillsEvo;

public static class QuickbarPresetManager
{
	private static readonly List<ClothSlotID> wearOrder;

	static QuickbarPresetManager()
	{
		wearOrder = new List<ClothSlotID>();
		wearOrder.Add(ClothSlotID.Head_Inner);
		wearOrder.Add(ClothSlotID.Chest_InnerBase);
		wearOrder.Add(ClothSlotID.Legs_Underwear1);
		wearOrder.Add(ClothSlotID.Feet_Socks1);
		wearOrder.Add(ClothSlotID.Hands);
		wearOrder.Add(ClothSlotID.Accessory1);
		wearOrder.Add(ClothSlotID.Head_Outer);
		wearOrder.Add(ClothSlotID.Chest_InnerMid);
		wearOrder.Add(ClothSlotID.Legs_Underwear2);
		wearOrder.Add(ClothSlotID.Feet_Socks2);
		wearOrder.Add(ClothSlotID.Chest_InnerOuter);
		wearOrder.Add(ClothSlotID.Legs_Inner);
		wearOrder.Add(ClothSlotID.Feet_Boots);
		wearOrder.Add(ClothSlotID.Chest_Outer);
		wearOrder.Add(ClothSlotID.Legs_Outer);
		wearOrder.Add(ClothSlotID.Accessory2);
	}

	public static void ApplyPreset(QuickPresetData preset)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		if (preset == null)
		{
			return;
		}
		PlayerManager playerManagerComponent = GameManager.GetPlayerManagerComponent();
		if ((UnityEngine.Object)(object)playerManagerComponent == (UnityEngine.Object)null)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (ClothSlotID item in wearOrder)
		{
			int instanceID = preset.GetInstanceID(item);
			string name = preset.GetName(item);
			ClothingRegion region = QuickClothData.GetRegion(item);
			ClothingLayer layer = QuickClothData.GetLayer(item);
			if (instanceID == -1 || string.IsNullOrEmpty(name) || name == "None")
			{
				GearItem clothingInSlot = playerManagerComponent.GetClothingInSlot(region, layer);
				if ((UnityEngine.Object)(object)clothingInSlot != (UnityEngine.Object)null)
				{
					playerManagerComponent.TakeOffClothingItem(clothingInSlot);
				}
				continue;
			}
			GearItem val = FindItem(instanceID, name);
			if ((UnityEngine.Object)(object)val == (UnityEngine.Object)null || list.Contains(val.m_InstanceID))
			{
				continue;
			}
			if (playerManagerComponent.IsWearingClothingItem(val))
			{
				list.Add(val.m_InstanceID);
				continue;
			}
			GearItem clothingInSlot2 = playerManagerComponent.GetClothingInSlot(region, layer);
			if ((UnityEngine.Object)(object)clothingInSlot2 != (UnityEngine.Object)null)
			{
				playerManagerComponent.TakeOffClothingItem(clothingInSlot2);
			}
			playerManagerComponent.PutOnClothingItem(val, layer);
			list.Add(val.m_InstanceID);
		}
		HUDMessage.AddMessage("프리셋 적용됨", 2f, true, false);
		GameAudioManager.PlayGuiConfirm();
	}

	private static GearItem FindItem(int instanceID, string prefabName)
	{
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			return null;
		}
		GearItem result = null;
		foreach (var current in inventoryComponent.m_Items)
		{
			GearItem val = ((current != null) ? current.m_GearItem : null);
			if ((UnityEngine.Object)(object)val != (UnityEngine.Object)null)
			{
				if (val.m_InstanceID == instanceID)
				{
					return val;
				}
				if (((UnityEngine.Object)val).name == prefabName)
				{
					result = val;
				}
			}
		}
		return result;
	}
}
