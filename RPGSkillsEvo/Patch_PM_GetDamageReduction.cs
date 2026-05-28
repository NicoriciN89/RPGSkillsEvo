using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerManager), "GetDamageReductionFromExteriorClothing")]
internal static class Patch_PM_GetDamageReduction
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float protectionBonus = Status.GetProtectionBonus();
			if (!(protectionBonus <= 0f))
			{
				__result = Mathf.Max(0.01f, __result - protectionBonus);
			}
		}
	}
}
