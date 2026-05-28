using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(vp_FPSCamera), "LateUpdate")]
internal class Patch_GunZoom_Camera
{
	private static bool wasZoomingLastFrame;

	private static void Postfix(vp_FPSCamera __instance)
	{
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive() || string.IsNullOrEmpty(GameManager.m_ActiveScene))
		{
			return;
		}
		PlayerManager playerManagerComponent = GameManager.GetPlayerManagerComponent();
		if ((UnityEngine.Object)(object)playerManagerComponent == (UnityEngine.Object)null || (UnityEngine.Object)(object)playerManagerComponent.m_ItemInHands == (UnityEngine.Object)null)
		{
			GunZoomManager.isRifle = false;
			GunZoomManager.isRevolver = false;
			return;
		}
		string text = ((UnityEngine.Object)playerManagerComponent.m_ItemInHands).name.ToLower();
		GunZoomManager.isRifle = text.Contains("rifle");
		GunZoomManager.isRevolver = text.Contains("revolver");
		GunZoomManager.isZooming = __instance.IsZoomed;
		if (GunZoomManager.fixedBaseSensitivity <= 0f && !GunZoomManager.isZooming)
		{
			GunZoomManager.fixedBaseSensitivity = __instance.MouseSensitivity;
			Camera component = ((Component)__instance).GetComponent<Camera>();
			if ((UnityEngine.Object)(object)component != (UnityEngine.Object)null)
			{
				GunZoomManager.originalMainFOV = component.fieldOfView;
			}
			if ((UnityEngine.Object)(object)__instance.m_WeaponCamera != (UnityEngine.Object)null)
			{
				GunZoomManager.originalWeaponFOV = __instance.m_WeaponCamera.fieldOfView;
			}
		}
		bool flag = GunZoomManager.isRifle && GunZoomManager.IsRifleZoomUnlocked();
		bool flag2 = GunZoomManager.isRevolver && GunZoomManager.IsRevolverZoomUnlocked();
		bool flag3 = flag || flag2;
		if (flag3 && GunZoomManager.isZooming)
		{
			float currentLerpMult = GunZoomManager.currentLerpMult;
			Camera component2 = ((Component)__instance).GetComponent<Camera>();
			if ((UnityEngine.Object)(object)component2 != (UnityEngine.Object)null && GunZoomManager.originalMainFOV > 0f)
			{
				component2.fieldOfView = GunZoomManager.originalMainFOV * currentLerpMult;
			}
			if ((UnityEngine.Object)(object)__instance.m_WeaponCamera != (UnityEngine.Object)null && GunZoomManager.originalWeaponFOV > 0f)
			{
				__instance.m_WeaponCamera.fieldOfView = GunZoomManager.originalWeaponFOV * currentLerpMult;
			}
			float num = Mathf.Clamp(currentLerpMult + 0.15f, 0f, 1f);
			__instance.MouseSensitivity = GunZoomManager.fixedBaseSensitivity * num;
			wasZoomingLastFrame = true;
		}
		else if (flag3 && wasZoomingLastFrame)
		{
			Camera component3 = ((Component)__instance).GetComponent<Camera>();
			if ((UnityEngine.Object)(object)component3 != (UnityEngine.Object)null && GunZoomManager.originalMainFOV > 0f)
			{
				component3.fieldOfView = GunZoomManager.originalMainFOV;
			}
			if ((UnityEngine.Object)(object)__instance.m_WeaponCamera != (UnityEngine.Object)null && GunZoomManager.originalWeaponFOV > 0f)
			{
				__instance.m_WeaponCamera.fieldOfView = GunZoomManager.originalWeaponFOV;
			}
			if (GunZoomManager.fixedBaseSensitivity > 0f)
			{
				__instance.MouseSensitivity = GunZoomManager.fixedBaseSensitivity;
			}
			wasZoomingLastFrame = false;
		}
		else
		{
			wasZoomingLastFrame = false;
		}
	}
}
