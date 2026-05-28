using System;
using UnityEngine;

namespace RPGSkillsEvo;

public static class HubButtonsUI
{
	public static void Draw(Action onSkillsOpen, Action onAutoLootOpen, Action onQuickbarOpen)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		float num = 120f;
		float num2 = 96f;
		float num3 = 20f;
		float num4 = 470f;
		float num5 = 180f;
		Rect val = new Rect(num4, num5, num, num2);
		bool flag = val.Contains(Event.current.mousePosition);
		Rect val2 = (Rect)(flag ? new Rect(val.x - 2f, val.y - 2f, val.width, val.height) : val);
		DrawingUtils.Draw3DBox(val2, new Color(0.1f, 0.1f, 0.1f, 1f), 1f, isActive: true, flag);
		SkillNodeRenderer.DrawRainbowRect(new Rect(val2.x + 2f, val2.y + 2f, val2.width - 4f, val2.height - 4f));
		DrawingUtils.DrawRectOutline(val2, new Color(0.9f, 0.9f, 0.9f, 1f), flag ? 2f : 1f);
		if (GUI.Button(val2, "", GUIStyle.none))
		{
			onSkillsOpen?.Invoke();
		}
		Texture2D icon = IconManager.GetIcon("CORE");
		if ((UnityEngine.Object)(object)icon != (UnityEngine.Object)null)
		{
			float num6 = val2.height * 0.5f;
			GUI.DrawTexture(new Rect(val2.x + (val2.width - num6) / 2f, val2.y + (val2.height - num6) * 0.35f, num6, num6), (Texture)(object)icon, (ScaleMode)2);
		}
		GUIStyle val3 = new GUIStyle
		{
			alignment = (TextAnchor)7,
			fontSize = 11,
			fontStyle = (FontStyle)1,
			wordWrap = true
		};
		val3.normal.textColor = Color.black;
		GUIStyle val4 = val3;
		GUI.Label(new Rect(val2.x, val2.y, val2.width, val2.height - 6f), Loc.Get("RPG.UI.SKILL_TREE"), val4);
		bool flag2 = NodeManager.tNodes.ContainsKey("S6W1") && NodeManager.tNodes["S6W1"] > 0;
		Color baseColor = (flag2 ? new Color(0.4f, 0.9f, 0.4f, 1f) : new Color(0.15f, 0.15f, 0.15f, 0.6f));
		DrawNodeStyleButton(new Rect(num4 + (num + num3), num5, num, num2), flag2 ? Loc.Get("RPG.UI.AUTO_LOOT") : "", "Magnet", baseColor, flag2, flag2 ? ((Action)delegate
		{
			onAutoLootOpen?.Invoke();
		}) : null);
		bool flag3 = NodeManager.tNodes.ContainsKey("N6W1") && NodeManager.tNodes["N6W1"] > 0;
		Color baseColor2 = (flag3 ? new Color(1f, 0.7f, 0.1f, 1f) : new Color(0.15f, 0.15f, 0.15f, 0.6f));
		DrawNodeStyleButton(new Rect(num4 + (num + num3) * 2f, num5, num, num2), flag3 ? Loc.Get("RPG.UI.QUICKBAR") : "", "QuickbarIcon", baseColor2, flag3, flag3 ? ((Action)delegate
		{
			onQuickbarOpen?.Invoke();
		}) : null);
		Color baseColor3 = new Color(0.15f, 0.15f, 0.15f, 0.6f);
		for (int num7 = 0; num7 < 3; num7++)
		{
			for (int num8 = 0; num8 < 3; num8++)
			{
				if ((num7 != 0 || num8 != 0) && (num7 != 0 || num8 != 1) && (num7 != 0 || num8 != 2))
				{
					DrawNodeStyleButton(new Rect(num4 + (float)num8 * (num + num3), num5 + (float)num7 * (num2 + num3), num, num2), "", null, baseColor3, isActive: false, null);
				}
			}
		}
	}

	private static void DrawNodeStyleButton(Rect r, string text, string iconID, Color baseColor, bool isActive, Action onClick)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		bool flag = r.Contains(Event.current.mousePosition);
		Rect val = (Rect)(flag ? new Rect(r.x - 2f, r.y - 2f, r.width, r.height) : r);
		DrawingUtils.Draw3DBox(val, baseColor, 1f, isActive, flag);
		Color color = (isActive ? new Color(0.9f, 0.9f, 0.9f, 1f) : new Color(0.4f, 0.4f, 0.4f, 0.8f));
		DrawingUtils.DrawRectOutline(val, color, flag ? 2f : 1f);
		if (GUI.Button(val, "", GUIStyle.none))
		{
			onClick?.Invoke();
		}
		if (!string.IsNullOrEmpty(iconID))
		{
			Texture2D icon = IconManager.GetIcon(iconID);
			if ((UnityEngine.Object)(object)icon != (UnityEngine.Object)null)
			{
				GUI.color = (Color)(isActive ? Color.white : new Color(0.4f, 0.4f, 0.4f, 0.5f));
				float num = val.height * 0.5f;
				Rect val2 = new Rect(val.x + (val.width - num) / 2f, val.y + (val.height - num) * 0.35f, num, num);
				GUI.DrawTexture(val2, (Texture)(object)icon, (ScaleMode)2);
				GUI.color = Color.white;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			GUIStyle val3 = new GUIStyle
			{
				alignment = (TextAnchor)7,
				fontSize = 11,
				fontStyle = (FontStyle)1,
				wordWrap = true
			};
			val3.normal.textColor = (Color)(isActive ? Color.black : new Color(0.7f, 0.7f, 0.7f, 1f));
			GUIStyle val4 = val3;
			GUI.Label(new Rect(val.x, val.y, val.width, val.height - 6f), text, val4);
		}
	}
}
