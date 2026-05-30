using HarmonyLib;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerManager), "ApplyIngestedCarryCapacityBuff")]
internal static class Patch_ApplyIngestedCarryCapacityBuff
{
	private static void Postfix(PlayerManager __instance)
	{
		List<PlayerManager.IngestedCarryCapacityBuff> list = __instance.m_IngestedCarryCapacityBuffList;
		if (list == null || list.Count == 0) return;
		float mult = 1f + Status.GetBuffDuration();
		if (mult <= 1f) return;
		for (int i = 0; i < list.Count; i++)
		{
			PlayerManager.IngestedCarryCapacityBuff buff = list[i];
			buff.m_HoursRemaining *= mult;
			buff.m_HoursDuration *= mult;
			list[i] = buff;
		}
	}
}
