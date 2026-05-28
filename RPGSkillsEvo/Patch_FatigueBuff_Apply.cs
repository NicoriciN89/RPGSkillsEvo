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
			float num = 1f + Status.GetBuffDuration();
			float fatigueBuffHoursDuration = (playerManager.m_FatigueBuffHoursRemaining = (__instance.m_DurationHours *= num));
			playerManager.m_FatigueBuffHoursDuration = fatigueBuffHoursDuration;
		}
	}
}
