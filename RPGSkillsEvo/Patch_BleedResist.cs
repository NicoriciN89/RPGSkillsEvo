using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(ExperienceMode), "GetBleedOutTimeScale")]
internal static class Patch_BleedResist
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float bonus = Status.GetBleedResist();
			if (bonus > 0f)
				__result *= 1f + bonus;
		}
	}
}
