using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Panel_Clothing), "UpdateGlobalStatBars")]
internal static class Patch_Protection_UpdateGlobalStatBars
{
	private static void Postfix(Panel_Clothing __instance)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive())
		{
			return;
		}
		float protectionBonus = Status.GetProtectionBonus();
		if (!(protectionBonus <= 0f))
		{
			UILabel totalToughnessLabel = __instance.m_TotalToughnessLabel;
			if ((UnityEngine.Object)(object)totalToughnessLabel != (UnityEngine.Object)null && int.TryParse(totalToughnessLabel.text.Replace("%", "").Trim(), out var result))
			{
				int num = Mathf.RoundToInt(protectionBonus * 100f);
				totalToughnessLabel.text = $"{result + num}%";
			}
		}
	}
}
