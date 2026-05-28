using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSkillsEvo;

public static class AutoLootSlotUI
{
	private static List<string> categoryKeys = new List<string>();

	public static void Init()
	{
		categoryKeys = new List<string>(AutoLootData.Categories.Keys);
	}

	public static void DrawSlot(int i, int activeSlotIndex, int activeItemSlotIndex, Action<int> onCategoryClick, Action<int> onItemClick, Action<int> onToggle, Action<int> onReset)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)i * 70f;
		AutoLootData.SlotData slotData = AutoLootData.Slots[i];
		GUI.color = new Color(0.06f, 0.06f, 0.06f, 1f);
		GUI.DrawTexture(new Rect(0f, num, 940f, 62f), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(new Rect(0f, num, 940f, 62f), new Color(0.25f, 0.25f, 0.25f, 1f), 1f);
		GUIStyle val = new GUIStyle
		{
			fontSize = 15,
			fontStyle = (FontStyle)1
		};
		val.normal.textColor = Color.white;
		val.alignment = (TextAnchor)4;
		GUIStyle val2 = val;
		GUI.Label(new Rect(0f, num, 50f, 62f), $"{i + 1}", val2);
		GUIStyle val3 = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13,
			fontStyle = (FontStyle)1
		};
		val3.normal.textColor = Color.white;
		GUIStyle val4 = val3;
		GUI.enabled = activeSlotIndex < 0 && activeItemSlotIndex < 0;
		string text = (string.IsNullOrEmpty(slotData.CategoryKey) ? Loc.Get("RPG.UI.AL_CATEGORY") : slotData.CategoryKey);
		if (GUI.Button(new Rect(60f, num + 12f, 250f, 36f), text, val4))
		{
			onCategoryClick?.Invoke(i);
		}
		GUI.enabled = !string.IsNullOrEmpty(slotData.CategoryKey) && activeSlotIndex < 0 && activeItemSlotIndex < 0;
		string text2 = (string.IsNullOrEmpty(slotData.ItemKey) ? Loc.Get("RPG.UI.AL_ITEM") : AutoLootData.GetDisplayName(slotData.ItemKey));
		if (GUI.Button(new Rect(320f, num + 12f, 380f, 36f), text2, val4))
		{
			onItemClick?.Invoke(i);
		}
		GUI.enabled = true;
		GUI.enabled = !string.IsNullOrEmpty(slotData.ItemKey) && activeSlotIndex < 0 && activeItemSlotIndex < 0;
		GUI.color = (Color)(slotData.IsOn ? Color.green : new Color(0.4f, 0.4f, 0.4f, 1f));
		if (GUI.Button(new Rect(712f, num + 12f, 100f, 36f), slotData.IsOn ? "ON" : "OFF"))
		{
			onToggle?.Invoke(i);
		}
		GUI.color = Color.white;
		GUI.enabled = true;
		GUI.enabled = activeSlotIndex < 0 && activeItemSlotIndex < 0;
		if (GUI.Button(new Rect(822f, num + 12f, 110f, 36f), Loc.Get("RPG.UI.BTN_RESET_SHORT"), val4))
		{
			onReset?.Invoke(i);
		}
		GUI.enabled = true;
	}

	public static void DrawCategoryDropdown(int slotIndex, int activeSlotIndex, float scrollOffsetY, Action<int, string> onSelect)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)slotIndex * 70f - scrollOffsetY + 136f;
		float num2 = (float)categoryKeys.Count * 34f;
		GUI.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		GUI.DrawTexture(new Rect(60f, num + 62f, 250f, num2), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(new Rect(60f, num + 62f, 250f, num2), new Color(0.5f, 0.5f, 0.5f, 1f), 1f);
		GUIStyle val = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13
		};
		val.normal.textColor = Color.white;
		val.alignment = (TextAnchor)3;
		GUIStyle val2 = val;
		for (int i = 0; i < categoryKeys.Count; i++)
		{
			if (GUI.Button(new Rect(62f, num + 62f + (float)(i * 34), 246f, 32f), "  " + categoryKeys[i], val2))
			{
				onSelect?.Invoke(slotIndex, categoryKeys[i]);
			}
		}
	}

	public static void DrawItemDropdown(int slotIndex, float scrollOffsetY, Action<int, string> onSelect)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		AutoLootData.SlotData slotData = AutoLootData.Slots[slotIndex];
		if (string.IsNullOrEmpty(slotData.CategoryKey) || !AutoLootData.Categories.ContainsKey(slotData.CategoryKey))
		{
			return;
		}
		List<string> list = AutoLootData.Categories[slotData.CategoryKey];
		if (list.Count == 0)
		{
			return;
		}
		float num = (float)slotIndex * 70f - scrollOffsetY + 136f;
		float num2 = (float)list.Count * 34f;
		GUI.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		GUI.DrawTexture(new Rect(320f, num + 62f, 380f, num2), (Texture)(object)Texture2D.whiteTexture);
		GUI.color = Color.white;
		DrawingUtils.DrawRectOutline(new Rect(320f, num + 62f, 380f, num2), new Color(0.5f, 0.5f, 0.5f, 1f), 1f);
		GUIStyle val = new GUIStyle(GUI.skin.button)
		{
			fontSize = 13
		};
		val.normal.textColor = Color.white;
		val.alignment = (TextAnchor)3;
		GUIStyle val2 = val;
		for (int i = 0; i < list.Count; i++)
		{
			string displayName = AutoLootData.GetDisplayName(list[i]);
			if (GUI.Button(new Rect(322f, num + 62f + (float)(i * 34), 376f, 32f), "  " + displayName, val2))
			{
				onSelect?.Invoke(slotIndex, list[i]);
			}
		}
	}
}
