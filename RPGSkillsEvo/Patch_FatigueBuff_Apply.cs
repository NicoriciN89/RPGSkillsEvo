using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(FatigueBuff), "Apply")]
internal static class Patch_FatigueBuff_Apply
{
	private static void Postfix(FatigueBuff __instance)
	{
		PlayerManager playerManager = GameManager.m_PlayerManager;
		if ((UnityEngine.Object)(object)playerManager != (UnityEngine.Object)null)
		{
			float modifiedDuration = __instance.m_DurationHours * (1f + Status.GetBuffDuration());
			playerManager.m_FatigueBuffHoursRemaining = modifiedDuration;
			playerManager.m_FatigueBuffHoursDuration = modifiedDuration;
		}
	}
}
