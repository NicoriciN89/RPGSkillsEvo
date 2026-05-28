using System.Collections.Generic;

namespace RPGSkillsEvo;

public static class NodeManager
{
	public static int tPoints;

	public static Dictionary<string, int> tNodes = new Dictionary<string, int>();

	public static void SyncFromHub()
	{
		tPoints = PlayerLevel.SkillPoints;
		tNodes.Clear();
		foreach (KeyValuePair<string, int> realNode in DataHub.RealNodes)
		{
			tNodes[realNode.Key] = realNode.Value;
		}
	}

	public static void PushToHub()
	{
		PlayerLevel.SkillPoints = tPoints;
		DataHub.RealNodes.Clear();
		foreach (KeyValuePair<string, int> tNode in tNodes)
		{
			DataHub.RealNodes[tNode.Key] = tNode.Value;
		}
		Status.RefreshCache();
	}

	public static bool IsVisible(SkillNode node)
	{
		if (node.ID == "CORE")
		{
			return true;
		}
		return tNodes.ContainsKey(node.RequiredNodeID) && tNodes[node.RequiredNodeID] > 0;
	}

	private static bool IsFreeInvestNode(SkillNode node)
	{
		return node.Effect == EffectType.SpeedPenaltyOffset || node.Effect == EffectType.LootRadius || node.ID == "E7N1" || node.ID == "E7S1";
	}

	private static bool IsPenaltyOffsetNode(SkillNode node)
	{
		return node.Effect == EffectType.SpeedPenaltyOffset;
	}

	public static bool IsParentMaxLevel(SkillNode node)
	{
		if (string.IsNullOrEmpty(node.RequiredNodeID))
		{
			return true;
		}
		SkillNode byID = NodeDatabase.GetByID(node.RequiredNodeID);
		if (byID == null)
		{
			return true;
		}
		int level = GetLevel(byID.ID);
		if (IsFreeInvestNode(node))
		{
			return level > 0;
		}
		return level >= byID.MaxLevel;
	}

	private static bool IsWithinParentLevel(SkillNode node)
	{
		if (!IsPenaltyOffsetNode(node))
		{
			return true;
		}
		SkillNode byID = NodeDatabase.GetByID(node.RequiredNodeID);
		if (byID == null)
		{
			return true;
		}
		int level = GetLevel(byID.ID);
		int level2 = GetLevel(node.ID);
		return level2 < level;
	}

	public static int GetLevel(string id)
	{
		return tNodes.ContainsKey(id) ? tNodes[id] : 0;
	}

	public static int GetConfirmedLevel(string id)
	{
		return DataHub.RealNodes.ContainsKey(id) ? DataHub.RealNodes[id] : 0;
	}

	public static void Invest(SkillNode node)
	{
		if (IsParentMaxLevel(node) && IsWithinParentLevel(node))
		{
			int level = GetLevel(node.ID);
			if (level < node.MaxLevel && tPoints >= node.Cost)
			{
				tPoints -= node.Cost;
				tNodes[node.ID] = level + 1;
			}
		}
	}

	public static bool CanCancel(SkillNode node)
	{
		int level = GetLevel(node.ID);
		int confirmedLevel = GetConfirmedLevel(node.ID);
		return level > confirmedLevel;
	}

	public static void CancelNode(SkillNode node)
	{
		CancelRecursive(node);
	}

	private static void CancelRecursive(SkillNode node)
	{
		int level = GetLevel(node.ID);
		int confirmedLevel = GetConfirmedLevel(node.ID);
		if (level > confirmedLevel)
		{
			int num = (level - confirmedLevel) * node.Cost;
			tPoints += num;
			tNodes[node.ID] = confirmedLevel;
		}
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			if (allNode.RequiredNodeID == node.ID)
			{
				CancelRecursive(allNode);
			}
		}
	}
}
