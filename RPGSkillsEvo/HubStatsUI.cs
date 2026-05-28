using UnityEngine;

namespace RPGSkillsEvo;

public static class HubStatsUI
{
	private static Vector2 statScrollPos = Vector2.zero;

	public static void Draw()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Expected O, but got Unknown
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Expected O, but got Unknown
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Expected O, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected O, but got Unknown
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected O, but got Unknown
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Expected O, but got Unknown
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Expected O, but got Unknown
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Expected O, but got Unknown
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Unknown result type (might be due to invalid IL or missing references)
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0823: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f59: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_111c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1191: Unknown result type (might be due to invalid IL or missing references)
		//IL_1157: Unknown result type (might be due to invalid IL or missing references)
		//IL_100b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1206: Unknown result type (might be due to invalid IL or missing references)
		//IL_127b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1241: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1069: Unknown result type (might be due to invalid IL or missing references)
		//IL_1365: Unknown result type (might be due to invalid IL or missing references)
		//IL_132b: Unknown result type (might be due to invalid IL or missing references)
		GUIStyle val = new GUIStyle
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = new Color(0.85f, 0.85f, 0.85f, 1f);
		GUIStyle val2 = val;
		GUIStyle val3 = new GUIStyle
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		GUIStyle val5 = new GUIStyle
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val5.normal.textColor = Color.yellow;
		GUIStyle val6 = val5;
		GUIStyle val7 = new GUIStyle
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val7.normal.textColor = new Color(0.7f, 0.9f, 1f);
		GUIStyle val8 = val7;
		GUI.color = new Color(0.06f, 0.06f, 0.06f, 1f);
		GUI.DrawTexture(new Rect(20f, 55f, 300f, 110f), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(new Rect(20f, 55f, 300f, 110f), new Color(0.35f, 0.35f, 0.35f, 1f), 1f);
		GUI.Label(new Rect(35f, 65f, 130f, 22f), Loc.Get("RPG.UI.LEVEL"), val2);
		GUI.Label(new Rect(185f, 65f, 120f, 22f), $"Lv.{PlayerLevel.Level}", val4);
		DrawingUtils.DrawRectOutline(new Rect(30f, 88f, 280f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(35f, 93f, 130f, 22f), Loc.Get("RPG.UI.EXP"), val2);
		GUI.Label(new Rect(185f, 93f, 120f, 22f), $"{PlayerLevel.CurrentXP:F0} / {PlayerLevel.RequiredXP:F0}", val8);
		DrawingUtils.DrawRectOutline(new Rect(30f, 116f, 280f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(35f, 121f, 130f, 22f), Loc.Get("RPG.UI.SP"), val2);
		GUI.Label(new Rect(185f, 121f, 120f, 22f), $"{NodeManager.tPoints} PT", val6);
		Rect val9 = new Rect(20f, 180f, 300f, 590f);
		GUI.color = new Color(0.06f, 0.06f, 0.06f, 1f);
		GUI.DrawTexture(val9, (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(val9, new Color(0.35f, 0.35f, 0.35f, 1f), 1f);
		GUIStyle val10 = new GUIStyle
		{
			fontSize = 12,
			fontStyle = (FontStyle)1
		};
		val10.normal.textColor = new Color(0.6f, 0.6f, 0.6f, 1f);
		val10.alignment = (TextAnchor)3;
		GUIStyle val11 = val10;
		GUI.Label(new Rect(35f, 185f, 280f, 22f), Loc.Get("RPG.UI.STATS_DETAIL"), val11);
		DrawingUtils.DrawRectOutline(new Rect(30f, 205f, 280f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		Rect val12 = new Rect(20f, 209f, 300f, 559f);
		float weightBonus = Status.GetWeightBonus();
		float num = Status.GetWalkSpeedBonus() * 100f;
		float num2 = Status.GetSprintSpeedBonus() * 100f;
		float num3 = Status.GetCrouchSpeedBonus() * 100f;
		float num4 = Status.GetSpeedPenalty() * 100f;
		float num5 = Status.GetWindResist() * 100f;
		float warmthBonus = Status.GetWarmthBonus();
		float num6 = Status.GetFatigueReduction() * 100f;
		float num7 = Status.GetHungerReduction() * 100f;
		float vitalityBonus = Status.GetVitalityBonus();
		float weightDownPenalty = Status.GetWeightDownPenalty();
		float num8 = Status.GetProtectionBonus() * 100f;
		float vitalityDownPenalty = Status.GetVitalityDownPenalty();
		float num9 = Status.GetDecayEfficiency() * 100f;
		float num10 = Status.GetBuffDuration() * 100f;
		float final = num - num4;
		float final2 = num2 - num4;
		float final3 = num3 - num4;
		Color textColor = new Color(1f, 1f, 1f, 1f);
		Color textColor2 = new Color(1f, 0.2f, 0.2f, 1f);
		Color textColor3 = new Color(0.2f, 1f, 0.4f, 1f);
		Color textColor4 = new Color(0.4f, 0.8f, 1f, 1f);
		Color textColor5 = new Color(1f, 0.6f, 0.2f, 1f);
		Color textColor6 = new Color(0.2f, 0.9f, 0.9f, 1f);
		Color textColor7 = new Color(1f, 0.9f, 0.2f, 1f);
		Color textColor8 = new Color(0.8f, 0.4f, 1f, 1f);
		Color textColor9 = new Color(0.2f, 0.9f, 0.7f, 1f);
		Color textColor10 = new Color(0.2f, 0.4f, 1f, 1f);
		Color textColor11 = new Color(1f, 0.4f, 0.8f, 1f);
		GUIStyle val13 = new GUIStyle
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val13.normal.textColor = new Color(0.85f, 0.85f, 0.85f, 1f);
		val13.wordWrap = true;
		GUIStyle val14 = val13;
		GUIStyle val15 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val15.normal.textColor = textColor;
		val15.wordWrap = false;
		GUIStyle val16 = val15;
		GUIStyle val17 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val17.normal.textColor = textColor2;
		val17.wordWrap = false;
		GUIStyle val18 = val17;
		GUIStyle val19 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val19.normal.textColor = textColor3;
		val19.wordWrap = false;
		GUIStyle val20 = val19;
		GUIStyle val21 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val21.normal.textColor = textColor4;
		val21.wordWrap = false;
		GUIStyle val22 = val21;
		GUIStyle val23 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val23.normal.textColor = textColor5;
		val23.wordWrap = false;
		GUIStyle val24 = val23;
		GUIStyle val25 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val25.normal.textColor = textColor6;
		val25.wordWrap = false;
		GUIStyle val26 = val25;
		GUIStyle val27 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val27.normal.textColor = textColor7;
		val27.wordWrap = false;
		GUIStyle val28 = val27;
		GUIStyle val29 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val29.normal.textColor = textColor8;
		val29.wordWrap = false;
		GUIStyle val30 = val29;
		GUIStyle val31 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val31.normal.textColor = textColor9;
		val31.wordWrap = false;
		GUIStyle val32 = val31;
		GUIStyle val33 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val33.normal.textColor = textColor10;
		val33.wordWrap = false;
		GUIStyle val34 = val33;
		GUIStyle val35 = new GUIStyle
		{
			fontSize = 11,
			fontStyle = (FontStyle)1
		};
		val35.normal.textColor = textColor11;
		val35.wordWrap = false;
		GUIStyle val36 = val35;
		float num11 = 634f;
		Rect val37 = new Rect(0f, 0f, 280f, num11);
		statScrollPos = GUI.BeginScrollView(val12, statScrollPos, val37, false, false);
		float num12 = 10f;
		float num13 = 52f;
		float num14 = 10f;
		float num15 = 145f;
		GUI.Label(new Rect(10f, num12, 130f, 40f), Loc.Get("RPG.UI.STAT_WEIGHT"), val14);
		if (weightDownPenalty > 0f)
		{
			float num16 = num15;
			GUI.Label(new Rect(num16, num12 + num14, 60f, 22f), $"+{weightBonus}kg", val16);
			num16 += 50f;
			GUI.Label(new Rect(num16, num12 + num14, 60f, 22f), $"-{weightDownPenalty}kg", val18);
			num16 += 50f;
			GUI.Label(new Rect(num16, num12 + num14, 60f, 22f), $"({weightBonus - weightDownPenalty}kg)", val20);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num14, 110f, 22f), $"+{weightBonus}kg", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13, 130f, 40f), Loc.Get("RPG.UI.STAT_WALK"), val14);
		DrawSpeedStat(num15, num12 + num13 + num14, num, num4, final, val16, val18, val20);
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 2f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 2f, 130f, 40f), Loc.Get("RPG.UI.STAT_SPRINT"), val14);
		DrawSpeedStat(num15, num12 + num13 * 2f + num14, num2, num4, final2, val16, val18, val20);
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 3f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 3f, 130f, 40f), Loc.Get("RPG.UI.STAT_CROUCH"), val14);
		DrawSpeedStat(num15, num12 + num13 * 3f + num14, num3, num4, final3, val16, val18, val20);
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 4f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 4f, 130f, 40f), Loc.Get("RPG.UI.STAT_WIND"), val14);
		if (num5 > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 4f + num14, 120f, 22f), $"{num5:F0}% Ignore", val22);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 4f + num14, 110f, 22f), "+0%", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 5f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 5f, 130f, 40f), Loc.Get("RPG.UI.STAT_WARMTH"), val14);
		if (warmthBonus > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 5f + num14, 120f, 22f), $"+{warmthBonus:F0}°C", val24);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 5f + num14, 110f, 22f), "+0°C", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 6f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 6f, 130f, 40f), Loc.Get("RPG.UI.STAT_FATIGUE"), val14);
		if (num6 > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 6f + num14, 120f, 22f), $"-{num6:F0}%", val26);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 6f + num14, 110f, 22f), "-0%", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 7f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 7f, 130f, 40f), Loc.Get("RPG.UI.STAT_HUNGER"), val14);
		if (num7 > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 7f + num14, 120f, 22f), $"-{num7:F0}%", val28);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 7f + num14, 110f, 22f), "-0%", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 8f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 8f, 130f, 40f), Loc.Get("RPG.UI.STAT_VITALITY"), val14);
		if (vitalityBonus > 0f || vitalityDownPenalty > 0f)
		{
			float num17 = num15;
			if (vitalityBonus > 0f)
			{
				GUI.Label(new Rect(num17, num12 + num13 * 8f + num14, 50f, 22f), $"+{vitalityBonus:F0}", val30);
				num17 += 40f;
			}
			if (vitalityDownPenalty > 0f)
			{
				GUI.Label(new Rect(num17, num12 + num13 * 8f + num14, 50f, 22f), $"-{vitalityDownPenalty:F0}", val18);
				num17 += 40f;
			}
			if (vitalityBonus > 0f || vitalityDownPenalty > 0f)
			{
				GUI.Label(new Rect(num17, num12 + num13 * 8f + num14, 60f, 22f), $"({vitalityBonus - vitalityDownPenalty:F0})", val20);
			}
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 8f + num14, 110f, 22f), "+0", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 9f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 9f, 130f, 40f), Loc.Get("RPG.UI.STAT_PROTECTION"), val14);
		if (num8 > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 9f + num14, 120f, 22f), $"+{num8:F0}%", val32);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 9f + num14, 110f, 22f), "+0%", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 10f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 10f, 130f, 40f), Loc.Get("RPG.UI.STAT_DURABILITY"), val14);
		if (num9 > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 10f + num14, 120f, 22f), $"-{num9:F0}%", val34);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 10f + num14, 110f, 22f), "-0%", val16);
		}
		DrawingUtils.DrawRectOutline(new Rect(10f, num12 + num13 * 11f - 4f, 260f, 1f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUI.Label(new Rect(10f, num12 + num13 * 11f, 130f, 40f), Loc.Get("RPG.UI.STAT_BUFF"), val14);
		if (num10 > 0f)
		{
			GUI.Label(new Rect(num15, num12 + num13 * 11f + num14, 120f, 22f), $"+{num10:F0}%", val36);
		}
		else
		{
			GUI.Label(new Rect(num15, num12 + num13 * 11f + num14, 110f, 22f), "+0%", val16);
		}
		GUI.EndScrollView();
	}

	private static void DrawSpeedStat(float x, float y, float bonus, float penalty, float final, GUIStyle plusSt, GUIStyle minusSt, GUIStyle finalSt)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		float num = x;
		if (bonus > 0f)
		{
			GUI.Label(new Rect(num, y, 50f, 22f), $"+{bonus:F0}%", plusSt);
			num += 40f;
		}
		if (penalty > 0f)
		{
			GUI.Label(new Rect(num, y, 50f, 22f), $"-{penalty:F0}%", minusSt);
			num += 40f;
		}
		if (bonus > 0f || penalty > 0f)
		{
			GUI.Label(new Rect(num, y, 60f, 22f), $"({final:F0}%)", finalSt);
		}
		else
		{
			GUI.Label(new Rect(x, y, 50f, 22f), "+0%", plusSt);
		}
	}
}
