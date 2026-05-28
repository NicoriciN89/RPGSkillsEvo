using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(IceFishingHole), "RollNextCatch")]
internal static class Patch_FishingBonus
{
	private static void Postfix(IceFishingHole __instance)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetFishingBonus();
		if (bonus <= 0f) return;
		var nextCatch = __instance.m_NextCatch;
		if (nextCatch == null) return;
		nextCatch.m_FishWeightScale *= 1f + bonus;
	}
}
