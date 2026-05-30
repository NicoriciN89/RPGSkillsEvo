using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MelonLoader;
using MelonLoader.Utils;

namespace RPGSkillsEvo;

public static class AutoLootUserCustom
{
	private static readonly HashSet<string> customLootSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private static readonly string filePath = Path.Combine(MelonEnvironment.UserDataDirectory, "RPGSkillsEvo_AutoLootCustomList.txt");

	public static void Refresh()
	{
		customLootSet.Clear();
		if (!File.Exists(filePath))
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("# RPG Skills Evo - Auto Loot Custom Item List");
				stringBuilder.AppendLine("# Enter one item name per line.");
				stringBuilder.AppendLine("# The GEAR_ prefix is added automatically.");
				stringBuilder.AppendLine("");
				stringBuilder.AppendLine("# ↓↓ Add item names below ↓↓");
				stringBuilder.AppendLine("");
				File.WriteAllText(filePath, stringBuilder.ToString(), Encoding.UTF8);
				return;
			}
			catch
			{
				return;
			}
		}
		try
		{
			string[] array = File.ReadAllLines(filePath);
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Trim();
				if (!string.IsNullOrEmpty(text2) && !text2.StartsWith("#") && !text2.StartsWith("↓") && !text2.StartsWith("["))
				{
					string item = (text2.StartsWith("GEAR_", StringComparison.OrdinalIgnoreCase) ? text2 : ("GEAR_" + text2));
					customLootSet.Add(item);
				}
			}
			MelonLogger.Msg($"[RPGSkillsEvo] Custom auto-loot list loaded: {customLootSet.Count} item(s).");
		}
		catch
		{
		}
	}

	public static bool IsCustomTarget(string gearName)
	{
		if (string.IsNullOrEmpty(gearName))
		{
			return false;
		}
		string item = gearName.Replace("(Clone)", "").Trim();
		return customLootSet.Contains(item);
	}
}
