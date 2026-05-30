using Il2Cpp;

namespace RPGSkillsEvo;

public static class MaxConditionManager
{
	private const float BASE_FATIGUE = 100f;

	private const float BASE_THIRST = 100f;

	public static float GetVitalityBonus()
	{
		return Status.GetVitalityBonus();
	}

	public static float GetVitalityDownPenalty()
	{
		return Status.GetVitalityDownPenalty();
	}

	public static void ResetBase()
	{
	}

	public static void ApplyFatigue(Fatigue instance)
	{
		float target = 100f + GetVitalityBonus() - GetVitalityDownPenalty();
		if (instance.m_MaxFatigue != target)
			instance.m_MaxFatigue = target;
	}

	public static void ApplyThirst(Thirst instance)
	{
		float target = 100f + GetVitalityBonus() - GetVitalityDownPenalty();
		if (instance.m_MaxThirst != target)
			instance.m_MaxThirst = target;
	}
}
