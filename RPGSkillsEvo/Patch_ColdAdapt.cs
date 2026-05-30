using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

// Reduces HP damage from freezing by ColdAdapt (up to 50%).
// Mirrors Patch_BleedResist but targets DamageSource.Freezing.
[HarmonyPatch(typeof(Condition), "AddHealth", typeof(float), typeof(DamageSource), typeof(bool))]
internal static class Patch_ColdAdapt
{
	private static void Prefix(ref float hp, DamageSource cause)
	{
		if (hp >= 0f || cause != DamageSource.Freezing) return;
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetColdAdapt();
		if (bonus > 0f)
			hp *= 1f - bonus;
	}
}
