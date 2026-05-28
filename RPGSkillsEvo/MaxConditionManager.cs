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
		float num = GetVitalityBonus() - GetVitalityDownPenalty();
		if (num != 0f)
		{
			float num2 = 100f + num;
			if (instance.m_MaxFatigue != num2)
			{
				instance.m_MaxFatigue = num2;
			}
		}
	}

	public static void ApplyThirst(Thirst instance)
	{
		float num = GetVitalityBonus() - GetVitalityDownPenalty();
		if (num != 0f)
		{
			float num2 = 100f + num;
			if (instance.m_MaxThirst != num2)
			{
				instance.m_MaxThirst = num2;
			}
		}
	}
}
