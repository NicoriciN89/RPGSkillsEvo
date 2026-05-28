using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Thirst), "UpdateThirstStatusOnHUD")]
internal static class Patch_MaxThirst_Vitality
{
	private static void Postfix(Thirst __instance)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			MaxConditionManager.ApplyThirst(__instance);
		}
	}
}
