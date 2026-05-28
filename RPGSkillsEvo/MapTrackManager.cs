using UnityEngine;

namespace RPGSkillsEvo;

public static class MapTrackManager
{
	public static Vector3 TargetPosition { get; private set; }

	public static Vector2 MapPosition { get; private set; }

	public static string TargetName { get; private set; }

	public static bool IsTracking { get; private set; }

	public static bool IsUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("S7") && DataHub.RealNodes["S7"] > 0;
	}

	public static bool IsArrowUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("S8") && DataHub.RealNodes["S8"] > 0;
	}

	public static bool IsHeightUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("S9") && DataHub.RealNodes["S9"] > 0;
	}

	public static void SetTarget(Vector3 worldPos, Vector2 mapPos, string name)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		TargetPosition = worldPos;
		MapPosition = mapPos;
		TargetName = name;
		IsTracking = true;
	}

	public static void ClearTarget()
	{
		IsTracking = false;
		TargetName = "";
	}
}
