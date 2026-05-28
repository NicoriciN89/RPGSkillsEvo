using System;
using UnityEngine;

namespace RPGSkillsEvo;

public static class InterfaceUI
{
	private enum SubMenu
	{
		None,
		Skills
	}

	public static bool IsOpen;

	private static SubMenu currentSub;

	public static void OpenMenu()
	{
		IsOpen = true;
		currentSub = SubMenu.None;
		NodeManager.SyncFromHub();
	}

	public static void CloseMenu()
	{
		if (currentSub == SubMenu.Skills)
		{
			SkillsUI.TryCloseMenu(delegate
			{
				currentSub = SubMenu.None;
				TryCloseAutoLoot(delegate
				{
					TryCloseQuickbar(delegate
					{
						CompleteClose();
					});
				});
			});
			return;
		}
		TryCloseAutoLoot(delegate
		{
			TryCloseQuickbar(delegate
			{
				CompleteClose();
			});
		});
	}

	public static void ForceClose()
	{
		IsOpen = false;
		currentSub = SubMenu.None;
		Cursor.visible = false;
		Main.isWaitingForKey = false;
	}

	private static void TryCloseAutoLoot(Action onDone)
	{
		if (AutoLootUI.IsOpen)
		{
			AutoLootUI.TryCloseMenu(delegate
			{
				onDone?.Invoke();
			});
		}
		else
		{
			onDone?.Invoke();
		}
	}

	private static void TryCloseQuickbar(Action onDone)
	{
		if (QuickbarUI.IsOpen)
		{
			QuickbarUI.TryCloseMenu(delegate
			{
				onDone?.Invoke();
			});
		}
		else
		{
			onDone?.Invoke();
		}
	}

	private static void CompleteClose()
	{
		IsOpen = false;
		currentSub = SubMenu.None;
		Cursor.visible = false;
		TooltipManager.Hide();
		Main.isWaitingForKey = false;
		SkillsUI.ResetInternalState();
		AutoLootUI.CloseMenu();
		QuickbarUI.CloseMenu();
	}

	public static void OnGUI()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			return;
		}
		Cursor.visible = true;
		Cursor.lockState = (CursorLockMode)0;
		if (Main.isWaitingForKey)
		{
			Event current = Event.current;
			if (current != null && current.isKey && (int)current.keyCode != 0 && (int)current.keyCode != 27)
			{
				DataHub.MenuHotkey = current.keyCode;
				Main.isWaitingForKey = false;
			}
			else if (current != null && current.isKey && (int)current.keyCode == 27)
			{
				Main.isWaitingForKey = false;
			}
		}
		UILayout.windowRect = GUI.Window(0, UILayout.windowRect, (Action<int>)DrawMainHub, "");
		if (currentSub == SubMenu.Skills)
		{
			SkillsUI.OnGUI();
		}
		AutoLootUI.OnGUI();
		QuickbarUI.OnGUI();
	}

	private static void DrawMainHub(int id)
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
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
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
		GUI.Label(new Rect(0f, 5f, 1000f, 40f), Loc.Get("RPG.UI.PLAYER_INTERFACE"), val2);
		if (GUI.Button(new Rect(950f, 10f, 40f, 40f), "X"))
		{
			CloseMenu();
		}
		DrawingUtils.DrawRectOutline(new Rect(20f, 44f, 960f, 1f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		DrawingUtils.DrawRectOutline(new Rect(340f, 45f, 1f, 740f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		if (GUI.Button(new Rect(850f, 45f, 110f, 30f), Main.isWaitingForKey ? "WAITING..." : $"HOTKEY: {DataHub.MenuHotkey}", val4))
		{
			Main.isWaitingForKey = !Main.isWaitingForKey;
		}
		HubStatsUI.Draw();
		HubButtonsUI.Draw(delegate
		{
			currentSub = SubMenu.Skills;
			SkillsUI.OpenMenuOnly();
		}, delegate
		{
			AutoLootUI.OpenMenu();
		}, delegate
		{
			QuickbarUI.OpenMenu();
		});
	}
}
