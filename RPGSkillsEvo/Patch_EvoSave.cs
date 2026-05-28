using HarmonyLib;
using Il2Cpp;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(SaveGameSystem), "SaveGlobalData")]
internal class Patch_EvoSave
{
	private static void Postfix(SlotData slot)
	{
		string text = EvoSaveManager.ResolveSlotName(slot);
		if (!string.IsNullOrEmpty(text))
		{
			EvoSaveManager.Save(text);
		}
	}
}
