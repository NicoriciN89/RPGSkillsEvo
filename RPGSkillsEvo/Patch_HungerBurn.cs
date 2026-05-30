using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Hunger), "UpdateCalorieReserves")]
internal static class Patch_HungerBurn
{
	private static float s_originalBurnRate;

	private static void Prefix(Hunger __instance)
	{
		s_originalBurnRate = __instance.m_CurrentCalorieBurnPerHour;
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float hungerReduction = HungerManager.GetHungerReduction();
			if (hungerReduction > 0f)
				__instance.m_CurrentCalorieBurnPerHour *= 1f - hungerReduction;
		}
	}

	private static void Postfix(Hunger __instance)
	{
		__instance.m_CurrentCalorieBurnPerHour = s_originalBurnRate;
	}
}
