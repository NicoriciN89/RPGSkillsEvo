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
				stringBuilder.AppendLine("# RPG Skills Evo - 오토루팅 커스텀 아이템 목록");
				stringBuilder.AppendLine("# 아이템 이름을 한 줄에 하나씩 입력하세요.");
				stringBuilder.AppendLine("# GEAR_ 접두사는 자동으로 붙습니다.");
				stringBuilder.AppendLine("");
				stringBuilder.AppendLine("↓↓ [ 여기에 아이템 이름을 입력하세요 ] ↓↓");
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
			MelonLogger.Msg($"[RPGSkillsEvo] 커스텀 오토루팅 아이템 {customLootSet.Count}개 로드 완료.");
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
