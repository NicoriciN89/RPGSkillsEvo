using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerMovement), "GetWindMovementMultiplier")]
internal static class Patch_WindResist
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive())
		{
			float windResist = Status.GetWindResist();
			if (!(windResist <= 0f))
			{
				__result += (1f - __result) * windResist;
			}
		}
	}
}
