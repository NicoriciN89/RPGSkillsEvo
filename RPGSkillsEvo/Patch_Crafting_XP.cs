using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Panel_Crafting), "OnCraftingSuccess")]
internal static class Patch_Crafting_XP
{
	private static void Postfix()
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			PlayerLevel.AddXP(Settings.XpPerSkill * 2f);
		}
	}
}
