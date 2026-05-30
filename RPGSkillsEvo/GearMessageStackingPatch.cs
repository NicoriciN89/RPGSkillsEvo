using HarmonyLib;
using Il2Cpp;
using Il2CppSystem.Collections.Generic;
using NativeDict = System.Collections.Generic.Dictionary<string, int>;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(GearMessage), "AddMessageToQueue")]
public static class GearMessageStackingPatch
{
	private static NativeDict pickupCounts = new NativeDict();

	public static void ClearCounts()
	{
		pickupCounts.Clear();
	}

	[HarmonyPrefix]
	public static bool Prefix(Panel_HUD hud, GearMessage.GearMessageInfo newGearMessage)
	{
		if (newGearMessage == null)
		{
			return true;
		}
		string text = newGearMessage.m_Text;
		List<GearMessage.GearMessageInfo> gearMessageQueue = GearMessage.m_GearMessageQueue;
		if (gearMessageQueue == null)
		{
			return true;
		}
		// Find existing visible message for this text
		GearMessage.GearMessageInfo existing = null;
		for (int i = 0; i < gearMessageQueue.Count; i++)
		{
			GearMessage.GearMessageInfo val = gearMessageQueue[i];
			if (val != null && val.m_Text != null && val.m_Text.StartsWith(text))
			{
				existing = val;
				break;
			}
		}
		// No visible message means previous batch expired — start a fresh count
		if (existing == null || !pickupCounts.ContainsKey(text))
		{
			pickupCounts[text] = 0;
		}
		pickupCounts[text]++;
		int count = pickupCounts[text];
		if (existing != null)
		{
			existing.m_Text = count > 1 ? $"{text} x{count}" : text;
			existing.m_DisplayTime = 2f;
			return false;
		}
		if (count > 1)
		{
			newGearMessage.m_Text = $"{text} x{count}";
		}
		return true;
	}
}
