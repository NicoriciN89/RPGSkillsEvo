using System;
using UnityEngine;

namespace RPGSkillsEvo;

public static class AutoLootUI
{
	public static bool IsOpen = false;

	private static Rect windowRect = new Rect((float)(Screen.width / 2 - 500), (float)(Screen.height / 2 - 400), 1000f, 800f);

	private static Rect confirmRect = new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 100), 400f, 200f);

	private static int activeSlotIndex = -1;

	private static int activeItemSlotIndex = -1;

	private static bool isScanDropdownOpen = false;

	private static bool isWaitingForHotkey = false;

	private static bool isDirty = false;

	private static bool showConfirmWindow = false;

	private static Action onConfirmClose;

	private static Vector2 scrollPos = Vector2.zero;

	private static readonly float[] scanIntervals = new float[10] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f };

	public static void OpenMenu()
	{
		IsOpen = true;
		isDirty = false;
		showConfirmWindow = false;
		isWaitingForHotkey = false;
		isScanDropdownOpen = false;
		activeSlotIndex = -1;
		activeItemSlotIndex = -1;
		AutoLootSlotUI.Init();
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
		isWaitingForHotkey = false;
		isScanDropdownOpen = false;
		activeSlotIndex = -1;
		activeItemSlotIndex = -1;
		onConfirmClose = null;
	}

	private static void ApplyChanges()
	{
		AutoLootData.ConfirmSlots();
		isDirty = false;
		showConfirmWindow = false;
	}

	private static void MarkDirty()
	{
		isDirty = true;
	}

	public static void OnGUI()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		if (!IsOpen)
		{
			return;
		}
		if (isWaitingForHotkey)
		{
			Event current = Event.current;
			if (current != null && current.isKey && (int)current.keyCode != 0 && (int)current.keyCode != 27)
			{
				AutoLootManager.ToggleHotkey = current.keyCode;
				isWaitingForHotkey = false;
			}
			else if (current != null && current.isKey && (int)current.keyCode == 27)
			{
				isWaitingForHotkey = false;
			}
		}
		bool flag = activeSlotIndex >= 0 || activeItemSlotIndex >= 0 || isScanDropdownOpen;
		GUI.depth = (flag ? 3 : 4);
		windowRect = GUI.Window(20, windowRect, (Action<int>)DrawWindow, "");
		if (flag)
		{
			GUI.depth = 2;
			GUI.Window(21, new Rect(windowRect.x, windowRect.y, windowRect.width, windowRect.height), (Action<int>)DrawDropdownOverlay, "");
			GUI.BringWindowToFront(21);
		}
		if (showConfirmWindow)
		{
			GUI.depth = 0;
			confirmRect = GUI.Window(22, confirmRect, (Action<int>)DrawConfirmWindowWrapper, "SYSTEM");
			GUI.BringWindowToFront(22);
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
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		GUI.color = new Color(0.02f, 0.02f, 0.02f, 1f);
		GUI.DrawTexture(new Rect(0f, 0f, 1000f, 800f), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(new Rect(2f, 2f, 996f, 796f), new Color(0.6f, 0.6f, 0.6f, 1f), 1f);
		DrawingUtils.DrawRectOutline(new Rect(0f, 0f, 1000f, 800f), new Color(0.25f, 0.25f, 0.25f, 1f), 2f);
		GUIStyle val = new GUIStyle
		{
			alignment = (TextAnchor)4,
			fontSize = 22,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.white;
		GUIStyle val2 = val;
		GUI.Label(new Rect(0f, 5f, 1000f, 40f), Loc.Get("RPG.UI.AUTO_LOOT_SETTINGS"), val2);
		DrawingUtils.DrawRectOutline(new Rect(20f, 44f, 960f, 1f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		if (GUI.Button(new Rect(950f, 8f, 40f, 30f), "X"))
		{
			TryCloseMenu(delegate
			{
				IsOpen = false;
			});
		}
		GUI.color = (Color)(AutoLootManager.IsEnabled ? Color.green : new Color(0.5f, 0.5f, 0.5f, 1f));
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		if (GUI.Button(new Rect(20f, 55f, 200f, 35f), AutoLootManager.IsEnabled ? Loc.Get("RPG.UI.AL_ON") : Loc.Get("RPG.UI.AL_OFF"), val4))
		{
			AutoLootManager.IsEnabled = !AutoLootManager.IsEnabled;
		}
		GUI.color = Color.white;
		GUIStyle val5 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val5.normal.textColor = Color.white;
		GUIStyle val6 = val5;
		if (GUI.Button(new Rect(230f, 55f, 200f, 35f), isWaitingForHotkey ? Loc.Get("RPG.UI.AL_WAITING") : Loc.Get("RPG.UI.AL_HOTKEY", AutoLootManager.ToggleHotkey), val6))
		{
			isWaitingForHotkey = !isWaitingForHotkey;
		}
		GUIStyle val7 = new GUIStyle
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val7.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
		val7.alignment = (TextAnchor)3;
		GUIStyle val8 = val7;
		GUI.Label(new Rect(440f, 55f, 220f, 35f), Loc.Get("RPG.UI.AL_ACTIVE_SLOTS", AutoLootData.GetActiveSlotCount(), 15), val8);
		GUIStyle val9 = new GUIStyle
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val9.normal.textColor = new Color(0.4f, 0.8f, 1f, 1f);
		val9.alignment = (TextAnchor)3;
		GUIStyle val10 = val9;
		GUI.Label(new Rect(670f, 55f, 120f, 35f), Loc.Get("RPG.UI.AL_RADIUS", AutoLootData.GetActiveLootRadius()), val10);
		GUIStyle val11 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val11.normal.textColor = Color.white;
		GUIStyle val12 = val11;
		bool showApply = isDirty && !showConfirmWindow;
		if (GUI.Button(new Rect(showApply ? 760f : 800f, 55f, showApply ? 120f : 180f, 35f), Loc.Get("RPG.UI.AL_SCAN", AutoLootManager.ScanInterval), val12))
		{
			isScanDropdownOpen = !isScanDropdownOpen;
			activeSlotIndex = -1;
			activeItemSlotIndex = -1;
		}
		if (showApply)
		{
			GUI.color = Color.green;
			if (GUI.Button(new Rect(885f, 55f, 95f, 35f), Loc.Get("RPG.UI.BTN_APPLY")))
			{
				ApplyChanges();
			}
			GUI.color = Color.white;
		}
		DrawingUtils.DrawRectOutline(new Rect(20f, 98f, 960f, 1f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		GUIStyle val13 = new GUIStyle
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val13.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
		val13.alignment = (TextAnchor)4;
		GUIStyle val14 = val13;
		GUI.Label(new Rect(20f, 104f, 50f, 28f), Loc.Get("RPG.UI.AL_SLOT"), val14);
		GUI.Label(new Rect(80f, 104f, 250f, 28f), Loc.Get("RPG.UI.AL_CATEGORY"), val14);
		GUI.Label(new Rect(340f, 104f, 380f, 28f), Loc.Get("RPG.UI.AL_ITEM"), val14);
		GUI.Label(new Rect(730f, 104f, 100f, 28f), Loc.Get("RPG.UI.AL_STATUS"), val14);
		DrawingUtils.DrawRectOutline(new Rect(20f, 132f, 960f, 1f), new Color(0.3f, 0.3f, 0.3f, 1f), 1f);
		int activeSlotCount = AutoLootData.GetActiveSlotCount();
		float num = (float)activeSlotCount * 70f;
		Rect val15 = new Rect(20f, 136f, 960f, 648f);
		Rect val16 = new Rect(0f, 0f, 940f, num);
		scrollPos = GUI.BeginScrollView(val15, scrollPos, val16, false, activeSlotCount > 9);
		for (int num2 = 0; num2 < activeSlotCount; num2++)
		{
			AutoLootSlotUI.DrawSlot(num2, activeSlotIndex, activeItemSlotIndex, delegate(int idx)
			{
				if (activeSlotIndex == idx)
				{
					activeSlotIndex = -1;
				}
				else
				{
					activeSlotIndex = idx;
					activeItemSlotIndex = -1;
					isScanDropdownOpen = false;
				}
			}, delegate(int idx)
			{
				if (activeItemSlotIndex == idx)
				{
					activeItemSlotIndex = -1;
				}
				else
				{
					activeItemSlotIndex = idx;
					activeSlotIndex = -1;
					isScanDropdownOpen = false;
				}
			}, delegate(int idx)
			{
				AutoLootData.Slots[idx].IsOn = !AutoLootData.Slots[idx].IsOn;
				MarkDirty();
			}, delegate(int idx)
			{
				AutoLootData.SlotData slotData = AutoLootData.Slots[idx];
				if (!string.IsNullOrEmpty(slotData.CategoryKey) || !string.IsNullOrEmpty(slotData.ItemKey) || slotData.IsOn)
				{
					MarkDirty();
				}
				slotData.CategoryKey = "";
				slotData.ItemKey = "";
				slotData.IsOn = false;
				if (activeSlotIndex == idx)
				{
					activeSlotIndex = -1;
				}
				if (activeItemSlotIndex == idx)
				{
					activeItemSlotIndex = -1;
				}
			});
		}
		GUI.EndScrollView();
	}

	private static void DrawDropdownOverlay(int id)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		GUI.color = new Color(0f, 0f, 0f, 0f);
		GUI.DrawTexture(new Rect(0f, 0f, 1000f, 800f), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		if (isScanDropdownOpen)
		{
			float num = (float)scanIntervals.Length * 32f;
			GUI.color = new Color(0.1f, 0.1f, 0.1f, 1f);
			GUI.DrawTexture(new Rect(800f, 92f, 180f, num), (Texture)(object)Texture2D.whiteTexture);
			GUI.color = Color.white;
			DrawingUtils.DrawRectOutline(new Rect(800f, 92f, 180f, num), new Color(0.5f, 0.5f, 0.5f, 1f), 1f);
			GUIStyle val = new GUIStyle(GUI.skin.button)
			{
				fontSize = 13
			};
			val.normal.textColor = Color.white;
			val.alignment = (TextAnchor)4;
			GUIStyle val2 = val;
			for (int i = 0; i < scanIntervals.Length; i++)
			{
				GUI.color = ((Math.Abs(AutoLootManager.ScanInterval - scanIntervals[i]) < 0.01f) ? Color.yellow : Color.white);
				if (GUI.Button(new Rect(802f, (float)(92 + i * 32), 176f, 30f), Loc.Get("RPG.UI.AL_SCAN", scanIntervals[i]), val2))
				{
					AutoLootManager.ScanInterval = scanIntervals[i];
					isScanDropdownOpen = false;
				}
				GUI.color = Color.white;
			}
			return;
		}
		if (activeSlotIndex >= 0)
		{
			AutoLootSlotUI.DrawCategoryDropdown(activeSlotIndex, activeSlotIndex, scrollPos.y, delegate(int idx, string cat)
			{
				AutoLootData.SlotData slotData = AutoLootData.Slots[idx];
				if (slotData.CategoryKey != cat)
				{
					MarkDirty();
				}
				slotData.CategoryKey = cat;
				slotData.ItemKey = "";
				slotData.IsOn = false;
				activeSlotIndex = -1;
			});
		}
		if (activeItemSlotIndex < 0)
		{
			return;
		}
		AutoLootSlotUI.DrawItemDropdown(activeItemSlotIndex, scrollPos.y, delegate(int idx, string item)
		{
			AutoLootData.SlotData slotData = AutoLootData.Slots[idx];
			if (slotData.ItemKey != item)
			{
				MarkDirty();
			}
			slotData.ItemKey = item;
			activeItemSlotIndex = -1;
		});
	}

	private static void DrawConfirmWindowWrapper(int id)
	{
		SkillConfirmWindow.Draw(id, isApplyMode: false, null, null, delegate
		{
			ApplyChanges();
			IsOpen = false;
			onConfirmClose?.Invoke();
			onConfirmClose = null;
		}, delegate
		{
			AutoLootData.RevertSlots();
			isDirty = false;
			showConfirmWindow = false;
			IsOpen = false;
			onConfirmClose?.Invoke();
			onConfirmClose = null;
		});
	}
}
