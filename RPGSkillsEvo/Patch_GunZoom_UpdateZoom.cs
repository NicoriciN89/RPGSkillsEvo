using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(vp_FPSCamera), "UpdateZoom")]
internal class Patch_GunZoom_UpdateZoom
{
	private static bool Prefix()
	{
		bool flag = GunZoomManager.isRifle && GunZoomManager.IsRifleZoomUnlocked();
		bool flag2 = GunZoomManager.isRevolver && GunZoomManager.IsRevolverZoomUnlocked();
		if (flag || flag2)
		{
			return false;
		}
		return true;
	}
}
