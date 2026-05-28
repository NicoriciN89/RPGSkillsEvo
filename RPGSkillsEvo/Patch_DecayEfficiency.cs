using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(GearItem), "DecayOverTODHours")]
internal static class Patch_DecayEfficiency
{
	private static void Prefix(GearItem __instance, ref float scale)
	{
		if (__instance.m_InPlayerInventory && !(__instance.m_DecayScalar <= 0f))
		{
			float decayEfficiency = Status.GetDecayEfficiency();
			if (!(decayEfficiency <= 0f))
			{
				scale *= 1f - decayEfficiency;
			}
		}
	}
}
