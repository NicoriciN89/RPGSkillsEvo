using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(GameManager), "OnDestroy")]
internal static class Patch_StatsHUD_GameManager
{
	private static void Postfix()
	{
		StatsHUDRenderer.ResetLabels();
	}
}
