using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Il2Cpp;
using MelonLoader;
using MelonLoader.Utils;
using UnityEngine;

namespace RPGSkillsEvo;

public static class EvoSaveManager
{
	private const string CURRENT_VERSION = "2.0.0";

	private static string GetSavePath(string slotName)
	{
		if (string.IsNullOrEmpty(slotName))
		{
			return null;
		}
		string text = Path.Combine(MelonEnvironment.UserDataDirectory, "EvoSaves");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return Path.Combine(text, "EvoSave_" + slotName + ".txt");
	}

	public static string Serialize()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected I4, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected I4, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected I4, but got Unknown
		List<string> list = new List<string>();
		list.Add($"VERSION|{CURRENT_VERSION}");
		list.Add($"LEVEL|{PlayerLevel.Level}|{PlayerLevel.CurrentXP.ToString(CultureInfo.InvariantCulture)}|{PlayerLevel.SkillPoints}");
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, int> realNode in DataHub.RealNodes)
		{
			list2.Add($"{realNode.Key}:{realNode.Value}");
		}
		list.Add("NODES|" + string.Join(",", list2));
		list.Add($"HOTKEY|{(int)DataHub.MenuHotkey}");
		list.Add($"AUTOLOOT|{AutoLootManager.IsEnabled}|{AutoLootManager.ScanInterval.ToString(CultureInfo.InvariantCulture)}|{(int)AutoLootManager.ToggleHotkey}");
		List<string> list3 = new List<string>();
		AutoLootData.SlotData[] slots = AutoLootData.Slots;
		foreach (AutoLootData.SlotData slotData in slots)
		{
			list3.Add($"{slotData.CategoryKey}:{slotData.ItemKey}:{slotData.IsOn}");
		}
		list.Add("LOOTSLOTS|" + string.Join(",", list3));
		List<string> list4 = new List<string>();
		for (int j = 0; j < 7; j++)
		{
			QuickSlotData quickSlotData = QuickbarData.Slots[j];
			list4.Add($"{quickSlotData.ItemID}:{(int)quickSlotData.HotKey}:{quickSlotData.Category}:{quickSlotData.Priority}");
		}
		list.Add("QSLOTS|" + string.Join(",", list4));
		List<string> list5 = new List<string>();
		for (int k = 0; k < 3; k++)
		{
			list5.Add($"{(int)QuickbarData.PresetHotKeys[k]}");
		}
		list.Add("PRESETKEYS|" + string.Join(",", list5));
		for (int l = 0; l < 3; l++)
		{
			QuickPresetData quickPresetData = QuickbarData.Presets[l];
			List<string> list6 = new List<string>();
			foreach (ClothSlotID value in Enum.GetValues(typeof(ClothSlotID)))
			{
				string name = quickPresetData.GetName(value);
				if (!string.IsNullOrEmpty(name))
				{
					list6.Add($"{(int)value}:{name}");
				}
			}
			list.Add(string.Format("PRESET{0}|{1}", l, string.Join(",", list6)));
		}
		list.Add($"GUNZOOM|{GunZoomManager.rifleMult.ToString(CultureInfo.InvariantCulture)}|{GunZoomManager.revolverMult.ToString(CultureInfo.InvariantCulture)}");
		return string.Join("\n", list);
	}

	public static void Deserialize(string data)
	{
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (string.IsNullOrEmpty(data))
			{
				ResetToDefaults();
				return;
			}
			string[] array = data.Split('\n');
			string version = "1.0.0";
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.StartsWith("VERSION|"))
				{
					string[] array3 = text.Split('|');
					if (array3.Length >= 2)
					{
						version = array3[1].Trim();
					}
					break;
				}
			}
			string[] array4 = array;
			foreach (string text2 in array4)
			{
				if (string.IsNullOrEmpty(text2))
				{
					continue;
				}
				string[] array5 = text2.Split('|');
				if (array5.Length == 0)
				{
					continue;
				}
				switch (array5[0])
				{
				case "LEVEL":
					if (array5.Length >= 4)
					{
						PlayerLevel.Level = int.Parse(array5[1]);
						PlayerLevel.CurrentXP = float.Parse(array5[2], CultureInfo.InvariantCulture);
						PlayerLevel.SkillPoints = int.Parse(array5[3]);
					}
					break;
				case "NODES":
				{
					DataHub.RealNodes.Clear();
					if (array5.Length < 2 || string.IsNullOrEmpty(array5[1]))
					{
						break;
					}
					string[] array6 = array5[1].Split(',');
					foreach (string text3 in array6)
					{
						string[] array7 = text3.Split(':');
						if (array7.Length == 2 && int.TryParse(array7[1], out var result))
						{
							DataHub.RealNodes[array7[0]] = result;
						}
					}
					break;
				}
				case "HOTKEY":
					if (array5.Length >= 2)
					{
						DataHub.MenuHotkey = (KeyCode)int.Parse(array5[1]);
					}
					break;
				case "AUTOLOOT":
					if (array5.Length >= 4)
					{
						AutoLootManager.IsEnabled = bool.Parse(array5[1]);
						AutoLootManager.ScanInterval = float.Parse(array5[2], CultureInfo.InvariantCulture);
						AutoLootManager.ToggleHotkey = (KeyCode)int.Parse(array5[3]);
					}
					break;
				case "LOOTSLOTS":
				{
					if (array5.Length < 2 || string.IsNullOrEmpty(array5[1]))
					{
						break;
					}
					string[] array10 = array5[1].Split(',');
					for (int m = 0; m < array10.Length && m < AutoLootData.Slots.Length; m++)
					{
						string[] array11 = array10[m].Split(':');
						if (array11.Length >= 3)
						{
							AutoLootData.Slots[m].CategoryKey = array11[0];
							AutoLootData.Slots[m].ItemKey = array11[1];
							AutoLootData.Slots[m].IsOn = bool.Parse(array11[2]);
						}
					}
					AutoLootData.ConfirmSlots();
					break;
				}
				case "QSLOTS":
				{
					if (array5.Length < 2 || string.IsNullOrEmpty(array5[1]))
					{
						break;
					}
					string[] array12 = array5[1].Split(',');
					for (int n = 0; n < array12.Length && n < 7; n++)
					{
						string[] array13 = array12[n].Split(':');
						if (array13.Length >= 4)
						{
							QuickbarData.Slots[n].ItemID = array13[0];
							QuickbarData.Slots[n].HotKey = (KeyCode)int.Parse(array13[1]);
							QuickbarData.Slots[n].Category = array13[2];
							QuickbarData.Slots[n].Priority = array13[3];
						}
					}
					QuickbarData.ConfirmAll();
					QuickbarHUDRenderer.UpdateKeyStrings();
					break;
				}
				case "PRESETKEYS":
					if (array5.Length >= 2 && !string.IsNullOrEmpty(array5[1]))
					{
						string[] array14 = array5[1].Split(',');
						for (int num2 = 0; num2 < array14.Length && num2 < 3; num2++)
						{
							QuickbarData.PresetHotKeys[num2] = (KeyCode)int.Parse(array14[num2]);
						}
						QuickbarHUDRenderer.UpdateKeyStrings();
					}
					break;
				case "PRESET0":
				case "PRESET1":
				case "PRESET2":
				{
					int num = int.Parse(array5[0].Replace("PRESET", ""));
					if (num >= 3)
					{
						break;
					}
					QuickbarData.Presets[num].ClothingInstanceIDs.Clear();
					QuickbarData.Presets[num].ClothingNames.Clear();
					if (array5.Length >= 2 && !string.IsNullOrEmpty(array5[1]))
					{
						string[] array8 = array5[1].Split(',');
						foreach (string text4 in array8)
						{
							string[] array9 = text4.Split(':');
							if (array9.Length == 2)
							{
								ClothSlotID key = (ClothSlotID)int.Parse(array9[0]);
								QuickbarData.Presets[num].ClothingNames[key] = array9[1];
							}
						}
					}
					QuickbarData.ConfirmAll();
					break;
				}
				case "GUNZOOM":
					if (array5.Length >= 3)
					{
						GunZoomManager.rifleMult = float.Parse(array5[1], CultureInfo.InvariantCulture);
						GunZoomManager.revolverMult = float.Parse(array5[2], CultureInfo.InvariantCulture);
					}
					break;
				}
			}
			EvoMigration.Run(ref version);
			Status.RefreshCache();
			WeightManager.UpdateFromEvo();
		}
		catch (Exception ex)
		{
			MelonLogger.Error("[EvoSaveManager] Load failed: " + ex.Message);
			ResetToDefaults();
		}
	}

	public static void ResetToDefaults()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		PlayerLevel.Reset();
		DataHub.RealNodes.Clear();
		DataHub.MenuHotkey = (KeyCode)286;
		AutoLootManager.IsEnabled = false;
		AutoLootManager.ScanInterval = 2f;
		AutoLootManager.ToggleHotkey = (KeyCode)108;
		AutoLootData.SlotData[] slots = AutoLootData.Slots;
		foreach (AutoLootData.SlotData slotData in slots)
		{
			slotData.CategoryKey = "";
			slotData.ItemKey = "";
			slotData.IsOn = false;
		}
		AutoLootData.ConfirmSlots();
		for (int j = 0; j < 7; j++)
		{
			QuickbarData.Slots[j].ItemID = "None";
			QuickbarData.Slots[j].Category = "Weapon";
			QuickbarData.Slots[j].Priority = "Low";
			QuickbarData.Slots[j].HotKey = (KeyCode)0;
		}
		for (int k = 0; k < 3; k++)
		{
			QuickbarData.Presets[k].ClothingInstanceIDs.Clear();
			QuickbarData.Presets[k].ClothingNames.Clear();
		}
		QuickbarData.ConfirmAll();
		QuickbarHUDRenderer.UpdateKeyStrings();
		GunZoomManager.Reset();
		Status.RefreshCache();
		WeightManager.UpdateFromEvo();
	}

	public static void Save(string slotName)
	{
		string savePath = GetSavePath(slotName);
		if (savePath == null)
		{
			return;
		}
		try
		{
			File.WriteAllText(savePath, Serialize());
		}
		catch (Exception ex)
		{
			MelonLogger.Error("[EvoSaveManager] Save failed: " + ex.Message);
		}
	}

	public static void Load(string slotName)
	{
		ResetToDefaults();
		string savePath = GetSavePath(slotName);
		if (savePath != null && File.Exists(savePath))
		{
			Deserialize(File.ReadAllText(savePath));
		}
	}

	public static string ResolveSlotName(SlotData slot)
	{
		if (slot == null)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(slot.m_BaseName))
		{
			return slot.m_BaseName;
		}
		if (!string.IsNullOrEmpty(slot.m_Filename))
		{
			return Path.GetFileNameWithoutExtension(slot.m_Filename);
		}
		return null;
	}
}
