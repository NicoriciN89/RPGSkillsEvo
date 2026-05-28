using System.Collections.Generic;

namespace RPGSkillsEvo;

public static class EvoMigration
{
	public static void Run(ref string version)
	{
		if (version == "1.0.0")
		{
			Migrate_100_to_110();
			version = "1.1.0";
		}
		if (version == "1.1.0")
		{
			version = "1.2.0";
		}
		if (version == "1.2.0")
		{
			version = "1.2.1";
		}
	}

	private static void Migrate_100_to_110()
	{
		MigrateCategoryKeys();
		MigrateNodeIDs();
	}

	private static void MigrateCategoryKeys()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "화살", "화살 / Arrow" },
			{ "나무", "나무 / Wood" },
			{ "식물", "식물 / Plant" },
			{ "탄약", "탄약 / Ammo" },
			{ "가죽", "가죽 / Hide" },
			{ "불", "불 / Fire" },
			{ "기타", "기타 / Misc" },
			{ "커스텀", "커스텀 / Custom" }
		};
		AutoLootData.SlotData[] slots = AutoLootData.Slots;
		foreach (AutoLootData.SlotData slotData in slots)
		{
			if (!string.IsNullOrEmpty(slotData.CategoryKey) && dictionary.TryGetValue(slotData.CategoryKey, out var value))
			{
				slotData.CategoryKey = value;
			}
		}
		AutoLootData.ConfirmSlots();
	}

	private static void MigrateNodeIDs()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "W1", "W6" },
			{ "W2", "W7" },
			{ "W2N1", "W7N1" },
			{ "W3", "W8" },
			{ "W3N1", "W8N1" },
			{ "W4", "W9" },
			{ "W4N1", "W9N1" },
			{ "W5", "W10" },
			{ "E1", "E6" },
			{ "E2", "E7" },
			{ "E2N1", "E7N1" },
			{ "E2S1", "E7S1" },
			{ "E3", "E8" },
			{ "E2N1E1", "E7N1E1" },
			{ "E2S1E1", "E7S1E1" },
			{ "E4", "E9" },
			{ "E2N1E2", "E7N1E2" },
			{ "E2S1E2", "E7S1E2" },
			{ "E1S1", "E6S1" },
			{ "E1S2", "E6S2" },
			{ "E1S3", "E6S3" },
			{ "E1S4", "E6S4" },
			{ "S1", "S6" },
			{ "S1W1", "S6W1" },
			{ "S1W1S1", "S6W1S1" },
			{ "S1W2", "S6W2" },
			{ "S1W2S1", "S6W2S1" },
			{ "S1W3", "S6W3" },
			{ "S1W3S1", "S6W3S1" },
			{ "S2", "S7" },
			{ "S3", "S8" },
			{ "S4", "S9" },
			{ "N1", "N6" },
			{ "N1W1", "N6W1" },
			{ "N1W1N1", "N6W1N1" },
			{ "N1W1N1W1", "N6W1N1W1" },
			{ "N1W1N2", "N6W1N2" },
			{ "N1E1", "N6E1" },
			{ "N1E1N1", "N6E1N1" },
			{ "N1E1N2", "N6E1N2" },
			{ "N1E1N3", "N6E1N3" },
			{ "N1E1N1E1", "N6E1N1E1" },
			{ "N1E1N1E1N1", "N6E1N1E1N1" }
		};
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> realNode in DataHub.RealNodes)
		{
			string key = (dictionary.ContainsKey(realNode.Key) ? dictionary[realNode.Key] : realNode.Key);
			dictionary2[key] = realNode.Value;
		}
		DataHub.RealNodes.Clear();
		foreach (KeyValuePair<string, int> item in dictionary2)
		{
			DataHub.RealNodes[item.Key] = item.Value;
		}
	}
}
