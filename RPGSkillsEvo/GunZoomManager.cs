namespace RPGSkillsEvo;

public static class GunZoomManager
{
	public static float zoomIncrement = 1.2f;

	public static float rifleMult = 1f;

	public static float revolverMult = 1f;

	public static float currentLerpMult = 1f;

	public static float zoomSpeed = 15f;

	public static float originalMainFOV = -1f;

	public static float originalWeaponFOV = -1f;

	public static float fixedBaseSensitivity = -1f;

	public static bool isZooming = false;

	public static bool isRifle = false;

	public static bool isRevolver = false;

	public static float GetRifleMaxZoom()
	{
		if (!IsRifleZoomUnlocked())
		{
			return 1f;
		}
		float num = 5f;
		num += (float)GetNodeLevel("N6E1N2") * 1f;
		return num + (float)GetNodeLevel("N6E1N3") * 2f;
	}

	public static float GetRevolverMaxZoom()
	{
		if (!IsRevolverZoomUnlocked())
		{
			return 1f;
		}
		float num = 2f;
		return num + (float)GetNodeLevel("N6E1N1E1N1") * 1f;
	}

	public static float GetRifleMultiplier()
	{
		return 1f / GetRifleMaxZoom();
	}

	public static float GetRevolverMultiplier()
	{
		return 1f / GetRevolverMaxZoom();
	}

	public static bool IsRevolverAimMoveUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("N6E1") && DataHub.RealNodes["N6E1"] > 0;
	}

	public static bool IsRifleZoomUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("N6E1N1") && DataHub.RealNodes["N6E1N1"] > 0;
	}

	public static bool IsRevolverZoomUnlocked()
	{
		return DataHub.RealNodes.ContainsKey("N6E1N1E1") && DataHub.RealNodes["N6E1N1E1"] > 0;
	}

	private static int GetNodeLevel(string id)
	{
		return DataHub.RealNodes.ContainsKey(id) ? DataHub.RealNodes[id] : 0;
	}

	public static void Reset()
	{
		rifleMult = 1f;
		revolverMult = 1f;
		currentLerpMult = 1f;
		originalMainFOV = -1f;
		originalWeaponFOV = -1f;
		fixedBaseSensitivity = -1f;
		isZooming = false;
		isRifle = false;
		isRevolver = false;
	}
}
