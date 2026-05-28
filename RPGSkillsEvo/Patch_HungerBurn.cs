using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Hunger), "UpdateCalorieReserves")]
internal static class Patch_HungerBurn
{
	private static void Prefix(Hunger __instance)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float hungerReduction = HungerManager.GetHungerReduction();
			if (!(hungerReduction <= 0f))
			{
				__instance.m_CurrentCalorieBurnPerHour *= 1f - hungerReduction;
			}
		}
	}
}
