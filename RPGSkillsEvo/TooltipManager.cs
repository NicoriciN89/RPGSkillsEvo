using UnityEngine;

namespace RPGSkillsEvo;

public static class TooltipManager
{
	public static bool showTooltip = false;

	private static SkillNode currentNode;

	private static int currentLvl;

	public static Rect tooltipWindowRect = new Rect(0f, 0f, 310f, 260f);

	public static void ShowForNode(SkillNode node, int lvl, Rect worldNodeRect)
	{
		currentNode = node;
		currentLvl = lvl;
		showTooltip = true;
		float num = worldNodeRect.xMax + 15f;
		float num2 = worldNodeRect.y;
		if (num + tooltipWindowRect.width > (float)Screen.width)
		{
			num = worldNodeRect.x - tooltipWindowRect.width - 15f;
		}
		if (num2 + tooltipWindowRect.height > (float)Screen.height)
		{
			num2 = (float)Screen.height - tooltipWindowRect.height - 20f;
		}
		if (num2 < 20f)
		{
			num2 = 20f;
		}
		tooltipWindowRect.x = num;
		tooltipWindowRect.y = num2;
	}

	public static void Hide()
	{
		showTooltip = false;
		currentNode = null;
	}

	public static bool IsCurrentNode(string id)
	{
		return showTooltip && currentNode != null && currentNode.ID == id;
	}

	public static void UpdateLevel(int newLvl)
	{
		currentLvl = newLvl;
	}

	private static float CalcHeight(GUIStyle style, string text, float width)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		return style.CalcHeight(new GUIContent(text), width);
	}

	private static void DrawSeparator(float x, float y, float width)
	{
		Color old = GUI.color;
		GUI.color = new Color(0.4f, 0.45f, 0.55f, 0.5f);
		GUI.DrawTexture(new Rect(x, y + 1f, width, 1f), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = old;
	}

	public static void DrawTooltipWindow(int id)
	{
		if (currentNode == null) return;
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Expected O, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected O, but got Unknown
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected O, but got Unknown
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_076f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		if (currentNode != null)
		{
			float width = tooltipWindowRect.width;
			float h = tooltipWindowRect.height;
			float cw = width - 24f;
			float x = 12f;

			// background + border
			GUI.color = new Color(0.05f, 0.05f, 0.05f, 1f);
			GUI.DrawTexture(new Rect(0f, 0f, width, h), (Texture)(object)Texture2D.whiteTexture);
			GUI.color = Color.white;
			DrawingUtils.DrawRectOutline(new Rect(0f, 0f, width, h), new Color(0.15f, 0.15f, 0.18f, 1f), 3f);
			DrawingUtils.DrawRectOutline(new Rect(3f, 3f, width - 6f, h - 6f), new Color(0.75f, 0.8f, 0.88f, 1f), 2f);
			DrawingUtils.DrawRectOutline(new Rect(5f, 5f, width - 10f, h - 10f), new Color(0.55f, 0.62f, 0.72f, 1f), 1f);

			// styles
			GUIStyle titleSt = new GUIStyle { fontSize = 18, fontStyle = (FontStyle)1, wordWrap = true };
			titleSt.normal.textColor = Color.cyan;
			GUIStyle levelSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1 };
			levelSt.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			GUIStyle descSt = new GUIStyle { fontSize = 13, wordWrap = true };
			descSt.normal.textColor = Color.white;
			GUIStyle valSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1, wordWrap = true };
			valSt.normal.textColor = Color.yellow;
			GUIStyle maxSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1, wordWrap = true };
			maxSt.normal.textColor = Color.green;
			GUIStyle costSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1 };
			costSt.normal.textColor = new Color(1f, 0.5f, 0.5f, 1f);
			GUIStyle condOkSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1 };
			condOkSt.normal.textColor = new Color(0.2f, 1f, 0.4f, 1f);
			GUIStyle condFailSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1, wordWrap = true };
			condFailSt.normal.textColor = new Color(1f, 0.2f, 0.2f, 1f);
			GUIStyle limitSt = new GUIStyle { fontSize = 13, fontStyle = (FontStyle)1, wordWrap = true };
			limitSt.normal.textColor = new Color(1f, 0.6f, 0f, 1f);

			// data
			bool maxed = NodeEffectTextBuilder.IsNodeMaxed(currentNode, currentLvl);
			string curVal = NodeEffectTextBuilder.BuildCurrentVal(currentNode, currentLvl);
			string nxtVal = NodeEffectTextBuilder.BuildNextVal(currentNode, currentLvl, maxed);
			if (maxed && currentNode.MaxLevel < 999) { curVal += Loc.Get("RPG.TIP.MAX"); nxtVal = Loc.Get("RPG.TIP.IS_MAX"); }
			string maxStr = (currentNode.MaxLevel >= 999) ? "∞" : currentNode.MaxLevel.ToString();
			GUIStyle activeSt = maxed ? maxSt : valSt;

			// flowing Y cursor
			float y = 10f;
			const float gap = 5f;

			// Title
			float titleH = CalcHeight(titleSt, currentNode.GetLocalizedName(), cw);
			GUI.Label(new Rect(x, y, cw, titleH), currentNode.GetLocalizedName(), titleSt);
			y += titleH + 2f;

			// Level
			GUI.Label(new Rect(x, y, cw, 18f), Loc.Get("RPG.TIP.LEVEL", currentLvl, maxStr), levelSt);
			y += 22f;

			// separator
			DrawSeparator(x, y, cw);
			y += 8f;

			// Description
			string desc = NodeEffectTextBuilder.BuildDescription(currentNode);
			float descH = CalcHeight(descSt, desc, cw);
			GUI.Label(new Rect(x, y, cw, descH), desc, descSt);
			y += descH + gap;

			// separator
			DrawSeparator(x, y, cw);
			y += 8f;

			// Current value
			string curStr = Loc.Get("RPG.TIP.CURRENT", curVal);
			float curH = CalcHeight(activeSt, curStr, cw);
			GUI.Label(new Rect(x, y, cw, curH), curStr, activeSt);
			y += curH + gap;

			// Next value
			string nxtStr = Loc.Get("RPG.TIP.NEXT", nxtVal);
			float nxtH = CalcHeight(valSt, nxtStr, cw);
			GUI.Label(new Rect(x, y, cw, nxtH), nxtStr, valSt);
			y += nxtH + gap;

			// Cost
			GUI.Label(new Rect(x, y, cw, 20f), Loc.Get("RPG.TIP.COST", currentNode.Cost), costSt);
			y += 24f;

			// Condition
			y += DrawConditionInfo(currentNode, condOkSt, condFailSt, limitSt, x, cw, y);

			// auto-resize for next frame
			tooltipWindowRect.height = y + 12f;
		}
	}

	private static float DrawConditionInfo(SkillNode node, GUIStyle condOkSt, GUIStyle condFailSt, GUIStyle limitSt, float x, float cw, float y)
	{
		if (string.IsNullOrEmpty(node.RequiredNodeID))
		{
			return 0f;
		}
		if (!NodeManager.IsParentMaxLevel(node))
		{
			SkillNode byID = NodeDatabase.GetByID(node.RequiredNodeID);
			if (byID != null)
			{
				string text = ((byID.MaxLevel >= 999) ? "∞" : byID.MaxLevel.ToString());
				GUI.Label(new Rect(x, y, cw, 40f), Loc.Get("RPG.TIP.COND_FAIL", byID.GetLocalizedName(), text), condFailSt);
			}
			return 40f;
		}
		if (node.Effect == EffectType.SpeedPenaltyOffset)
		{
			SkillNode byID2 = NodeDatabase.GetByID(node.RequiredNodeID);
			if (byID2 != null)
			{
				int level = NodeManager.GetLevel(byID2.ID);
				int level2 = NodeManager.GetLevel(node.ID);
				if (level2 >= level && level2 < node.MaxLevel)
				{
					GUI.Label(new Rect(x, y, cw, 40f), Loc.Get("RPG.TIP.LIMIT", byID2.GetLocalizedName()), limitSt);
					return 40f;
				}
			}
		}
		GUI.Label(new Rect(x, y, cw, 24f), Loc.Get("RPG.TIP.COND_OK"), condOkSt);
		return 24f;
	}

}

