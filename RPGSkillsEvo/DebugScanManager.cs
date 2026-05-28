using System.Collections.Generic;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

namespace RPGSkillsEvo;

public static class DebugScanManager
{
	private static float remainingDuration = 0f;

	private static bool isActive = false;

	private static Dictionary<int, Shader[]> originalShaders = new Dictionary<int, Shader[]>();

	private static Material lineMaterial;

	private static Vector2[] circleCache;

	private static readonly HashSet<string> exclusionKeywords = new HashSet<string>
	{
		"breath", "fx", "particle", "steam", "cloud", "fire", "flame", "ember", "smoke", "light",
		"glow", "spark", "debris", "burst", "ash", "bone", "skeleton", "remains", "skull", "ribs",
		"prop", "static", "env", "wood", "stick", "branch", "rock", "stone", "coat", "pant",
		"boots", "shoes", "gloves", "mittens", "hat", "wrap", "cap", "balaclava", "shirt", "vest",
		"socks", "sweater", "parka", "jacket", "scarf", "underwear", "clothing", "skin", "hide", "pelt",
		"cured", "dried", "leather", "fur", "item", "gear", "pickup", "proxy", "container", "loot",
		"crow"
	};

	private const float SCAN_RANGE = 3000f;

	private const float SCAN_DURATION = 10f;

	private static void InitCircleCache()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (circleCache == null)
		{
			circleCache = (Vector2[])(object)new Vector2[181];
			for (int i = 0; i <= 180; i++)
			{
				float num = (float)i / 180f * Mathf.PI * 2f;
				circleCache[i] = new Vector2(Mathf.Cos(num), Mathf.Sin(num));
			}
		}
	}

	private static void CreateLineMaterial()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		if (!(UnityEngine.Object)(object)lineMaterial)
		{
			lineMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
			((UnityEngine.Object)lineMaterial).hideFlags = (HideFlags)61;
			lineMaterial.SetInt("_SrcBlend", 5);
			lineMaterial.SetInt("_DstBlend", 10);
			lineMaterial.SetInt("_Cull", 0);
			lineMaterial.SetInt("_ZWrite", 0);
		}
	}

	public static void TriggerScan()
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive() && !string.IsNullOrEmpty(GameManager.m_ActiveScene))
		{
			if (isActive)
			{
				DisableScan();
			}
			else
			{
				EnableScan();
			}
		}
	}

	public static void OnUpdate()
	{
		if (isActive && !GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			remainingDuration -= Time.deltaTime;
			if (remainingDuration <= 0f)
			{
				DisableScan();
			}
		}
	}

	public static void OnGUI()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		if (DebugHelper.isDebugUnlocked && !GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			InitCircleCache();
			CreateLineMaterial();
			float num = 50f;
			float num2 = Screen.width - 270;
			float num3 = Screen.height - 400;
			Rect val = new Rect(num2, num3, num, num);
			Color val2 = (isActive ? Color.green : Color.gray);
			DrawSenseIcon(num2 + num + 10f, num3 + 15f, val2);
			GUIStyle val3 = new GUIStyle
			{
				fontSize = 17,
				fontStyle = (FontStyle)1,
				alignment = (TextAnchor)3
			};
			val3.normal.textColor = val2;
			GUIStyle val4 = val3;
			string text = (isActive ? "ACTIVE" : "READY");
			GUI.Label(new Rect(num2 + num + 85f, num3, 150f, num), text, val4);
			if (isActive)
			{
				GUIStyle val5 = new GUIStyle
				{
					fontSize = 14,
					fontStyle = (FontStyle)1,
					alignment = (TextAnchor)3
				};
				val5.normal.textColor = Color.white;
				GUIStyle val6 = val5;
				GUI.Label(new Rect(num2 + num + 85f, num3 + 22f, 150f, num), $"{remainingDuration:F1}s", val6);
			}
		}
	}

	private static void DrawSenseIcon(float x, float y, Color color)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		float num = 36f;
		Vector2 val = new Vector2(x + num / 2f, y + num / 2f);
		float num2 = num / 2f;
		float time = Time.time;
		DrawRing(val, num2 * (0.97f + Mathf.Sin(time * 0.6f) * 0.03f), 1.6f, new Color(color.r, color.g, color.b, 0.35f));
		for (int i = 0; i < 2; i++)
		{
			float num3 = (time * 0.4f + (float)i * 0.6f) % 1f;
			DrawRing(val, num2 * (0.5f + num3 * 1.8f), 1.2f, new Color(color.r, color.g, color.b, Mathf.Pow(1f - num3, 2f) * 0.5f));
		}
		float num4 = time * 60f * Mathf.Deg2Rad;
		float num5 = 50f * Mathf.Deg2Rad;
		for (int j = 0; j < 2; j++)
		{
			for (float num6 = 0f; num6 < num5; num6 += 0.04f)
			{
				float num7 = num4 + num6 + (float)j * 0.15f;
				float num8 = (1f - num6 / num5) * (1f - (float)j * 0.4f);
				DrawLine(val, val + new Vector2(Mathf.Cos(num7), Mathf.Sin(num7)) * num2, new Color(color.r, color.g, color.b, num8 * 0.35f), 1.1f);
			}
		}
		GUI.color = new Color(color.r, color.g, color.b, 0.08f);
		for (int k = 0; k < 4; k++)
		{
			Vector2 val2 = Random.insideUnitCircle * (num2 * 0.4f);
			GUI.DrawTexture(new Rect(val.x + val2.x, val.y + val2.y, 2f, 2f), (Texture)(object)Texture2D.whiteTexture);
		}
		float num9 = 3.5f * (0.9f + Mathf.Sin(time * 0.8f) * 0.1f);
		GUI.color = new Color(1f, 1f, 1f, 0.85f);
		GUI.DrawTexture(new Rect(val.x - num9 / 2f, val.y - num9 / 2f, num9, num9), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = new Color(color.r, color.g, color.b, 0.15f);
		GUI.DrawTexture(new Rect(x, val.y - 0.5f, num, 1f), (Texture)(object)Texture2D.whiteTexture);
		GUI.DrawTexture(new Rect(val.x - 0.5f, y, 1f, num), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
	}

	private static void DrawRing(Vector2 center, float radius, float thickness, Color color)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		InitCircleCache();
		CreateLineMaterial();
		lineMaterial.SetPass(0);
		float num = radius - thickness;
		GL.Begin(4);
		GL.Color(color);
		for (int i = 0; i < 180; i++)
		{
			Vector2 val = circleCache[i];
			Vector2 val2 = circleCache[i + 1];
			GL.Vertex((Vector3)(center + val * radius));
			GL.Vertex((Vector3)(center + val2 * radius));
			GL.Vertex((Vector3)(center + val * num));
			GL.Vertex((Vector3)(center + val * num));
			GL.Vertex((Vector3)(center + val2 * radius));
			GL.Vertex((Vector3)(center + val2 * num));
		}
		GL.End();
	}

	private static void DrawLine(Vector2 a, Vector2 b, Color color, float width)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		CreateLineMaterial();
		lineMaterial.SetPass(0);
		Vector2 val = b - a;
		float num = 0f - val.normalized.y;
		val = b - a;
		Vector2 val2 = new Vector2(num, val.normalized.x) * (width * 0.5f);
		GL.Begin(4);
		GL.Color(color);
		GL.Vertex((Vector3)(a - val2));
		GL.Vertex((Vector3)(a + val2));
		GL.Vertex((Vector3)(b - val2));
		GL.Vertex((Vector3)(b - val2));
		GL.Vertex((Vector3)(a + val2));
		GL.Vertex((Vector3)(b + val2));
		GL.End();
	}

	private static void EnableScan()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		isActive = true;
		remainingDuration = 10f;
		float num = 9000000f;
		Vector3 position = GameManager.GetPlayerTransform().position;
		Shader val = Shader.Find("Hidden/Internal-Colored");
		if ((UnityEngine.Object)(object)val == (UnityEngine.Object)null)
		{
			return;
		}
		foreach (Renderer item in Object.FindObjectsOfType<Renderer>())
		{
			if ((UnityEngine.Object)(object)item == (UnityEngine.Object)null)
			{
				continue;
			}
			Vector3 val2 = ((Component)item).transform.position - position;
			if (val2.sqrMagnitude > num)
			{
				continue;
			}
			GameObject gameObject = ((Component)item).gameObject;
			string text = ((UnityEngine.Object)gameObject).name.ToLower();
			bool flag = false;
			foreach (string exclusionKeyword in exclusionKeywords)
			{
				if (text.Contains(exclusionKeyword))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			string text2 = (((UnityEngine.Object)(object)gameObject.transform.parent != (UnityEngine.Object)null) ? ((UnityEngine.Object)gameObject.transform.parent).name.ToLower() : "");
			string text3 = ((UnityEngine.Object)gameObject.transform.root).name.ToLower();
			string text4 = text + " " + text2 + " " + text3;
			float num2 = 0.5f;
			Color white = Color.white;
			bool flag2 = false;
			if (text4.Contains("bear"))
			{
				white = new Color(0.5f, 0f, 0.5f, num2);
				flag2 = true;
			}
			else if (text4.Contains("wolf"))
			{
				white = new Color(1f, 0f, 0f, num2);
				flag2 = true;
			}
			else if (text4.Contains("cougar"))
			{
				white = new Color(1f, 0.4f, 0f, num2);
				flag2 = true;
			}
			else if (text4.Contains("moose"))
			{
				white = new Color(0f, 0f, 0.4f, num2);
				flag2 = true;
			}
			else if (text4.Contains("rabbit") || text4.Contains("doe") || text4.Contains("stag") || text4.Contains("deer"))
			{
				white = new Color(0f, 1f, 0f, num2);
				flag2 = true;
			}
			else if (text4.Contains("ptarmigan"))
			{
				white = new Color(1f, 1f, 0f, num2);
				flag2 = true;
			}
			if (!flag2 && (UnityEngine.Object)(object)gameObject.GetComponentInParent<BaseAi>() != (UnityEngine.Object)null)
			{
				white = new Color(1f, 0f, 0f, num2);
				flag2 = true;
			}
			if (!flag2)
			{
				continue;
			}
			int instanceID = ((UnityEngine.Object)item).GetInstanceID();
			if (originalShaders.ContainsKey(instanceID))
			{
				continue;
			}
			var array = item.materials;
			Shader[] array2 = (Shader[])(object)new Shader[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if ((UnityEngine.Object)(object)array[i] != (UnityEngine.Object)null)
				{
					array2[i] = array[i].shader;
					array[i].shader = val;
					array[i].SetInt("_ZTest", 8);
					array[i].SetInt("_ZWrite", 0);
					array[i].renderQueue = 5000;
					array[i].SetColor("_Color", white);
				}
			}
			originalShaders[instanceID] = array2;
		}
	}

	private static void DisableScan()
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		isActive = false;
		remainingDuration = 0f;
		foreach (Renderer item in Object.FindObjectsOfType<Renderer>())
		{
			if ((UnityEngine.Object)(object)item == (UnityEngine.Object)null)
			{
				continue;
			}
			int instanceID = ((UnityEngine.Object)item).GetInstanceID();
			if (!originalShaders.TryGetValue(instanceID, out var value))
			{
				continue;
			}
			var array = item.materials;
			for (int i = 0; i < array.Length; i++)
			{
				if ((UnityEngine.Object)(object)array[i] != (UnityEngine.Object)null && i < value.Length)
				{
					array[i].shader = value[i];
					array[i].renderQueue = -1;
					if (array[i].HasProperty("_Color"))
					{
						array[i].SetColor("_Color", Color.white);
					}
				}
			}
		}
		originalShaders.Clear();
	}
}
