using UnityEngine;

namespace RPGSkillsEvo;

public static class DrawingUtils
{
	public static float Spacing = 144f;

	public static float NodeSize = 60f;

	public static Vector2 GetCanvasPos(int gridX, int gridY)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		float zoomLevel = UILayout.ZoomLevel;
		Vector2 panOffset = UILayout.PanOffset;
		float num = UILayout.NodeAreaRect.width / 2f;
		float num2 = UILayout.NodeAreaRect.height / 2f;
		float num3 = Mathf.Round(num + panOffset.x + (float)gridX * Spacing * zoomLevel);
		float num4 = Mathf.Round(num2 + panOffset.y + (float)gridY * Spacing * zoomLevel);
		return new Vector2(num3, num4);
	}

	public static void Draw3DBox(Rect r, Color baseColor, float zoom, bool isActive, bool isHovered)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		Rect val = new Rect((float)(int)r.x, (float)(int)r.y, (float)(int)r.width, (float)(int)r.height);
		float num = (int)(4f * zoom);
		if (isHovered)
		{
			num += 2f;
		}
		GUI.color = new Color(0f, 0f, 0f, 0.8f);
		GUI.DrawTexture(new Rect(val.x + num, val.y + num, val.width, val.height), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = baseColor;
		GUI.DrawTexture(val, (Texture)(object)Texture2D.whiteTexture);
		Color color;
		float num2;
		if (isHovered)
		{
			color = Color.white;
			num2 = 2.5f * zoom;
		}
		else
		{
			color = (isActive ? new Color(1f, 1f, 1f, 0.8f) : new Color(0.4f, 0.4f, 0.4f, 0.8f));
			num2 = 1.5f * zoom;
		}
		DrawRectOutline(val, color, Mathf.Max(1f, (float)(int)num2));
		GUI.color = Color.white;
	}

	public static void DrawLevelDots(Rect nodeRect, int currentLvl, int maxLvl, float zoom, bool skipDots = false)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		if (skipDots || maxLvl <= 0)
		{
			return;
		}
		float num = 6f * zoom;
		float num2 = 3f * zoom;
		float num3 = num * (float)maxLvl + num2 * (float)(maxLvl - 1);
		if (num3 > nodeRect.width)
		{
			num = (nodeRect.width - num2 * (float)(maxLvl - 1)) / (float)maxLvl;
			num3 = nodeRect.width;
		}
		float num4 = nodeRect.x + (nodeRect.width - num3) / 2f;
		float num5 = nodeRect.y - (num + 5f * zoom);
		Rect val = default(Rect);
		for (int i = 0; i < maxLvl; i++)
		{
			val = new Rect(num4 + (float)i * (num + num2), num5, num, num);
			if (i < currentLvl)
			{
				GUI.color = new Color(1f, 0.84f, 0f, 1f);
			}
			else
			{
				GUI.color = new Color(0.2f, 0.2f, 0.2f, 0.8f);
			}
			GUI.DrawTexture(val, (Texture)(object)Texture2D.whiteTexture);
			DrawRectOutline(val, new Color(1f, 1f, 1f, 0.6f), 1f);
		}
		GUI.color = Color.white;
	}

	public static void DrawRectOutline(Rect r, Color color, float thickness)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		GUI.color = color;
		int num = (int)thickness;
		GUI.DrawTexture(new Rect(r.x - (float)num, r.y - (float)num, r.width + (float)(num * 2), (float)num), (Texture)(object)Texture2D.whiteTexture);
		GUI.DrawTexture(new Rect(r.x - (float)num, r.yMax, r.width + (float)(num * 2), (float)num), (Texture)(object)Texture2D.whiteTexture);
		GUI.DrawTexture(new Rect(r.x - (float)num, r.y, (float)num, r.height), (Texture)(object)Texture2D.whiteTexture);
		GUI.DrawTexture(new Rect(r.xMax, r.y, (float)num, r.height), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
	}

	public static void DrawGridLine(Vector2 start, Vector2 end, Color color, float thickness)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		float zoomLevel = UILayout.ZoomLevel;
		float num = (int)(thickness * zoomLevel);
		Rect val = default(Rect);
		if (Mathf.Abs(start.y - end.y) < 0.1f)
		{
			val = new Rect((float)(int)Mathf.Min(start.x, end.x), (float)(int)(start.y - num / 2f), (float)(int)Mathf.Abs(start.x - end.x), (float)(int)num);
		}
		else
		{
			val = new Rect((float)(int)(start.x - num / 2f), (float)(int)Mathf.Min(start.y, end.y), (float)(int)num, (float)(int)Mathf.Abs(start.y - end.y));
		}
		GUI.color = color;
		GUI.DrawTexture(val, (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
	}

	public static void DrawDiagonalLine(Vector2 start, Vector2 end, Color color, float thickness)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		float zoomLevel = UILayout.ZoomLevel;
		float num = Mathf.Max(1f, thickness * zoomLevel);
		float num2 = end.x - start.x;
		float num3 = end.y - start.y;
		float num4 = Mathf.Sqrt(num2 * num2 + num3 * num3);
		if (!(num4 < 0.1f))
		{
			int num5 = Mathf.CeilToInt(num4);
			float num6 = num2 / (float)num5;
			float num7 = num3 / (float)num5;
			int num8 = Mathf.Max(1, (int)num);
			GUI.color = color;
			for (int i = 0; i < num5; i++)
			{
				float num9 = start.x + num6 * (float)i;
				float num10 = start.y + num7 * (float)i;
				GUI.DrawTexture(new Rect((float)(int)(num9 - (float)num8 * 0.5f), (float)(int)(num10 - (float)num8 * 0.5f), (float)num8, (float)num8), (Texture)(object)Texture2D.whiteTexture);
			}
			GUI.color = Color.white;
		}
	}

	public static void DrawConnection(SkillNode node)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		SkillNode skillNode = NodeDatabase.AllNodes.Find((SkillNode n) => n.ID == node.RequiredNodeID);
		if (skillNode == null)
		{
			return;
		}
		Vector2 canvasPos = GetCanvasPos(skillNode.GridX, skillNode.GridY);
		Vector2 canvasPos2 = GetCanvasPos(node.GridX, node.GridY);
		int level = NodeManager.GetLevel(skillNode.ID);
		int level2 = NodeManager.GetLevel(node.ID);
		Color val = default(Color);
		if (node.ID.StartsWith("WS") || skillNode.ID.StartsWith("WS"))
		{
			val = new Color(0.65f, 0.3f, 0.9f, 1f);
		}
		else if (node.ID.StartsWith("W") || skillNode.ID.StartsWith("W"))
		{
			val = new Color(0.85f, 0.25f, 0.25f, 1f);
		}
		else if (node.ID.StartsWith("ES") || skillNode.ID.StartsWith("ES"))
		{
			val = new Color(0f, 0.2f, 1f, 1f);
		}
		else if (node.ID.StartsWith("E") || skillNode.ID.StartsWith("E"))
		{
			val = new Color(0.3f, 0.75f, 1f, 1f);
		}
		else if (node.ID.StartsWith("S") || skillNode.ID.StartsWith("S"))
		{
			val = new Color(0.4f, 0.9f, 0.4f, 1f);
		}
		else
		{
			val = new Color(1f, 0.7f, 0.1f, 1f);
		}
		Color val2 = (Color)((level > 0 && level2 > 0) ? val : ((level > 0) ? new Color(0.4f, 0.4f, 0.4f, 0.6f) : Color.clear));
		if (!(val2 == Color.clear))
		{
			if (Mathf.Abs(canvasPos.x - canvasPos2.x) > 0.1f && Mathf.Abs(canvasPos.y - canvasPos2.y) > 0.1f)
			{
				DrawDiagonalLine(canvasPos, canvasPos2, val2, 4f);
			}
			else
			{
				DrawGridLine(canvasPos, canvasPos2, val2, 4f);
			}
		}
	}
}
