using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(ExperienceMode), "GetRepairTimeScale")]
internal static class Patch_CraftSpeed
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float bonus = Status.GetCraftSpeed();
			if (bonus > 0f)
				__result *= 1f - bonus;
		}
	}
}
