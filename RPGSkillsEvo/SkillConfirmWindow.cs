using System;
using UnityEngine;

namespace RPGSkillsEvo;

public static class SkillConfirmWindow
{
	public static void Draw(int id, bool isApplyMode, Action onApply, Action onCancel, Action onSave, Action onDiscard)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		DrawingUtils.Draw3DBox(new Rect(0f, 0f, UILayout.confirmRect.width, UILayout.confirmRect.height), new Color(0.1f, 0.1f, 0.1f, 1f), 1f, isActive: false, isHovered: false);
		GUIStyle val = new GUIStyle
		{
			alignment = (TextAnchor)4,
			fontSize = 15,
			wordWrap = true
		};
		val.normal.textColor = Color.white;
		GUIStyle val2 = val;
		if (isApplyMode)
		{
			GUI.Label(new Rect(10f, 30f, 380f, 80f), Loc.Get("RPG.CONFIRM.APPLY_BODY"), val2);
			if (GUI.Button(new Rect(50f, 130f, 140f, 40f), Loc.Get("RPG.CONFIRM.YES")))
			{
				onApply?.Invoke();
			}
			if (GUI.Button(new Rect(210f, 130f, 140f, 40f), Loc.Get("RPG.CONFIRM.NO")))
			{
				onCancel?.Invoke();
			}
		}
		else
		{
			GUI.Label(new Rect(10f, 20f, 380f, 90f), Loc.Get("RPG.CONFIRM.UNSAVED_BODY"), val2);
			if (GUI.Button(new Rect(50f, 130f, 140f, 40f), Loc.Get("RPG.CONFIRM.SAVE")))
			{
				onSave?.Invoke();
			}
			if (GUI.Button(new Rect(210f, 130f, 140f, 40f), Loc.Get("RPG.CONFIRM.DISCARD")))
			{
				onDiscard?.Invoke();
			}
		}
	}
}
