using UnityEngine;

namespace RPGSkillsEvo;

public static class UILayout
{
	public static Rect windowRect = new Rect((float)(Screen.width / 2 - 500), (float)(Screen.height / 2 - 400), 1000f, 800f);

	public static Rect confirmRect = new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 100), 400f, 200f);

	public static Rect NodeAreaRect = new Rect(10f, 80f, 980f, 710f);

	public static float ZoomLevel = 1f;

	private const float MinZoom = 0.33f;

	private const float MaxZoom = 2f;

	public static Vector2 PanOffset = Vector2.zero;

	private static Vector2 lastMousePos;

	private static bool isDragging = false;

	public static void HandleZoom()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis != 0f)
		{
			float zoomLevel = ZoomLevel;
			float num = Mathf.Clamp(zoomLevel + axis * 0.13f, 0.33f, 2f);
			float num2 = num / zoomLevel;
			PanOffset *= num2;
			ZoomLevel = num;
		}
	}

	public static void HandlePan()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
		Rect val2 = new Rect(windowRect.x + NodeAreaRect.x, windowRect.y + NodeAreaRect.y, NodeAreaRect.width, NodeAreaRect.height);
		if (Input.GetMouseButtonDown(0) && val2.Contains(val))
		{
			bool flag = false;
			Vector2 val3 = val - new Vector2(val2.x, val2.y);
			Rect val4 = default(Rect);
			foreach (SkillNode allNode in NodeDatabase.AllNodes)
			{
				if (NodeManager.IsVisible(allNode))
				{
					float zoomLevel = ZoomLevel;
					Vector2 panOffset = PanOffset;
					float num = NodeAreaRect.width / 2f;
					float num2 = NodeAreaRect.height / 2f;
					float num3 = num + panOffset.x + (float)allNode.GridX * DrawingUtils.Spacing * zoomLevel;
					float num4 = num2 + panOffset.y + (float)allNode.GridY * DrawingUtils.Spacing * zoomLevel;
					float num5 = DrawingUtils.NodeSize * zoomLevel;
					val4 = new Rect(num3 - num5 / 2f, num4 - num5 / 2f, num5, num5);
					if (val4.Contains(val3))
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				lastMousePos = (Vector2)(Input.mousePosition);
				isDragging = true;
			}
		}
		if (Input.GetMouseButton(0) && isDragging)
		{
			Vector2 val5 = (Vector2)(Input.mousePosition);
			Vector2 val6 = val5 - lastMousePos;
			PanOffset += new Vector2(val6.x, 0f - val6.y);
			lastMousePos = val5;
		}
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
		}
	}

	public static void ResetView()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		ZoomLevel = 1f;
		PanOffset = Vector2.zero;
	}
}
