using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(SaveGameSystem), "RestoreGlobalData")]
internal class Patch_EvoRestore
{
	private static void Postfix(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			EvoSaveManager.Load(name);
		}
		else
		{
			EvoSaveManager.ResetToDefaults();
		}
	}
}
