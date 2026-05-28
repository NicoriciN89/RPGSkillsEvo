using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(CookingPotItem), "PickUpCookedGearItem")]
internal static class Patch_Cooking_XP_MaxLevel
{
	private static void Postfix(CookingPotItem __instance)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			if (ActivityXPFlag.CookingAwarded)
			{
				ActivityXPFlag.CookingAwarded = false;
			}
			else if ((UnityEngine.Object)(object)__instance.m_GearItemBeingCooked != (UnityEngine.Object)null
				&& __instance.m_MinutesUntilCooked <= 0f)
			{
				PlayerLevel.AddXP(Settings.XpPerSkill);
			}
		}
	}
}
