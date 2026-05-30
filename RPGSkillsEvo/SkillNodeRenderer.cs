using UnityEngine;

namespace RPGSkillsEvo;

public static class SkillNodeRenderer
{
	public static bool ShowCancelConfirm;

	private static SkillNode cancelTargetNode;

	public static bool IsDirty { get; private set; }

	public static void ResetDirty()
	{
		IsDirty = false;
	}

	public static void ResetCancel()
	{
		ShowCancelConfirm = false;
		cancelTargetNode = null;
	}

	private static Color GetNodeColor(SkillNode node, bool active)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		if (!active)
		{
			return new Color(0.15f, 0.15f, 0.15f, 0.6f);
		}
		if (node.ID == "CORE")
		{
			return Color.white;
		}
		if (node.ID.StartsWith("WS"))
		{
			return new Color(0.65f, 0.3f, 0.9f, 1f);
		}
		if (node.ID.StartsWith("W"))
		{
			return new Color(0.85f, 0.25f, 0.25f, 1f);
		}
		if (node.ID.StartsWith("ES"))
		{
			return new Color(0f, 0.2f, 1f, 1f);
		}
		if (node.ID.StartsWith("E"))
		{
			return new Color(0.3f, 0.75f, 1f, 1f);
		}
		if (node.ID.StartsWith("S"))
		{
			return new Color(0.4f, 0.9f, 0.4f, 1f);
		}
		if (node.ID.StartsWith("N"))
		{
			return new Color(1f, 0.7f, 0.1f, 1f);
		}
		return new Color(1f, 0.7f, 0.1f, 1f);
	}

	public static void DrawRainbowRect(Rect r)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		Color[] array = (Color[])(object)new Color[6]
		{
			new Color(1f, 0.6f, 0.6f, 0.85f),
			new Color(1f, 0.8f, 0.5f, 0.85f),
			new Color(1f, 1f, 0.6f, 0.85f),
			new Color(0.6f, 1f, 0.6f, 0.85f),
			new Color(0.5f, 0.8f, 1f, 0.85f),
			new Color(0.8f, 0.6f, 1f, 0.85f)
		};
		int num = array.Length;
		float num2 = r.width / (float)num;
		for (int i = 0; i < num; i++)
		{
			Color val = array[i];
			Color val2 = array[(i + 1) % num];
			int num3 = 4;
			float num4 = num2 / (float)num3;
			for (int j = 0; j < num3; j++)
			{
				float num5 = (float)j / (float)num3;
				Color color = Color.Lerp(val, val2, num5);
				GUI.color = color;
				GUI.DrawTexture(new Rect(r.x + (float)i * num2 + (float)j * num4, r.y, num4 + 1f, r.height), (Texture)(object)Texture2D.whiteTexture);
			}
		}
		GUI.color = Color.white;
	}

	public static void DrawNode(SkillNode node, float zoom, float sz)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		Vector2 canvasPos = DrawingUtils.GetCanvasPos(node.GridX, node.GridY);
		Rect val = new Rect((float)(int)(canvasPos.x - sz / 2f), (float)(int)(canvasPos.y - sz / 2f), (float)(int)sz, (float)(int)sz);
		int level = NodeManager.GetLevel(node.ID);
		bool flag = level > 0;
		bool flag2 = val.Contains(Event.current.mousePosition);
		if ((int)Event.current.type == 0 && Event.current.button == 1 && flag2)
		{
			if (NodeManager.CanCancel(node))
			{
				cancelTargetNode = node;
				ShowCancelConfirm = true;
			}
			Event.current.Use();
		}
		Rect val2 = (Rect)(flag2 ? new Rect(val.x - 2f, val.y - 2f, val.width, val.height) : val);
		if (node.ID == "CORE" && flag)
		{
			DrawingUtils.Draw3DBox(val2, new Color(0.1f, 0.1f, 0.1f, 1f), zoom, flag, flag2);
			DrawRainbowRect(new Rect(val2.x + 2f, val2.y + 2f, val2.width - 4f, val2.height - 4f));
		}
		else
		{
			DrawingUtils.Draw3DBox(val2, GetNodeColor(node, flag), zoom, flag, flag2);
		}
		bool skipDots = node.MaxLevel >= 999;
		DrawingUtils.DrawLevelDots(val2, level, node.MaxLevel, zoom, skipDots);
		if (GUI.Button(val2, "", GUIStyle.none) && Event.current.button == 0)
		{
			int num = level;
			NodeManager.Invest(node);
			if (NodeManager.GetLevel(node.ID) > num)
			{
				IsDirty = true;
				TooltipManager.UpdateLevel(NodeManager.GetLevel(node.ID));
			}
		}
		Texture2D icon = IconManager.GetIcon(node.IconID);
		if ((UnityEngine.Object)(object)icon != (UnityEngine.Object)null)
		{
			GUI.color = (Color)(flag ? Color.white : new Color(0.4f, 0.4f, 0.4f, 0.5f));
			float num2 = (int)(sz * 0.85f);
			Rect val3 = new Rect((float)(int)(val2.x + (sz - num2) / 2f), (float)(int)(val2.y + (sz - num2) / 2f - 2f * zoom), (float)(int)num2, (float)(int)num2);
			GUI.DrawTexture(val3, (Texture)(object)icon, (ScaleMode)2, true);
			GUI.color = Color.white;
		}
		GUIStyle val4 = new GUIStyle
		{
			alignment = (TextAnchor)7,
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val4.normal.textColor = (Color)(flag ? Color.black : new Color(0.7f, 0.7f, 0.7f, 1f));
		GUIStyle val5 = val4;
		GUI.Label(val2, string.Format("[{0} / {1}]", level, (node.MaxLevel >= 999) ? "∞" : node.MaxLevel.ToString()), val5);
	}

	public static void DrawCancelConfirmWindow(int id)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		if (cancelTargetNode != null)
		{
			DrawingUtils.Draw3DBox(new Rect(0f, 0f, 400f, 180f), new Color(0.1f, 0.1f, 0.1f, 1f), 1f, isActive: false, isHovered: false);
			GUIStyle val = new GUIStyle
			{
				alignment = (TextAnchor)4,
				fontSize = 15,
				fontStyle = (FontStyle)1
			};
			val.normal.textColor = Color.cyan;
			GUIStyle val2 = val;
			GUIStyle val3 = new GUIStyle
			{
				alignment = (TextAnchor)4,
				fontSize = 13,
				wordWrap = true
			};
			val3.normal.textColor = Color.white;
			GUIStyle val4 = val3;
			GUI.Label(new Rect(10f, 15f, 380f, 25f), cancelTargetNode.GetLocalizedName(), val2);
			GUI.Label(new Rect(10f, 45f, 380f, 60f), Loc.Get("RPG.CONFIRM.CANCEL_BODY"), val4);
			if (GUI.Button(new Rect(30f, 125f, 160f, 40f), Loc.Get("RPG.CONFIRM.OK")))
			{
				NodeManager.CancelNode(cancelTargetNode);
				IsDirty = true;
				ShowCancelConfirm = false;
				cancelTargetNode = null;
			}
			if (GUI.Button(new Rect(210f, 125f, 160f, 40f), Loc.Get("RPG.CONFIRM.CANCEL")))
			{
				ShowCancelConfirm = false;
				cancelTargetNode = null;
			}
		}
	}
}
