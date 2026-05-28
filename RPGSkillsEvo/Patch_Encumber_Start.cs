using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Encumber), "Start")]
internal static class Patch_Encumber_Start
{
	private static void Postfix(Encumber __instance)
	{
		if ((UnityEngine.Object)(object)__instance != (UnityEngine.Object)null && !GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			WeightManager.ApplyToComponent(__instance);
		}
	}
}
