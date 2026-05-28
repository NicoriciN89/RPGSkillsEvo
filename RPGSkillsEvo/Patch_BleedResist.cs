using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Condition), "AddHealth", typeof(float), typeof(DamageSource), typeof(bool))]
internal static class Patch_BleedResist
{
	private static void Prefix(ref float hp, DamageSource cause)
	{
		if (hp >= 0f || cause != DamageSource.BloodLoss) return;
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float bonus = Status.GetBleedResist();
		if (bonus > 0f)
			hp *= 1f - bonus;
	}
}
