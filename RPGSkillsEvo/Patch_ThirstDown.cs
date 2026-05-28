using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Thirst), "AddThirst")]
internal static class Patch_ThirstDown
{
	private static void Prefix(ref float thirstValue)
	{
		if (thirstValue <= 0f) return;
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive()) return;
		float reduction = Status.GetThirstDown();
		if (reduction > 0f)
			thirstValue *= 1f - reduction;
	}
}
