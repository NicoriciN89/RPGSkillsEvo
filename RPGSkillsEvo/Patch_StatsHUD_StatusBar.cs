using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(StatusBar), "Update")]
internal static class Patch_StatsHUD_StatusBar
{
	private static void Postfix(StatusBar __instance)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive() && !GameManager.m_IsPaused && !InterfaceManager.DetermineIfOverlayIsActive())
		{
			StatsHUDRenderer.EnsureLabel(__instance);
		}
	}
}
