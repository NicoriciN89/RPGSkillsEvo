using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(vp_FPSController), "GetSlopeMultiplier")]
internal class Patch_GunZoom_Speed
{
	private static void Postfix(ref float __result)
	{
		if (!GameManager.IsMainMenuActive() && !GameManager.IsEmptySceneActive() && GunZoomManager.isRevolver && GunZoomManager.isZooming && GunZoomManager.IsRevolverAimMoveUnlocked())
		{
			__result *= 0.9f;
		}
	}
}
