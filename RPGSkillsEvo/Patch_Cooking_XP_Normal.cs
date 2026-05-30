using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

// Awards XP for any vanilla skill increment (cooking, fire, fishing, repair, first aid, archery, etc.)
[HarmonyPatch(typeof(SkillsManager), "IncrementPointsAndNotify")]
internal static class Patch_Cooking_XP_Normal
{
	private static void Postfix(SkillType skillType)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			if (skillType == SkillType.Cooking)
				ActivityXPFlag.CookingAwarded = true;
			PlayerLevel.AddXP(Settings.XpPerSkill);
		}
	}
}
