using System;
using System.Collections.Generic;
using Il2Cpp;

namespace RPGSkillsEvo;

public static class AutoLootData
{
	public class SlotData
	{
		public string CategoryKey = "";

		public string ItemKey = "";

		public bool IsOn = false;

		public SlotData Clone()
		{
			return new SlotData
			{
				CategoryKey = CategoryKey,
				ItemKey = ItemKey,
				IsOn = IsOn
			};
		}

		public void CopyFrom(SlotData other)
		{
			CategoryKey = other.CategoryKey;
			ItemKey = other.ItemKey;
			IsOn = other.IsOn;
		}
	}

	public const int BaseSlotCount = 5;

	public const int MaxSlotCount = 15;

	public static SlotData[] Slots;

	private static SlotData[] confirmedSlots;

	public static Dictionary<string, List<string>> Categories;

	public static int GetActiveSlotCount()
	{
		int num = 5;
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			if (allNode.Effect == EffectType.LootSlot)
			{
				int num2 = (DataHub.RealNodes.ContainsKey(allNode.ID) ? DataHub.RealNodes[allNode.ID] : 0);
				num += num2;
			}
		}
		return Math.Min(num, 15);
	}

	public static float GetActiveLootRadius()
	{
		float num = 5f;
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			if (allNode.Effect == EffectType.LootRadius)
			{
				int num2 = (DataHub.RealNodes.ContainsKey(allNode.ID) ? DataHub.RealNodes[allNode.ID] : 0);
				num += (float)num2 * allNode.EffectPerLevel;
			}
		}
		return num;
	}

	static AutoLootData()
	{
		Slots = new SlotData[15];
		confirmedSlots = new SlotData[15];
		Categories = new Dictionary<string, List<string>>
		{
			{
				Loc.Get("RPG.CAT.ARROW"),
				new List<string> { "GEAR_Arrow", "GEAR_BrokenArrow", "GEAR_ArrowHardened", "GEAR_ArrowManufactured", "GEAR_BrokenArrowManufactured", "GEAR_BrokenArrowHardened", "GEAR_ArrowShaft", "GEAR_ArrowHead", "GEAR_CrowFeather" }
			},
			{
				Loc.Get("RPG.CAT.WOOD"),
				new List<string>
				{
					"GEAR_Stick", "GEAR_Coal", "GEAR_Charcoal", "GEAR_Softwood", "GEAR_Hardwood", "GEAR_BirchSaplingDried", "GEAR_BirchSapling", "GEAR_MapleSaplingDried", "GEAR_MapleSapling", "GEAR_BarkTinder",
					"GEAR_ReclaimedWoodB"
				}
			},
			{
				Loc.Get("RPG.CAT.PLANT"),
				new List<string> { "GEAR_RoseHip", "GEAR_ReishiMushroom", "GEAR_Burdock", "GEAR_OldMansBeardHarvested", "GEAR_Acorn", "GEAR_CattailStalk", "GEAR_CatailTinder", "GEAR_CattailPlant" }
			},
			{
				Loc.Get("RPG.CAT.AMMO"),
				new List<string> { "GEAR_RevolverAmmoBox", "GEAR_RevolverAmmoSingle", "GEAR_RevolverAmmoCasing", "GEAR_RifleAmmoBox", "GEAR_RifleAmmoSingle", "GEAR_RifleAmmoCasing" }
			},
			{
				Loc.Get("RPG.CAT.HIDE"),
				new List<string>
				{
					"GEAR_LeatherHideDried", "GEAR_LeatherHide", "GEAR_BearHideDried", "GEAR_BearHide", "GEAR_RabbitPeltDried", "GEAR_RabbitPelt", "GEAR_WolfPeltDried", "GEAR_WolfPelt", "GEAR_MooseHideDried", "GEAR_MooseHide",
					"GEAR_CougarHideDried", "GEAR_CougarHide", "GEAR_Cloth", "GEAR_LeatherDried", "GEAR_GutDried", "GEAR_Gut"
				}
			},
			{
				Loc.Get("RPG.CAT.FIRE"),
				new List<string> { "GEAR_WoodMatches", "GEAR_PackMatches" }
			},
			{
				Loc.Get("RPG.CAT.MISC"),
				new List<string> { "GEAR_ScrapMetal", "GEAR_Stone" }
			},
			{
				Loc.Get("RPG.CAT.CUSTOM"),
				new List<string>()
			}
		};
		for (int i = 0; i < 15; i++)
		{
			Slots[i] = new SlotData();
			confirmedSlots[i] = new SlotData();
		}
	}

	public static void ConfirmSlots()
	{
		for (int i = 0; i < 15; i++)
		{
			confirmedSlots[i].CopyFrom(Slots[i]);
		}
	}

	public static void RevertSlots()
	{
		for (int i = 0; i < 15; i++)
		{
			Slots[i].CopyFrom(confirmedSlots[i]);
		}
	}

	public static string GetDisplayName(string gearKey)
	{
		if (string.IsNullOrEmpty(gearKey))
		{
			return gearKey;
		}
		string gearDisplayName = GearItem.GetGearDisplayName(gearKey);
		return string.IsNullOrEmpty(gearDisplayName) ? gearKey : gearDisplayName;
	}

	public static bool IsTargetItem(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return false;
		}
		string text = name.Replace("(Clone)", "").Trim();
		int activeSlotCount = GetActiveSlotCount();
		for (int i = 0; i < activeSlotCount; i++)
		{
			if (Slots[i].IsOn && !string.IsNullOrEmpty(Slots[i].ItemKey) && text == Slots[i].ItemKey)
			{
				return true;
			}
		}
		if (AutoLootUserCustom.IsCustomTarget(text))
		{
			return true;
		}
		return false;
	}
}
