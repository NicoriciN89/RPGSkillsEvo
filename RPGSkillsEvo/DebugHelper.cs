using MelonLoader;
using UnityEngine;

namespace RPGSkillsEvo;

public static class DebugHelper
{
	public static bool isDebugUnlocked;

	public static void OnUpdate()
	{
		// LCtrl + LShift + Space  →  toggle debug mode
		if (Input.GetKey((KeyCode)306) && Input.GetKey((KeyCode)304) && Input.GetKeyDown((KeyCode)32))
		{
			isDebugUnlocked = !isDebugUnlocked;
			MelonLogger.Msg(isDebugUnlocked ? "[Debug] ON" : "[Debug] OFF");
		}
		if (!isDebugUnlocked) return;

		// F3  →  +1000 XP
		if (Input.GetKeyDown((KeyCode)284))
		{
			PlayerLevel.AddXP(1000f);
			MelonLogger.Msg("[Debug] +1000 XP  (Level=" + PlayerLevel.Level + "  XP=" + PlayerLevel.CurrentXP + ")");
		}
		// F4  →  +10 skill points directly
		if (Input.GetKeyDown((KeyCode)285))
		{
			PlayerLevel.SkillPoints += 10;
			NodeManager.tPoints += 10;
			MelonLogger.Msg("[Debug] +10 SP  (SP=" + PlayerLevel.SkillPoints + "  tPoints=" + NodeManager.tPoints + ")");
		}
		// F5  →  +1 skill point
		if (Input.GetKeyDown((KeyCode)286))
		{
			PlayerLevel.SkillPoints += 1;
			NodeManager.tPoints += 1;
			MelonLogger.Msg("[Debug] +1 SP  (SP=" + PlayerLevel.SkillPoints + "  tPoints=" + NodeManager.tPoints + ")");
		}
		// E  →  debug scan
		if (Input.GetKeyDown((KeyCode)101))
		{
			DebugScanManager.TriggerScan();
		}
	}
}
