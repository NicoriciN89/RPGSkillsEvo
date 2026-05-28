using Il2Cpp;
using Il2CppTLD.IntBackedUnit;
using UnityEngine;

namespace RPGSkillsEvo;

public static class WeightManager
{
	public static void UpdateFromEvo()
	{
		Encumber encumberComponent = GameManager.GetEncumberComponent();
		if ((UnityEngine.Object)(object)encumberComponent != (UnityEngine.Object)null)
		{
			ApplyToComponent(encumberComponent);
		}
	}

	public static void ApplyToComponent(Encumber enc)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		if ((UnityEngine.Object)(object)enc != (UnityEngine.Object)null)
		{
			float weightBonus = Status.GetWeightBonus();
			float weightDownPenalty = Status.GetWeightDownPenalty();
			float num = weightBonus - weightDownPenalty;
			enc.m_MaxCarryCapacity = ItemWeight.FromKilograms(30f + num);
			enc.m_MaxCarryCapacityWhenExhausted = ItemWeight.FromKilograms(15f + num);
			enc.m_NoSprintCarryCapacity = ItemWeight.FromKilograms(40f + num);
			enc.m_NoWalkCarryCapacity = ItemWeight.FromKilograms(60f + num);
			enc.m_EncumberLowThreshold = ItemWeight.FromKilograms(31f + num);
			enc.m_EncumberMedThreshold = ItemWeight.FromKilograms(40f + num);
			enc.m_EncumberHighThreshold = ItemWeight.FromKilograms(60f + num);
		}
	}
}
