using UnityEngine;

namespace RPGSkillsEvo;

public class QuickSlotData
{
	public string ItemID = "None";

	public KeyCode HotKey = (KeyCode)0;

	public string Category = "Weapon";

	public string Priority = "Low";

	public QuickSlotData Clone()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		return new QuickSlotData
		{
			ItemID = ItemID,
			HotKey = HotKey,
			Category = Category,
			Priority = Priority
		};
	}

	public void CopyFrom(QuickSlotData other)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		ItemID = other.ItemID;
		HotKey = other.HotKey;
		Category = other.Category;
		Priority = other.Priority;
	}
}
