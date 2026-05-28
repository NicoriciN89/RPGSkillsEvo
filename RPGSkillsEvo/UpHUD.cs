using System.Collections.Generic;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

public static class UpHUD
{
	private struct XPNotice
	{
		public string text;

		public float startTime;

		public Vector2 startPos;
	}

	private static List<XPNotice> xpNotices = new List<XPNotice>();

	private static float levelUpTime = -10f;

	private static int displayLevel = 1;

	private const float XP_DURATION = 2.5f;

	private const float LV_DURATION = 5f;

	private static Texture2D _whiteTex;

	private static Texture2D WhiteTex
	{
		get
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			if ((UnityEngine.Object)(object)_whiteTex != (UnityEngine.Object)null)
			{
				return _whiteTex;
			}
			_whiteTex = new Texture2D(1, 1);
			_whiteTex.SetPixel(0, 0, Color.white);
			_whiteTex.Apply();
			return _whiteTex;
		}
	}

	public static void AddXPNotice(float amount)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		xpNotices.Add(new XPNotice
		{
			text = $"+ {amount:F0} XP",
			startTime = Time.unscaledTime,
			startPos = new Vector2((float)Screen.width / 2f, (float)Screen.height * 0.45f)
		});
	}

	public static void ShowLevelUp(int level)
	{
		levelUpTime = Time.unscaledTime;
		displayLevel = level;
		if ((UnityEngine.Object)(object)GameManager.GetPlayerObject() != (UnityEngine.Object)null)
		{
			GameAudioManager.PlaySound("PLAY_SKILLLEVELLUP", GameManager.GetPlayerObject());
		}
	}

	public static void OnGUI()
	{
		if (!GameManager.IsMainMenuActive())
		{
			DrawXPNotices();
			DrawLevelUpBanner();
		}
	}

	private static void DrawXPNotices()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		if (xpNotices.Count == 0)
		{
			return;
		}
		Rect val3 = default(Rect);
		for (int num = xpNotices.Count - 1; num >= 0; num--)
		{
			XPNotice xPNotice = xpNotices[num];
			float num2 = Time.unscaledTime - xPNotice.startTime;
			if (num2 > 2.5f)
			{
				xpNotices.RemoveAt(num);
			}
			else
			{
				float num3 = Mathf.Clamp01(1f - num2 / 2.5f);
				float num4 = num2 * 50f;
				GUIStyle val = new GUIStyle();
				val.fontSize = 24;
				val.fontStyle = (FontStyle)1;
				val.alignment = (TextAnchor)4;
				val.normal.textColor = new Color(1f, 0.9f, 0.5f, num3);
				GUIStyle val2 = new GUIStyle(val);
				val2.normal.textColor = new Color(0f, 0f, 0f, num3 * 0.5f);
				val3 = new Rect(xPNotice.startPos.x - 100f, xPNotice.startPos.y - num4, 200f, 40f);
				GUI.Label(new Rect(val3.x + 2f, val3.y + 2f, val3.width, val3.height), xPNotice.text, val2);
				GUI.Label(val3, xPNotice.text, val);
			}
		}
	}

	private static void DrawLevelUpBanner()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		float num = Time.unscaledTime - levelUpTime;
		if (!(num > 5f))
		{
			float num2 = 1f;
			if (num < 0.8f)
			{
				num2 = num / 0.8f;
			}
			else if (num > 4.2f)
			{
				num2 = (5f - num) / 0.8f;
			}
			float num3 = (float)Screen.width / 2f;
			float num4 = (float)Screen.height * 0.25f;
			GUI.color = new Color(0f, 0f, 0f, num2 * 0.4f);
			GUI.DrawTexture(new Rect(num3 - 250f, num4 - 40f, 500f, 80f), (Texture)(object)WhiteTex);
			GUI.color = new Color(1f, 1f, 1f, num2 * 0.6f);
			GUI.DrawTexture(new Rect(num3 - 200f, num4 - 40f, 400f, 1f), (Texture)(object)WhiteTex);
			GUI.DrawTexture(new Rect(num3 - 200f, num4 + 40f, 400f, 1f), (Texture)(object)WhiteTex);
			GUIStyle val = new GUIStyle
			{
				fontSize = 32,
				fontStyle = (FontStyle)1,
				alignment = (TextAnchor)4
			};
			val.normal.textColor = new Color(1f, 1f, 1f, num2);
			GUI.Label(new Rect(num3 - 250f, num4 - 35f, 500f, 70f), $"LEVEL UP : {displayLevel}\n<size=18>레벨업 성공</size>", val);
			GUI.color = Color.white;
		}
	}
}
