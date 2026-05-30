using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RPGSkillsEvo;

public static class QuickbarData
{
	public const int BaseSlotCount = 2;

	public const int MaxSlotCount = 7;

	public const int BasePresetCount = 2;

	public const int MaxPresetCount = 3;

	public static QuickSlotData[] Slots;

	private static QuickSlotData[] confirmedSlots;

	public static QuickPresetData[] Presets;

	private static QuickPresetData[] confirmedPresets;

	public static KeyCode[] PresetHotKeys;

	private static KeyCode[] confirmedPresetHotKeys;

	public static readonly HashSet<string> WeaponList;

	public static readonly HashSet<string> FireList;

	public static readonly HashSet<string> ToolList;

	static QuickbarData()
	{
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		Slots = new QuickSlotData[7];
		confirmedSlots = new QuickSlotData[7];
		Presets = new QuickPresetData[3];
		confirmedPresets = new QuickPresetData[3];
		PresetHotKeys = new KeyCode[3];
		confirmedPresetHotKeys = new KeyCode[3];
		WeaponList = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"revolver", "revolverfancy", "revolvergreen", "revolverstubnosed", "rifle", "rifle_barbs", "rifle_curators", "rifle_trader", "rifle_vaughns", "bow",
			"bow_bushcraft", "bow_manufactured", "bow_woodwrights", "flaregun", "stone"
		};
		FireList = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "kerosenelampb", "kerosenelamp_spelunkers", "WoodMatches", "PackMatches", "torch" };
		ToolList = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "blueflare", "flareA" };
		KeyCode[] array4 = new KeyCode[7];
		for (int i = 0; i < 7; i++)
		{
			Slots[i] = new QuickSlotData
			{
				HotKey = array4[i]
			};
			confirmedSlots[i] = new QuickSlotData
			{
				HotKey = array4[i]
			};
		}
		for (int j = 0; j < 3; j++)
		{
			Presets[j] = new QuickPresetData();
			confirmedPresets[j] = new QuickPresetData();
		}
	}

	public static int GetActiveSlotCount() => Status.GetActiveQuickSlotCount();

	public static int GetActivePresetCount() => Status.GetActivePresetSlotCount();

	public static bool IsQuickSlotUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("N6W1") && DataHub.RealNodes["N6W1"] > 0;
	}

	public static bool IsPresetUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("N6W1N1") && DataHub.RealNodes["N6W1N1"] > 0;
	}

	public static void ConfirmAll()
	{
		for (int i = 0; i < 7; i++)
		{
			confirmedSlots[i].CopyFrom(Slots[i]);
		}
		for (int j = 0; j < 3; j++)
		{
			confirmedPresets[j].CopyFrom(Presets[j]);
		}
		for (int k = 0; k < 3; k++)
		{
			confirmedPresetHotKeys[k] = PresetHotKeys[k];
		}
	}

	public static void RevertAll()
	{
		for (int i = 0; i < 7; i++)
		{
			Slots[i].CopyFrom(confirmedSlots[i]);
		}
		for (int j = 0; j < 3; j++)
		{
			Presets[j].CopyFrom(confirmedPresets[j]);
		}
		for (int k = 0; k < 3; k++)
		{
			PresetHotKeys[k] = confirmedPresetHotKeys[k];
		}
	}

	public static string GetCleanName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return "";
		}
		return name.Replace("GEAR_", "").Replace("(Clone)", "").Trim();
	}

	public static bool IsValidItem(string name, string cat)
	{
		string cleanName = GetCleanName(name);
		return cat switch
		{
			"Weapon" => WeaponList.Contains(cleanName), 
			"Fire" => FireList.Contains(cleanName), 
			"Tool" => ToolList.Contains(cleanName), 
			_ => false, 
		};
	}
}
