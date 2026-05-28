using System;
using Il2Cpp;
using Il2CppTLD.Gear;
using UnityEngine;

namespace RPGSkillsEvo;

public static class SkillsUI
{
	private enum ConfirmPurpose
	{
		Apply,
		CloseProtection
	}

	public static bool IsOpen;

	private static bool isDirty;

	private static bool showConfirmWindow;

	private static ConfirmPurpose currentPurpose;

	private static Action onConfirmClose;

	private const int RESET_COST = 50;

	private const string STICK_GEAR_NAME = "GEAR_Stick";

	public static void OpenMenuOnly()
	{
		ResetInternalState();
		IsOpen = true;
	}

	public static void ResetInternalState()
	{
		isDirty = false;
		showConfirmWindow = false;
		onConfirmClose = null;
		SkillNodeRenderer.ResetDirty();
		SkillNodeRenderer.ResetCancel();
		TooltipManager.Hide();
	}

	public static void TryCloseMenu(Action onCloseAction = null)
	{
		if (!showConfirmWindow && !SkillNodeRenderer.ShowCancelConfirm)
		{
			if (isDirty)
			{
				onConfirmClose = onCloseAction;
				currentPurpose = ConfirmPurpose.CloseProtection;
				showConfirmWindow = true;
			}
			else
			{
				IsOpen = false;
				onCloseAction?.Invoke();
			}
		}
	}

	private static void ApplyChanges()
	{
		NodeManager.PushToHub();
		WeightManager.UpdateFromEvo();
		isDirty = false;
		showConfirmWindow = false;
		SkillNodeRenderer.ResetDirty();
	}

	private static bool TryResetAllNodes()
	{
		Inventory inventoryComponent = GameManager.GetInventoryComponent();
		if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < inventoryComponent.m_Items.Count; i++)
		{
			GearItemObject val = inventoryComponent.m_Items[i];
			if (val != null && (UnityEngine.Object)(object)val.m_GearItem != (UnityEngine.Object)null && ((UnityEngine.Object)val.m_GearItem).name.Contains("GEAR_Stick"))
			{
				num = (((UnityEngine.Object)(object)val.m_GearItem.m_StackableItem == (UnityEngine.Object)null) ? (num + 1) : (num + val.m_GearItem.m_StackableItem.m_Units));
			}
		}
		if (num < 50)
		{
			return false;
		}
		int num2 = 50;
		for (int num3 = inventoryComponent.m_Items.Count - 1; num3 >= 0; num3--)
		{
			GearItemObject val2 = inventoryComponent.m_Items[num3];
			if (val2 != null && (UnityEngine.Object)(object)val2.m_GearItem != (UnityEngine.Object)null && ((UnityEngine.Object)val2.m_GearItem).name.Contains("GEAR_Stick"))
			{
				GearItem gearItem = val2.m_GearItem;
				StackableItem stackableItem = gearItem.m_StackableItem;
				if ((UnityEngine.Object)(object)stackableItem == (UnityEngine.Object)null || stackableItem.m_Units <= num2)
				{
					int num4 = (((UnityEngine.Object)(object)stackableItem == (UnityEngine.Object)null) ? 1 : stackableItem.m_Units);
					num2 -= num4;
					inventoryComponent.DestroyGear(((Component)gearItem).gameObject);
				}
				else
				{
					stackableItem.m_Units -= num2;
					num2 = 0;
				}
			}
			if (num2 <= 0)
			{
				break;
			}
		}
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			int level = NodeManager.GetLevel(allNode.ID);
			if (level > 0)
			{
				NodeManager.tPoints += level * allNode.Cost;
				NodeManager.tNodes[allNode.ID] = 0;
			}
		}
		foreach (SkillNode allNode2 in NodeDatabase.AllNodes)
		{
			int confirmedLevel = NodeManager.GetConfirmedLevel(allNode2.ID);
			if (confirmedLevel > 0)
			{
				PlayerLevel.SkillPoints += confirmedLevel * allNode2.Cost;
				DataHub.RealNodes[allNode2.ID] = 0;
			}
		}
		NodeManager.SyncFromHub();
		Status.RefreshCache();
		MaxConditionManager.ResetBase();
		WeightManager.UpdateFromEvo();
		isDirty = false;
		SkillNodeRenderer.ResetDirty();
		SkillNodeRenderer.ResetCancel();
		TooltipManager.Hide();
		return true;
	}

	public static void OnGUI()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		if (!IsOpen)
		{
			return;
		}
		if (SkillNodeRenderer.IsDirty)
		{
			isDirty = true;
		}
		UILayout.HandlePan();
		UILayout.HandleZoom();
		Vector2 mousePosition = Event.current.mousePosition;
		Rect nodeAreaRect = UILayout.NodeAreaRect;
		Vector2 val = mousePosition - new Vector2(nodeAreaRect.x + UILayout.windowRect.x, nodeAreaRect.y + UILayout.windowRect.y);
		SkillNode skillNode = null;
		Rect val2 = default(Rect);
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			if (NodeManager.IsVisible(allNode))
			{
				float zoomLevel = UILayout.ZoomLevel;
				float num = nodeAreaRect.width / 2f;
				float num2 = nodeAreaRect.height / 2f;
				float num3 = num + UILayout.PanOffset.x + (float)allNode.GridX * DrawingUtils.Spacing * zoomLevel;
				float num4 = num2 + UILayout.PanOffset.y + (float)allNode.GridY * DrawingUtils.Spacing * zoomLevel;
				float num5 = DrawingUtils.NodeSize * zoomLevel;
				val2 = new Rect(num3 - num5 / 2f, num4 - num5 / 2f, num5, num5);
				if (val2.Contains(val))
				{
					skillNode = allNode;
					break;
				}
			}
		}
		if (skillNode != null)
		{
			float zoomLevel2 = UILayout.ZoomLevel;
			float num6 = nodeAreaRect.width / 2f;
			float num7 = nodeAreaRect.height / 2f;
			float num8 = num6 + UILayout.PanOffset.x + (float)skillNode.GridX * DrawingUtils.Spacing * zoomLevel2;
			float num9 = num7 + UILayout.PanOffset.y + (float)skillNode.GridY * DrawingUtils.Spacing * zoomLevel2;
			float num10 = DrawingUtils.NodeSize * zoomLevel2;
			Rect worldNodeRect = new Rect(UILayout.windowRect.x + nodeAreaRect.x + num8 - num10 / 2f, UILayout.windowRect.y + nodeAreaRect.y + num9 - num10 / 2f, num10, num10);
			TooltipManager.ShowForNode(skillNode, NodeManager.GetLevel(skillNode.ID), worldNodeRect);
		}
		else
		{
			TooltipManager.Hide();
		}
		GUI.depth = 10;
		UILayout.windowRect = GUI.Window(10, UILayout.windowRect, (Action<int>)DrawSkillWindow, "");
		if (TooltipManager.showTooltip)
		{
			GUI.depth = 5;
			TooltipManager.tooltipWindowRect = GUI.Window(12, TooltipManager.tooltipWindowRect, (Action<int>)TooltipManager.DrawTooltipWindow, "");
			GUI.BringWindowToFront(12);
		}
		if (SkillNodeRenderer.ShowCancelConfirm)
		{
			GUI.depth = 0;
			Rect val3 = new Rect(UILayout.windowRect.x + UILayout.windowRect.width / 2f - 200f, UILayout.windowRect.y + UILayout.windowRect.height / 2f - 90f, 400f, 180f);
			val3 = GUI.Window(13, val3, (Action<int>)SkillNodeRenderer.DrawCancelConfirmWindow, "");
			GUI.BringWindowToFront(13);
		}
		if (showConfirmWindow)
		{
			GUI.depth = 0;
			UILayout.confirmRect = GUI.Window(11, UILayout.confirmRect, (Action<int>)DrawConfirmWindowWrapper, "SYSTEM");
			GUI.BringWindowToFront(11);
		}
	}

	private static void DrawSkillWindow(int id)
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
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
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
		GUI.Label(new Rect(0f, 5f, 1000f, 40f), Loc.Get("RPG.UI.SKILL_AWAKENING"), val2);
		string text = Loc.Get("RPG.UI.RCLICK_HINT");
		GUIStyle val3 = new GUIStyle
		{
			alignment = (TextAnchor)5,
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = new Color(0f, 0f, 0f, 0.8f);
		GUIStyle val4 = val3;
		GUIStyle val5 = new GUIStyle
		{
			alignment = (TextAnchor)5,
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val5.normal.textColor = new Color(1f, 0.95f, 0.4f, 1f);
		GUIStyle val6 = val5;
		GUI.Label(new Rect(451f, 6f, 490f, 20f), text, val4);
		GUI.Label(new Rect(450f, 5f, 490f, 20f), text, val6);
		if (GUI.Button(new Rect(950f, 10f, 40f, 40f), "X"))
		{
			TryCloseMenu(delegate
			{
				IsOpen = false;
			});
		}
		Rect val7 = new Rect(50f, 45f, 400f, 40f);
		string text3 = Loc.Get("RPG.UI.AVAILABLE_POINTS", NodeManager.tPoints);
		GUIStyle val8 = new GUIStyle
		{
			fontSize = 20,
			fontStyle = (FontStyle)1
		};
		val8.normal.textColor = Color.yellow;
		GUI.Label(val7, text3, val8);
		DrawingUtils.DrawRectOutline(new Rect(20f, 44f, 960f, 1f), new Color(0.4f, 0.4f, 0.4f, 1f), 1f);
		Rect nodeAreaRect = UILayout.NodeAreaRect;
		GUI.color = new Color(0.12f, 0.12f, 0.12f, 1f);
		GUI.DrawTexture(nodeAreaRect, (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		GUI.Box(nodeAreaRect, "");
		GUIStyle val9 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val9.normal.textColor = Color.white;
		GUIStyle val10 = val9;
		if (GUI.Button(new Rect(nodeAreaRect.xMax - 110f, nodeAreaRect.y + 10f, 100f, 30f), Loc.Get("RPG.UI.BTN_BACK"), val10))
		{
			TryCloseMenu(delegate
			{
				IsOpen = false;
			});
		}
		if (GUI.Button(new Rect(445f, nodeAreaRect.y + 10f, 110f, 25f), Loc.Get("RPG.UI.BTN_MOVE_CORE"), val10))
		{
			UILayout.ResetView();
		}
		if (!showConfirmWindow && !SkillNodeRenderer.ShowCancelConfirm)
		{
			GUIStyle val11 = new GUIStyle(GUI.skin.button)
			{
				fontSize = 10,
				fontStyle = (FontStyle)1,
				wordWrap = true
			};
			val11.normal.textColor = Color.white;
			GUIStyle val12 = val11;
			GUI.color = new Color(1f, 0.3f, 0.3f, 1f);
			if (GUI.Button(new Rect(nodeAreaRect.x + 10f, nodeAreaRect.y + 10f, 120f, 30f), Loc.Get("RPG.UI.BTN_RESET", 50), val12))
			{
				TryResetAllNodes();
			}
			GUI.color = Color.white;
		}
		GUI.BeginGroup(nodeAreaRect);
		float zoomLevel = UILayout.ZoomLevel;
		float sz = DrawingUtils.NodeSize * zoomLevel;
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			if (!string.IsNullOrEmpty(allNode.RequiredNodeID))
			{
				DrawingUtils.DrawConnection(allNode);
			}
		}
		foreach (SkillNode allNode2 in NodeDatabase.AllNodes)
		{
			if (NodeManager.IsVisible(allNode2))
			{
				SkillNodeRenderer.DrawNode(allNode2, zoomLevel, sz);
			}
		}
		GUI.EndGroup();
		if (isDirty && !showConfirmWindow && !SkillNodeRenderer.ShowCancelConfirm)
		{
			GUI.color = Color.green;
			if (GUI.Button(new Rect(780f, 710f, 200f, 70f), Loc.Get("RPG.UI.BTN_APPLY_CHANGES")))
			{
				currentPurpose = ConfirmPurpose.Apply;
				showConfirmWindow = true;
			}
			GUI.color = Color.white;
		}
	}

	private static void DrawConfirmWindowWrapper(int id)
	{
		SkillConfirmWindow.Draw(id, currentPurpose == ConfirmPurpose.Apply, delegate
		{
			ApplyChanges();
		}, delegate
		{
			showConfirmWindow = false;
		}, delegate
		{
			ApplyChanges();
			onConfirmClose?.Invoke();
			ResetInternalState();
		}, delegate
		{
			NodeManager.SyncFromHub();
			onConfirmClose?.Invoke();
			ResetInternalState();
		});
	}
}
