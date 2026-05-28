using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerMovement), "GetMaxSprintStaminaModifier")]
internal static class Patch_SprintStamina
{
	private static void Postfix(ref float __result)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetSprintStamina();
		if (bonus > 0f)
			__result += bonus;
	}
}
