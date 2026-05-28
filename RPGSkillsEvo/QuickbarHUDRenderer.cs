using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using Il2CppTLD.Gear;
using UnityEngine;

namespace RPGSkillsEvo;

public static class QuickbarHUDRenderer
{
	private static Texture2D[] cachedIcons;

	private static string[] cachedKeyStrings;

	private static string[] cachedPresetKeyStrings;

	private static float lastUpdateTime;

	private const float UpdateInterval = 0.5f;

	private static bool stylesInit;

	private static GUIStyle keyStyle;

	private static GUIStyle condStyle;

	private static GUIStyle presetIconStyle;

	public static void Init()
	{
		cachedIcons = (Texture2D[])(object)new Texture2D[7];
		cachedKeyStrings = new string[7];
		cachedPresetKeyStrings = new string[3];
		UpdateKeyStrings();
	}

	public static void UpdateKeyStrings()
	{
		if (cachedKeyStrings != null)
		{
			for (int i = 0; i < 7; i++)
			{
				string text = QuickbarData.Slots[i].HotKey.ToString();
				cachedKeyStrings[i] = text.Replace("Alpha", "");
			}
			for (int j = 0; j < 3; j++)
			{
				string text2 = QuickbarData.PresetHotKeys[j].ToString();
				cachedPresetKeyStrings[j] = text2.Replace("Alpha", "");
			}
		}
	}

	public static void RefreshIcons()
	{
		if (cachedIcons == null)
		{
			Init();
		}
		int activeSlotCount = QuickbarData.GetActiveSlotCount();
		for (int i = 0; i < activeSlotCount; i++)
		{
			string itemID = QuickbarData.Slots[i].ItemID;
			cachedIcons[i] = ((itemID == "None") ? null : QuickbarActionManager.GetIcon(itemID));
		}
	}

	public static void OnGUI()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		if (!QuickbarData.IsQuickSlotUnlocked() || GameManager.IsMainMenuActive() || InterfaceUI.IsOpen || GameManager.m_IsPaused)
		{
			return;
		}
		if (cachedIcons == null)
		{
			Init();
		}
		if (!stylesInit)
		{
			GUIStyle val = new GUIStyle
			{
				fontSize = 11,
				fontStyle = (FontStyle)1
			};
			val.normal.textColor = new Color(0.7f, 0.7f, 0.7f, 1f);
			keyStyle = val;
			GUIStyle val2 = new GUIStyle
			{
				fontSize = 11,
				alignment = (TextAnchor)7,
				fontStyle = (FontStyle)1
			};
			val2.normal.textColor = Color.white;
			condStyle = val2;
			presetIconStyle = new GUIStyle
			{
				fontSize = 24,
				alignment = (TextAnchor)4,
				fontStyle = (FontStyle)1
			};
			stylesInit = true;
		}
		if (Time.realtimeSinceStartup - lastUpdateTime > 0.5f)
		{
			RefreshIcons();
			lastUpdateTime = Time.realtimeSinceStartup;
		}
		float num = (float)Screen.width / 1920f;
		float num2 = (float)Screen.height / 1080f;
		Matrix4x4 matrix = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(num, num2, 1f));
		float num3 = 52f;
		float num4 = 8f;
		float num5 = 20f;
		int activeSlotCount = QuickbarData.GetActiveSlotCount();
		int num6 = (QuickbarData.IsPresetUnlocked() ? QuickbarData.GetActivePresetCount() : 0);
		float num7 = (num3 + num4) * (float)activeSlotCount - num4;
		float num8 = ((num6 > 0) ? ((num3 + num4) * (float)num6 - num4) : 0f);
		float num9 = num7 + ((num6 > 0) ? (num5 + num8) : 0f);
		float num10 = (1920f - num9) / 2f;
		float num11 = 1080f - num3;
		Rect val3 = default(Rect);
		for (int i = 0; i < activeSlotCount; i++)
		{
			val3 = new Rect(num10 + (float)i * (num3 + num4), num11, num3, num3);
			GUI.color = new Color(0f, 0f, 0f, 0.7f);
			GUI.Box(val3, "");
			GUI.color = Color.white;
			if (cachedKeyStrings != null && i < cachedKeyStrings.Length)
			{
				GUI.Label(new Rect(val3.x + 4f, val3.y + 1f, 30f, 15f), cachedKeyStrings[i], keyStyle);
			}
			if ((UnityEngine.Object)(object)cachedIcons[i] == (UnityEngine.Object)null)
			{
				continue;
			}
			GUI.DrawTexture(new Rect(val3.x + 5f, val3.y + 5f, num3 - 10f, num3 - 10f), (Texture)(object)cachedIcons[i], (ScaleMode)2);
			Inventory inventoryComponent = GameManager.GetInventoryComponent();
			if ((UnityEngine.Object)(object)inventoryComponent == (UnityEngine.Object)null)
			{
				continue;
			}
			string itemID = QuickbarData.Slots[i].ItemID;
			foreach (var current in inventoryComponent.m_Items)
			{
				GearItem val4 = ((current != null) ? current.m_GearItem : null);
				if ((UnityEngine.Object)(object)val4 != (UnityEngine.Object)null && ((UnityEngine.Object)val4).name == itemID)
				{
					string text = $"{val4.GetNormalizedCondition() * 100f:F0}%";
					GUI.color = Color.black;
					GUI.Label(new Rect(val3.x + 1f, val3.y + num3 - 15f, num3, 14f), text, condStyle);
					GUI.color = Color.white;
					GUI.Label(new Rect(val3.x, val3.y + num3 - 16f, num3, 14f), text, condStyle);
					break;
				}
			}
		}
		if (num6 > 0)
		{
			float num12 = num10 + num7 + num5;
			string[] array = new string[3] { "★", "♥", "●" };
			Color[] array2 = (Color[])(object)new Color[3]
			{
				Color.cyan,
				Color.magenta,
				Color.green
			};
			Rect val5 = default(Rect);
			for (int j = 0; j < num6; j++)
			{
				val5 = new Rect(num12 + (float)j * (num3 + num4), num11, num3, num3);
				GUI.color = new Color(0f, 0f, 0f, 0.7f);
				GUI.Box(val5, "");
				GUI.color = Color.white;
				if (cachedPresetKeyStrings != null && j < cachedPresetKeyStrings.Length)
				{
					GUI.Label(new Rect(val5.x + 4f, val5.y + 1f, 30f, 15f), cachedPresetKeyStrings[j], keyStyle);
				}
				bool flag = QuickbarData.Presets[j].ClothingNames.Count > 0;
				presetIconStyle.normal.textColor = (Color)(flag ? array2[j] : new Color(0.4f, 0.4f, 0.4f, 0.5f));
				GUI.Label(new Rect(val5.x, val5.y - 2f, num3, num3), array[j], presetIconStyle);
				GUIStyle val6 = new GUIStyle
				{
					fontSize = 9,
					alignment = (TextAnchor)7,
					fontStyle = (FontStyle)1
				};
				val6.normal.textColor = Color.white;
				GUIStyle val7 = val6;
				GUI.Label(new Rect(val5.x, val5.y + num3 - 13f, num3, 12f), $"PRESET {j + 1}", val7);
			}
		}
		GUI.matrix = matrix;
	}
}
