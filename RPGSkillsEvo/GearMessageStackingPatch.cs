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
		if (!pickupCounts.ContainsKey(text))
		{
			pickupCounts[text] = 0;
		}
		pickupCounts[text]++;
		int num = (pickupCounts[text] + 1) / 2;
		for (int i = 0; i < gearMessageQueue.Count; i++)
		{
			GearMessage.GearMessageInfo val = gearMessageQueue[i];
			if (val != null && val.m_Text != null && val.m_Text.StartsWith(text))
			{
				val.m_Text = ((num > 1) ? $"{text} x{num}" : text);
				val.m_DisplayTime = 2f;
				return false;
			}
		}
		if (num > 1)
		{
			newGearMessage.m_Text = $"{text} x{num}";
		}
		return true;
	}
}
