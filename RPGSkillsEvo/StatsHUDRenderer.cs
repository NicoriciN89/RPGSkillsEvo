using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

public static class StatsHUDRenderer
{
	private static Condition cachedCondition;

	private static Fatigue cachedFatigue;

	private static Thirst cachedThirst;

	private static Hunger cachedHunger;

	private static Freezing cachedFreezing;

	private static UILabel labelHP;

	private static UILabel labelCold;

	private static UILabel labelFatigue;

	private static UILabel labelThirst;

	private static UILabel labelHunger;

	private static float lastHP = -1f;

	private static float lastMaxHP = -1f;

	private static float lastTemp = -999f;

	private static float lastFatigue = -1f;

	private static float lastThirst = -1f;

	private static float lastCalorie = -1f;

	private static float refreshTimer = 0f;

	private const float RefreshInterval = 0.1f;

	private static bool IsStatsHUDUnlocked()
	{
		int num = (DataHub.RealNodes.ContainsKey("WS5") ? DataHub.RealNodes["WS5"] : 0);
		return num > 0;
	}

	public static void OnUpdate()
	{
		if (!IsStatsHUDUnlocked())
		{
			return;
		}
		refreshTimer += Time.deltaTime;
		if (refreshTimer < 0.1f)
		{
			return;
		}
		refreshTimer = 0f;
		try
		{
			if ((UnityEngine.Object)(object)cachedCondition == (UnityEngine.Object)null || !((Behaviour)cachedCondition).isActiveAndEnabled)
			{
				cachedCondition = Object.FindObjectOfType<Condition>();
				ResetCache();
			}
			if ((UnityEngine.Object)(object)cachedFatigue == (UnityEngine.Object)null || !((Behaviour)cachedFatigue).isActiveAndEnabled)
			{
				cachedFatigue = Object.FindObjectOfType<Fatigue>();
			}
			if ((UnityEngine.Object)(object)cachedThirst == (UnityEngine.Object)null || !((Behaviour)cachedThirst).isActiveAndEnabled)
			{
				cachedThirst = Object.FindObjectOfType<Thirst>();
			}
			if ((UnityEngine.Object)(object)cachedHunger == (UnityEngine.Object)null || !((Behaviour)cachedHunger).isActiveAndEnabled)
			{
				cachedHunger = Object.FindObjectOfType<Hunger>();
			}
			if ((UnityEngine.Object)(object)cachedFreezing == (UnityEngine.Object)null || !((Behaviour)cachedFreezing).isActiveAndEnabled)
			{
				cachedFreezing = Object.FindObjectOfType<Freezing>();
			}
		}
		catch
		{
		}
		SyncLabelVisibility();
		UpdateLabels();
	}

	private static void SyncLabelVisibility()
	{
		bool show = Settings.ShowHUDNumbers;
		SetLabelVisible(labelHP, show);
		SetLabelVisible(labelCold, show);
		SetLabelVisible(labelFatigue, show);
		SetLabelVisible(labelThirst, show);
		SetLabelVisible(labelHunger, show);
	}

	private static void SetLabelVisible(UILabel label, bool visible)
	{
		if ((UnityEngine.Object)(object)label != (UnityEngine.Object)null)
		{
			((Component)label).gameObject.SetActive(visible);
		}
	}

	private static void ResetCache()
	{
		lastHP = -1f;
		lastMaxHP = -1f;
		lastTemp = -999f;
		lastFatigue = -1f;
		lastThirst = -1f;
		lastCalorie = -1f;
	}

	private static bool IsLabelAlive(UILabel label)
	{
		if ((UnityEngine.Object)(object)label == (UnityEngine.Object)null)
		{
			return false;
		}
		try
		{
			return ((Behaviour)label).isActiveAndEnabled;
		}
		catch
		{
			return false;
		}
	}

	private static void UpdateLabels()
	{
		if ((UnityEngine.Object)(object)cachedCondition != (UnityEngine.Object)null && IsLabelAlive(labelHP))
		{
			float currentHP = cachedCondition.m_CurrentHP;
			float adjustedMaxHP = cachedCondition.GetAdjustedMaxHP();
			if (currentHP != lastHP || adjustedMaxHP != lastMaxHP)
			{
				labelHP.text = $"{currentHP:F1} / {adjustedMaxHP:F1}";
				lastHP = currentHP;
				lastMaxHP = adjustedMaxHP;
			}
		}
		if ((UnityEngine.Object)(object)cachedFreezing != (UnityEngine.Object)null && IsLabelAlive(labelCold))
		{
			float num = cachedFreezing.CalculateBodyTemperature();
			if (num != lastTemp)
			{
				labelCold.text = $"{num:F1}°";
				lastTemp = num;
			}
		}
		if ((UnityEngine.Object)(object)cachedFatigue != (UnityEngine.Object)null && IsLabelAlive(labelFatigue))
		{
			float num2 = cachedFatigue.m_MaxFatigue - cachedFatigue.m_CurrentFatigue;
			if (num2 != lastFatigue)
			{
				labelFatigue.text = $"{num2:F0}";
				lastFatigue = num2;
			}
		}
		if ((UnityEngine.Object)(object)cachedThirst != (UnityEngine.Object)null && IsLabelAlive(labelThirst))
		{
			float num3 = cachedThirst.m_MaxThirst - cachedThirst.m_CurrentThirst;
			if (num3 != lastThirst)
			{
				labelThirst.text = $"{num3:F0}";
				lastThirst = num3;
			}
		}
		if ((UnityEngine.Object)(object)cachedHunger != (UnityEngine.Object)null && IsLabelAlive(labelHunger))
		{
			float currentReserveCalories = cachedHunger.m_CurrentReserveCalories;
			if (currentReserveCalories != lastCalorie)
			{
				labelHunger.text = $"{currentReserveCalories:F0}";
				lastCalorie = currentReserveCalories;
			}
		}
	}

	private static UILabel CreateLabel(Transform parent, Vector3 localPos, int fontSize, bool isHP = false)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("StatsHUD_Label");
		val.transform.SetParent(parent, false);
		val.transform.localPosition = localPos;
		val.transform.localScale = Vector3.one;
		UILabel val2 = val.AddComponent<UILabel>();
		FontManager fontManager = GameManager.GetFontManager();
		if ((UnityEngine.Object)(object)fontManager != (UnityEngine.Object)null)
		{
			val2.font = fontManager.GetUIFontForCharacterSet((CharacterSet)0);
		}
		val2.fontSize = fontSize;
		val2.fontStyle = (FontStyle)(isHP ? 1 : 0);
		((UIWidget)val2).color = new Color(1f, 1f, 1f, 1f);
		val2.effectStyle = (UILabel.Effect)2;
		val2.effectColor = new Color(0f, 0f, 0f, 0.9f);
		val2.effectDistance = new Vector2(2f, 2f);
		val2.alignment = (NGUIText.Alignment)2;
		val2.overflowMethod = (UILabel.Overflow)0;
		((UIWidget)val2).width = (isHP ? 160 : 100);
		if (isHP)
		{
			val2.spacingX = 3;
		}
		return val2;
	}

	public static void EnsureLabel(StatusBar statusBar)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		if (!IsStatsHUDUnlocked() || !statusBar.m_IsOnHUD || (UnityEngine.Object)(object)statusBar.m_OuterBoxSprite == (UnityEngine.Object)null)
		{
			return;
		}
		Transform parent = ((Component)statusBar.m_OuterBoxSprite).transform.parent;
		if ((UnityEngine.Object)(object)parent == (UnityEngine.Object)null)
		{
			return;
		}
		StatusBar.StatusBarType statusBarType = statusBar.m_StatusBarType;
		StatusBar.StatusBarType val = statusBarType;
		switch ((int)val)
		{
		case 4:
			if ((UnityEngine.Object)(object)labelHP == (UnityEngine.Object)null)
			{
				labelHP = CreateLabel(parent, new Vector3(75f, -29f, 0f), 22, isHP: true);
			}
			break;
		case 0:
			if ((UnityEngine.Object)(object)labelCold == (UnityEngine.Object)null)
			{
				labelCold = CreateLabel(parent, new Vector3(0f, -45f, 0f), 22);
			}
			break;
		case 3:
			if ((UnityEngine.Object)(object)labelFatigue == (UnityEngine.Object)null)
			{
				labelFatigue = CreateLabel(parent, new Vector3(0f, -45f, 0f), 22);
			}
			break;
		case 2:
			if ((UnityEngine.Object)(object)labelThirst == (UnityEngine.Object)null)
			{
				labelThirst = CreateLabel(parent, new Vector3(0f, -45f, 0f), 22);
			}
			break;
		case 1:
			if ((UnityEngine.Object)(object)labelHunger == (UnityEngine.Object)null)
			{
				labelHunger = CreateLabel(parent, new Vector3(0f, -45f, 0f), 22);
			}
			break;
		}
	}

	public static void ResetLabels()
	{
		try
		{
			if ((UnityEngine.Object)(object)labelHP != (UnityEngine.Object)null)
			{
				Object.Destroy((UnityEngine.Object)(object)((Component)labelHP).gameObject);
			}
		}
		catch
		{
		}
		try
		{
			if ((UnityEngine.Object)(object)labelCold != (UnityEngine.Object)null)
			{
				Object.Destroy((UnityEngine.Object)(object)((Component)labelCold).gameObject);
			}
		}
		catch
		{
		}
		try
		{
			if ((UnityEngine.Object)(object)labelFatigue != (UnityEngine.Object)null)
			{
				Object.Destroy((UnityEngine.Object)(object)((Component)labelFatigue).gameObject);
			}
		}
		catch
		{
		}
		try
		{
			if ((UnityEngine.Object)(object)labelThirst != (UnityEngine.Object)null)
			{
				Object.Destroy((UnityEngine.Object)(object)((Component)labelThirst).gameObject);
			}
		}
		catch
		{
		}
		try
		{
			if ((UnityEngine.Object)(object)labelHunger != (UnityEngine.Object)null)
			{
				Object.Destroy((UnityEngine.Object)(object)((Component)labelHunger).gameObject);
			}
		}
		catch
		{
		}
		labelHP = null;
		labelCold = null;
		labelFatigue = null;
		labelThirst = null;
		labelHunger = null;
		ResetCache();
	}
}
