using System;
using System.Collections.Generic;
using Il2Cpp;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using UnityEngine;

namespace RPGSkillsEvo;

public static class QuickbarUI
{
	private enum TabMode
	{
		QuickSlot,
		Preset
	}

	public static bool IsOpen = false;

	private static Rect windowRect = new Rect(0f, 0f, 1000f, 800f);
	private static bool windowRectInit = false;

	private static Rect confirmRect = new Rect(0f, 0f, 400f, 200f);
	private static bool confirmRectInit = false;

	private static TabMode currentTab = TabMode.QuickSlot;

	private static int selectedSlot = -1;

	private static List<GearItem> filteredItems = new List<GearItem>();

	private static Vector2 itemScrollPos = Vector2.zero;

	private static int waitingForKeySlot = -1;

	private static int waitingForPresetKey = -1;

	private static int selectedPreset = -1;

	private static int activeSelectionSlot = -1;

	private static List<GearItem> presetFilteredItems = new List<GearItem>();

	private static Vector2 presetScrollPos = Vector2.zero;

	private static Dictionary<ClothSlotID, Texture2D> presetIconCache = new Dictionary<ClothSlotID, Texture2D>();

	private static bool presetCacheDirty = true;

	private static bool isDirty = false;

	private static bool showConfirmWindow = false;

	private static Action onConfirmClose;

	public static void OpenMenu()
	{
		IsOpen = true;
		isDirty = false;
		showConfirmWindow = false;
		selectedSlot = -1;
		selectedPreset = -1;
		activeSelectionSlot = -1;
		waitingForKeySlot = -1;
		waitingForPresetKey = -1;
		currentTab = TabMode.QuickSlot;
		presetCacheDirty = true;
	}

	public static void TryCloseMenu(Action onCloseAction = null)
	{
		if (!showConfirmWindow)
		{
			if (isDirty)
			{
				onConfirmClose = onCloseAction;
				showConfirmWindow = true;
			}
			else
			{
				IsOpen = false;
				onCloseAction?.Invoke();
			}
		}
	}

	public static void CloseMenu()
	{
		IsOpen = false;
		isDirty = false;
		showConfirmWindow = false;
		waitingForKeySlot = -1;
		waitingForPresetKey = -1;
		onConfirmClose = null;
	}

	private static void ApplyChanges()
	{
		QuickbarData.ConfirmAll();
		QuickbarHUDRenderer.UpdateKeyStrings();
		QuickbarHUDRenderer.RefreshIcons();
		isDirty = false;
		showConfirmWindow = false;
	}

	private static void MarkDirty()
	{
		isDirty = true;
	}

	public static void OnGUI()
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected I4, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Invalid comparison between Unknown and I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			return;
		}
		if (waitingForKeySlot >= 0)
		{
			Event current = Event.current;
			if (current != null && current.isKey && (int)current.keyCode != 0 && (int)current.keyCode != 27)
			{
				QuickbarData.Slots[waitingForKeySlot].HotKey = current.keyCode;
				waitingForKeySlot = -1;
				MarkDirty();
				QuickbarHUDRenderer.UpdateKeyStrings();
			}
			else if (current != null && current.isKey && (int)current.keyCode == 27)
			{
				waitingForKeySlot = -1;
			}
		}
		if (waitingForPresetKey >= 0)
		{
			Event current2 = Event.current;
			if (current2 != null && current2.isKey && (int)current2.keyCode != 0 && (int)current2.keyCode != 27)
			{
				QuickbarData.PresetHotKeys[waitingForPresetKey] = (KeyCode)(int)current2.keyCode;
				waitingForPresetKey = -1;
				MarkDirty();
				QuickbarHUDRenderer.UpdateKeyStrings();
			}
			else if (current2 != null && current2.isKey && (int)current2.keyCode == 27)
			{
				waitingForPresetKey = -1;
			}
		}
		GUI.depth = 4;
		if (!windowRectInit) { windowRect = new Rect((float)(Screen.width / 2 - 500), (float)(Screen.height / 2 - 400), 1000f, 800f); windowRectInit = true; }
		if (!confirmRectInit) { confirmRect = new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 100), 400f, 200f); confirmRectInit = true; }
		windowRect = GUI.Window(30, windowRect, (Action<int>)DrawWindow, "");
		if (showConfirmWindow)
		{
			GUI.depth = 0;
			confirmRect = GUI.Window(31, confirmRect, (Action<int>)DrawConfirmWindow, "SYSTEM");
			GUI.BringWindowToFront(31);
		}
	}

	private static void DrawWindow(int id)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		GUI.color = new Color(0.02f, 0.02f, 0.02f, 1f);
		GUI.DrawTexture(new Rect(0f, 0f, 1000f, 800f), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(new Rect(2f, 2f, 996f, 796f), new Color(0.6f, 0.6f, 0.6f, 1f), 1f);
		DrawingUtils.DrawRectOutline(new Rect(0f, 0f, 1000f, 800f), new Color(0.25f, 0.25f, 0.25f, 1f), 2f);
		GUIStyle val = new GUIStyle
		{
			alignment = (TextAnchor)4,
			fontSize = 24,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.white;
		GUIStyle val2 = val;
		GUI.Label(new Rect(0f, 5f, 1000f, 40f), "퀵바 설정", val2);
		DrawingUtils.DrawRectOutline(new Rect(20f, 44f, 960f, 1f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		if (GUI.Button(new Rect(950f, 8f, 40f, 30f), "X"))
		{
			TryCloseMenu(delegate
			{
				IsOpen = false;
			});
		}
		bool flag = QuickbarData.IsPresetUnlocked();
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 14,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		GUI.color = ((currentTab == TabMode.QuickSlot) ? Color.yellow : Color.white);
		if (GUI.Button(new Rect(20f, 52f, 180f, 35f), Loc.Get("RPG.QB.TAB_SLOTS"), val4))
		{
			currentTab = TabMode.QuickSlot;
			selectedSlot = -1;
		}
		GUI.color = Color.white;
		if (flag)
		{
			GUI.color = ((currentTab == TabMode.Preset) ? Color.yellow : Color.white);
			if (GUI.Button(new Rect(210f, 52f, 180f, 35f), Loc.Get("RPG.QB.TAB_PRESET"), val4))
			{
				currentTab = TabMode.Preset;
				selectedPreset = -1;
				activeSelectionSlot = -1;
				presetCacheDirty = true;
			}
			GUI.color = Color.white;
		}
		GUIStyle val5 = new GUIStyle
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val5.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
		val5.alignment = (TextAnchor)3;
		GUIStyle val6 = val5;
		GUI.Label(new Rect(500f, 55f, 250f, 30f), Loc.Get("RPG.UI.AL_ACTIVE_SLOTS", QuickbarData.GetActiveSlotCount(), 7), val6);
		if (isDirty && !showConfirmWindow)
		{
			GUI.color = Color.green;
			if (GUI.Button(new Rect(730f, 52f, 210f, 35f), Loc.Get("RPG.UI.BTN_APPLY_CHANGES")))
			{
				ApplyChanges();
			}
			GUI.color = Color.white;
		}
		DrawingUtils.DrawRectOutline(new Rect(20f, 95f, 960f, 1f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		if (currentTab == TabMode.QuickSlot)
		{
			DrawQuickSlotTab();
		}
		else if (currentTab == TabMode.Preset && flag)
		{
			DrawPresetTab();
		}
	}

	private static void DrawQuickSlotTab()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		int activeSlotCount = QuickbarData.GetActiveSlotCount();
		GUIStyle val = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.white;
		val.alignment = (TextAnchor)3;
		GUIStyle val2 = val;
		Rect val3 = default(Rect);
		for (int i = 0; i < activeSlotCount; i++)
		{
			QuickSlotData quickSlotData = QuickbarData.Slots[i];
			val3 = new Rect(20f, (float)(103 + i * 65), 260f, 58f);
			GUI.color = ((selectedSlot == i) ? Color.yellow : Color.white);
			string text = ((quickSlotData.ItemID == "None") ? "EMPTY" : GearItem.GetGearDisplayName(quickSlotData.ItemID));
			if (string.IsNullOrEmpty(text))
			{
				text = quickSlotData.ItemID;
			}
			if (GUI.Button(val3, $"  [{i + 1}] {text}", val2))
			{
				selectedSlot = i;
				itemScrollPos = Vector2.zero;
				UpdateFilteredItems(i);
			}
			Texture2D icon = QuickbarActionManager.GetIcon(quickSlotData.ItemID);
			if ((UnityEngine.Object)(object)icon != (UnityEngine.Object)null)
			{
				GUI.DrawTexture(new Rect(val3.x + 5f, val3.y + 6f, 46f, 46f), (Texture)(object)icon, (ScaleMode)2);
			}
			GUI.color = Color.white;
		}
		if (selectedSlot >= 0 && selectedSlot < activeSlotCount)
		{
			DrawSlotDetail(selectedSlot);
		}
	}

	private static void DrawSlotDetail(int index)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		QuickSlotData quickSlotData = QuickbarData.Slots[index];
		GUI.Box(new Rect(295f, 100f, 685f, 688f), "");
		GUIStyle val = new GUIStyle
		{
			fontSize = 16,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.cyan;
		GUIStyle val2 = val;
		GUI.Label(new Rect(310f, 108f, 400f, 30f), Loc.Get("RPG.QB.SLOT_TITLE", index + 1), val2);
		string[] array = new string[4] { "Weapon", "Fire", "Tool", "Food" };
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		val3.alignment = (TextAnchor)4;
		GUIStyle val4 = val3;
		for (int i = 0; i < array.Length; i++)
		{
			GUI.color = ((quickSlotData.Category == array[i]) ? Color.yellow : Color.white);
			if (GUI.Button(new Rect((float)(310 + i * 90), 145f, 85f, 50f), array[i], val4))
			{
				quickSlotData.Category = array[i];
				MarkDirty();
				UpdateFilteredItems(index);
			}
		}
		GUI.color = Color.white;
		GUIStyle val5 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val5.normal.textColor = Color.white;
		GUIStyle val6 = val5;
		GUI.color = ((waitingForKeySlot == index) ? Color.yellow : Color.white);
		string text = ((waitingForKeySlot == index) ? Loc.Get("RPG.UI.AL_WAITING") : Loc.Get("RPG.UI.AL_HOTKEY", quickSlotData.HotKey));
		if (GUI.Button(new Rect(700f, 145f, 265f, 50f), text, val6))
		{
			waitingForKeySlot = index;
		}
		GUI.color = Color.white;
		GUIStyle val7 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val7.normal.textColor = Color.white;
		GUIStyle val8 = val7;
		if (GUI.Button(new Rect(700f, 205f, 265f, 40f), Loc.Get("RPG.QB.BTN_CLEAR"), val8))
		{
			quickSlotData.ItemID = "None";
			MarkDirty();
			QuickbarHUDRenderer.RefreshIcons();
		}
		float num = 62f;
		Rect val9 = new Rect(310f, 205f, 380f, 575f);
		Rect val10 = new Rect(0f, 0f, 360f, (float)filteredItems.Count * num);
		itemScrollPos = GUI.BeginScrollView(val9, itemScrollPos, val10);
		GUIStyle val11 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val11.normal.textColor = Color.white;
		val11.alignment = (TextAnchor)3;
		GUIStyle val12 = val11;
		for (int j = 0; j < filteredItems.Count; j++)
		{
			GearItem val13 = filteredItems[j];
			float num2 = (float)j * num;
			GUI.color = ((quickSlotData.ItemID == ((UnityEngine.Object)val13).name) ? Color.yellow : Color.white);
			if (GUI.Button(new Rect(0f, num2, 355f, num - 4f), $"   {val13.DisplayName} [{val13.GetNormalizedCondition() * 100f:F0}%]", val12))
			{
				quickSlotData.ItemID = ((UnityEngine.Object)val13).name;
				MarkDirty();
				QuickbarHUDRenderer.RefreshIcons();
			}
			Texture2D inventoryIconTexture = val13.GetInventoryIconTexture();
			if ((UnityEngine.Object)(object)inventoryIconTexture != (UnityEngine.Object)null)
			{
				GUI.DrawTexture(new Rect(3f, num2 + 6f, 50f, 50f), (Texture)(object)inventoryIconTexture, (ScaleMode)2);
			}
			GUI.color = Color.white;
		}
		GUI.EndScrollView();
	}

	private static void UpdateFilteredItems(int slotIndex)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		filteredItems.Clear();
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			return;
		}
		string category = QuickbarData.Slots[slotIndex].Category;
		foreach (var current in inventoryComponent.m_Items)
		{
			GearItem val = ((current != null) ? current.m_GearItem : null);
			if ((UnityEngine.Object)(object)val == (UnityEngine.Object)null)
			{
				continue;
			}
			if (category == "Food")
			{
				bool flag = (UnityEngine.Object)(object)val.m_FoodItem != (UnityEngine.Object)null && val.m_FoodItem.m_CaloriesRemaining > 0f;
				int num;
				if ((UnityEngine.Object)(object)val.m_WaterSupply != (UnityEngine.Object)null)
				{
					ItemLiquidVolume volumeInLiters = val.m_WaterSupply.m_VolumeInLiters;
					num = ((volumeInLiters.ToQuantity(1f) > 0f) ? 1 : 0);
				}
				else
				{
					num = 0;
				}
				bool flag2 = (byte)num != 0;
				bool flag3 = (UnityEngine.Object)(object)val.m_FoodItem != (UnityEngine.Object)null && val.m_FoodItem.m_IsDrink;
				if (flag || flag2 || flag3)
				{
					filteredItems.Add(val);
				}
			}
			else if (QuickbarData.IsValidItem(((UnityEngine.Object)val).name, category))
			{
				filteredItems.Add(val);
			}
		}
	}

	private static void DrawPresetTab()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		int activePresetCount = QuickbarData.GetActivePresetCount();
		string[] array = new string[3] { "★", "♥", "●" };
		Color[] array2 = (Color[])(object)new Color[3]
		{
			Color.cyan,
			Color.magenta,
			Color.green
		};
		GUIStyle val = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.white;
		GUIStyle val2 = val;
		GUIStyle val3 = new GUIStyle
		{
			fontSize = 22,
			alignment = (TextAnchor)4,
			fontStyle = (FontStyle)1
		};
		GUIStyle val4 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val4.normal.textColor = Color.white;
		GUIStyle val5 = val4;
		Rect val6 = default(Rect);
		for (int i = 0; i < activePresetCount; i++)
		{
			QuickPresetData quickPresetData = QuickbarData.Presets[i];
			val6 = new Rect(20f, (float)(103 + i * 95), 260f, 85f);
			GUI.color = ((selectedPreset == i) ? Color.yellow : Color.white);
			bool flag = quickPresetData.ClothingNames.Count > 0;
			string text = (flag ? $"  프리셋 {i + 1}\n  [등록됨]" : $"  프리셋 {i + 1}\n  [비어있음]");
			if (GUI.Button(val6, text, val2))
			{
				selectedPreset = i;
				activeSelectionSlot = -1;
				presetCacheDirty = true;
			}
			val3.normal.textColor = (Color)(flag ? array2[i] : new Color(0.4f, 0.4f, 0.4f, 0.5f));
			GUI.Label(new Rect(val6.x + 2f, val6.y, 35f, 85f), array[i], val3);
			GUI.color = Color.white;
			GUI.color = ((waitingForPresetKey == i) ? Color.yellow : Color.white);
			string text2 = ((waitingForPresetKey == i) ? "WAITING..." : $"핫키: {QuickbarData.PresetHotKeys[i]}");
			if (GUI.Button(new Rect(val6.xMax + 8f, val6.y + 25f, 140f, 35f), text2, val5))
			{
				waitingForPresetKey = i;
			}
			GUI.color = Color.white;
		}
		if (selectedPreset >= 0 && selectedPreset < activePresetCount)
		{
			if (presetCacheDirty)
			{
				RefreshPresetCache(selectedPreset);
			}
			if (activeSelectionSlot >= 0)
			{
				DrawPresetItemSelection();
			}
			else
			{
				DrawPresetLayout(selectedPreset);
			}
		}
	}

	private static void DrawPresetLayout(int index)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		GUI.Box(new Rect(455f, 100f, 525f, 688f), "");
		GUIStyle val = new GUIStyle
		{
			fontSize = 16,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.cyan;
		GUIStyle val2 = val;
		GUI.Label(new Rect(470f, 108f, 350f, 30f), $"프리셋 {index + 1} 설정", val2);
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		if (GUI.Button(new Rect(720f, 105f, 245f, 35f), "프리셋 적용", val4) && QuickbarData.Presets[index].ClothingNames.Count > 0)
		{
			QuickbarPresetManager.ApplyPreset(QuickbarData.Presets[index]);
		}
		float num = 78f;
		float num2 = 86f;
		float num3 = 470f;
		float x = 558f;
		float num4 = 720f;
		float num5 = 808f;
		float num6 = 150f;
		DrawPresetSlotBtn(ClothSlotID.Head_Outer, num3, num6, num);
		DrawPresetSlotBtn(ClothSlotID.Head_Inner, x, num6, num);
		DrawPresetSlotBtn(ClothSlotID.Chest_Outer, num3, num6 + num2, num);
		DrawPresetSlotBtn(ClothSlotID.Chest_InnerOuter, x, num6 + num2, num);
		DrawPresetSlotBtn(ClothSlotID.Chest_InnerMid, num3, num6 + num2 * 2f, num);
		DrawPresetSlotBtn(ClothSlotID.Chest_InnerBase, x, num6 + num2 * 2f, num);
		DrawPresetSlotBtn(ClothSlotID.Hands, num3 + 39f, num6 + num2 * 3f, num);
		DrawPresetSlotBtn(ClothSlotID.Accessory1, num4, num6, num);
		DrawPresetSlotBtn(ClothSlotID.Accessory2, num5, num6, num);
		DrawPresetSlotBtn(ClothSlotID.Legs_Inner, num4, num6 + num2, num);
		DrawPresetSlotBtn(ClothSlotID.Legs_Outer, num5, num6 + num2, num);
		DrawPresetSlotBtn(ClothSlotID.Legs_Underwear1, num4, num6 + num2 * 2f, num);
		DrawPresetSlotBtn(ClothSlotID.Legs_Underwear2, num5, num6 + num2 * 2f, num);
		float num7 = num6 + num2 * 3f;
		float num8 = (num4 + num5 + num) / 2f;
		DrawPresetSlotBtn(ClothSlotID.Feet_Socks1, num4, num7, num);
		DrawPresetSlotBtn(ClothSlotID.Feet_Socks2, num5, num7, num);
		DrawPresetSlotBtn(ClothSlotID.Feet_Boots, num8 - num / 2f, num7 + num2, num);
	}

	private static void DrawPresetSlotBtn(ClothSlotID slotID, float x, float y, float size)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		presetIconCache.TryGetValue(slotID, out var value);
		bool flag = (UnityEngine.Object)(object)value != (UnityEngine.Object)null;
		string text = (flag ? "" : ("[빈]\n" + QuickClothData.GetShortName(slotID)));
		GUIStyle val = new GUIStyle(GUI.skin.button)
		{
			fontSize = 10,
			alignment = (TextAnchor)4,
			wordWrap = true,
			fontStyle = (FontStyle)1
		};
		if (GUI.Button(new Rect(x, y, size, size), text, val))
		{
			activeSelectionSlot = (int)slotID;
			presetScrollPos = Vector2.zero;
			RefreshPresetItemList(slotID);
		}
		if (flag)
		{
			GUI.DrawTexture(new Rect(x + 5f, y + 5f, size - 10f, size - 10f), (Texture)(object)value, (ScaleMode)2);
		}
	}

	private static void DrawPresetItemSelection()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		GUI.Box(new Rect(455f, 100f, 525f, 688f), "");
		GUIStyle val = new GUIStyle
		{
			fontSize = 16,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.cyan;
		GUIStyle val2 = val;
		GUI.Label(new Rect(470f, 108f, 350f, 30f), "아이템 선택", val2);
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		if (GUI.Button(new Rect(730f, 105f, 235f, 35f), "← 뒤로", val4))
		{
			activeSelectionSlot = -1;
			presetCacheDirty = true;
		}
		QuickPresetData quickPresetData = QuickbarData.Presets[selectedPreset];
		int instanceID = quickPresetData.GetInstanceID((ClothSlotID)activeSelectionSlot);
		float num = 65f;
		Rect val5 = new Rect(470f, 148f, 495f, 632f);
		Rect val6 = new Rect(0f, 0f, 470f, (float)(presetFilteredItems.Count + 1) * num);
		presetScrollPos = GUI.BeginScrollView(val5, presetScrollPos, val6);
		GUIStyle val7 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val7.normal.textColor = Color.white;
		val7.alignment = (TextAnchor)3;
		GUIStyle val8 = val7;
		if (GUI.Button(new Rect(0f, 0f, 465f, num - 4f), "[ 비우기 ]", val8))
		{
			quickPresetData.SetClothing((ClothSlotID)activeSelectionSlot, null);
			activeSelectionSlot = -1;
			MarkDirty();
			presetCacheDirty = true;
		}
		for (int i = 0; i < presetFilteredItems.Count; i++)
		{
			GearItem val9 = presetFilteredItems[i];
			float num2 = (float)(i + 1) * num;
			GUI.color = ((val9.m_InstanceID == instanceID) ? Color.yellow : Color.white);
			if (GUI.Button(new Rect(0f, num2, 465f, num - 4f), $"   {val9.DisplayName} [{val9.GetNormalizedCondition() * 100f:F0}%]", val8))
			{
				quickPresetData.SetClothing((ClothSlotID)activeSelectionSlot, val9);
				activeSelectionSlot = -1;
				MarkDirty();
				presetCacheDirty = true;
			}
			try
			{
				Texture2D inventoryIconTexture = val9.GetInventoryIconTexture();
				if ((UnityEngine.Object)(object)inventoryIconTexture != (UnityEngine.Object)null)
				{
					GUI.DrawTexture(new Rect(3f, num2 + 6f, 55f, 55f), (Texture)(object)inventoryIconTexture, (ScaleMode)2);
				}
			}
			catch
			{
			}
			GUI.color = Color.white;
		}
		GUI.EndScrollView();
	}

	private static void RefreshPresetCache(int presetIndex)
	{
		presetIconCache.Clear();
		QuickPresetData quickPresetData = QuickbarData.Presets[presetIndex];
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			presetCacheDirty = false;
			return;
		}
		foreach (ClothSlotID value in Enum.GetValues(typeof(ClothSlotID)))
		{
			int instanceID = quickPresetData.GetInstanceID(value);
			if (instanceID == -1)
			{
				continue;
			}
			foreach (var current in inventoryComponent.m_Items)
			{
				GearItem val = ((current != null) ? current.m_GearItem : null);
				if ((UnityEngine.Object)(object)val != (UnityEngine.Object)null && val.m_InstanceID == instanceID)
				{
					presetIconCache[value] = val.GetInventoryIconTexture();
					break;
				}
			}
		}
		presetCacheDirty = false;
	}

	private static void RefreshPresetItemList(ClothSlotID slotID)
	{
		presetFilteredItems.Clear();
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			return;
		}
		QuickPresetData quickPresetData = QuickbarData.Presets[selectedPreset];
		System.Collections.Generic.HashSet<int> hashSet = new System.Collections.Generic.HashSet<int>();
		foreach (ClothSlotID value in Enum.GetValues(typeof(ClothSlotID)))
		{
			if (value != (ClothSlotID)activeSelectionSlot)
			{
				int instanceID = quickPresetData.GetInstanceID(value);
				if (instanceID != -1)
				{
					hashSet.Add(instanceID);
				}
			}
		}
		foreach (var current in inventoryComponent.m_Items)
		{
			GearItem val = ((current != null) ? current.m_GearItem : null);
			if ((UnityEngine.Object)(object)((val != null) ? val.m_ClothingItem : null) != (UnityEngine.Object)null && QuickClothData.IsValidForSlot(val, slotID) && !hashSet.Contains(val.m_InstanceID))
			{
				presetFilteredItems.Add(val);
			}
		}
	}

	private static void DrawConfirmWindow(int id)
	{
		SkillConfirmWindow.Draw(id, isApplyMode: false, null, null, delegate
		{
			ApplyChanges();
			IsOpen = false;
			onConfirmClose?.Invoke();
			onConfirmClose = null;
		}, delegate
		{
			QuickbarData.RevertAll();
			isDirty = false;
			showConfirmWindow = false;
			IsOpen = false;
			onConfirmClose?.Invoke();
			onConfirmClose = null;
		});
	}
}
