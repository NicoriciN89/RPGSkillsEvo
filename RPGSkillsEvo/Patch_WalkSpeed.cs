using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(vp_FPSController), "GetSlopeMultiplier")]
internal static class Patch_WalkSpeed
{
	private static void Postfix(ref float __result)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive())
		{
			return;
		}
		PlayerManager playerManagerComponent = GameManager.GetPlayerManagerComponent();
		if ((UnityEngine.Object)(object)playerManagerComponent != (UnityEngine.Object)null)
		{
			float num = (playerManagerComponent.PlayerIsSprinting() ? Status.GetSprintSpeedBonus() : ((!playerManagerComponent.PlayerIsCrouched()) ? Status.GetWalkSpeedBonus() : Status.GetCrouchSpeedBonus()));
			float speedPenalty = Status.GetSpeedPenalty();
			float num2 = 1f + num - speedPenalty;
			if (num2 < 0.1f)
			{
				num2 = 0.1f;
			}
			__result *= num2;
		}
	}
}
