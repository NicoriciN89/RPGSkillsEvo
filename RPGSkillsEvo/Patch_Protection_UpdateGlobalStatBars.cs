using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Panel_Clothing), "UpdateGlobalStatBars")]
internal static class Patch_Protection_UpdateGlobalStatBars
{
	private static int s_lastApplied = 0;

	private static void Postfix(Panel_Clothing __instance)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive())
		{
			s_lastApplied = 0;
			return;
		}
		float protectionBonus = Status.GetProtectionBonus();
		UILabel totalToughnessLabel = __instance.m_TotalToughnessLabel;
		if ((UnityEngine.Object)(object)totalToughnessLabel == (UnityEngine.Object)null)
			return;
		if (!int.TryParse(totalToughnessLabel.text.Replace("%", "").Trim(), out int current))
			return;
		// Subtract what we added last call to recover the game's base value, then add fresh bonus
		int baseValue = current - s_lastApplied;
		s_lastApplied = protectionBonus > 0f ? Mathf.RoundToInt(protectionBonus * 100f) : 0;
		if (s_lastApplied != 0)
			totalToughnessLabel.text = $"{baseValue + s_lastApplied}%";
	}
}
