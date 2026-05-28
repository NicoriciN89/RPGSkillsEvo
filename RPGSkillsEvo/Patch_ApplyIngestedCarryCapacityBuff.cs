using HarmonyLib;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerManager), "ApplyIngestedCarryCapacityBuff")]
internal static class Patch_ApplyIngestedCarryCapacityBuff
{
	private static void Postfix(PlayerManager __instance)
	{
		List<PlayerManager.IngestedCarryCapacityBuff> ingestedCarryCapacityBuffList = __instance.m_IngestedCarryCapacityBuffList;
		if (ingestedCarryCapacityBuffList != null && ingestedCarryCapacityBuffList.Count != 0)
		{
			float num = 1f + Status.GetBuffDuration();
			PlayerManager.IngestedCarryCapacityBuff val = ingestedCarryCapacityBuffList[ingestedCarryCapacityBuffList.Count - 1];
			val.m_HoursRemaining *= num;
			val.m_HoursDuration *= num;
			ingestedCarryCapacityBuffList.Clear();
			ingestedCarryCapacityBuffList.Add(val);
		}
	}
}
