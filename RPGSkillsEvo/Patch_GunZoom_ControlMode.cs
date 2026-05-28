using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(PlayerManager), "SetControlMode")]
internal class Patch_GunZoom_ControlMode
{
	private static void Prefix(ref PlayerControlMode mode)
	{
		if ((int)mode == 18 && GunZoomManager.IsRevolverAimMoveUnlocked())
		{
			mode = (PlayerControlMode)0;
		}
	}
}
