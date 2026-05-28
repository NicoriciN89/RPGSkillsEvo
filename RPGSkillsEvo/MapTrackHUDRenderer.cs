using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using UnityEngine;

namespace RPGSkillsEvo;

public static class MapTrackHUDRenderer
{
	private static GameObject m_HUDObj;

	private static UILabel m_DistanceLabel;

	private static UILabel m_ArrowLabel;

	private static UILabel m_HeightLabel;

	private static UILabel m_MapMarker;

	private static float m_UpdateTimer;

	public static void OnSceneLoaded()
	{
		HideAllUI();
		m_HUDObj = null;
		m_DistanceLabel = null;
		m_ArrowLabel = null;
		m_HeightLabel = null;
		m_MapMarker = null;
	}

	public static void OnUpdate()
	{
		if (!MapTrackManager.IsUnlocked() || GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive() || !MapTrackManager.IsTracking)
		{
			HideAllUI();
			return;
		}
		m_UpdateTimer += Time.deltaTime;
		if (m_UpdateTimer >= 0.05f)
		{
			UpdateDistanceHUD();
			UpdateMapMarker();
			m_UpdateTimer = 0f;
		}
	}

	private static void UpdateDistanceHUD()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		if ((UnityEngine.Object)(object)m_HUDObj == (UnityEngine.Object)null)
		{
			CreateHUDByCloning();
		}
		if ((UnityEngine.Object)(object)m_HUDObj == (UnityEngine.Object)null)
		{
			return;
		}
		if (!m_HUDObj.activeSelf)
		{
			m_HUDObj.SetActive(true);
		}
		Vector3 position = GameManager.GetPlayerTransform().position;
		Vector3 targetPosition = MapTrackManager.TargetPosition;
		float num = Vector2.Distance(new Vector2(position.x, position.z), new Vector2(targetPosition.x, targetPosition.z));
		if ((UnityEngine.Object)(object)m_DistanceLabel != (UnityEngine.Object)null)
		{
			m_DistanceLabel.text = $"[ {MapTrackManager.TargetName} ]  {num:F0}m";
		}
		if ((UnityEngine.Object)(object)m_ArrowLabel != (UnityEngine.Object)null)
		{
			if (MapTrackManager.IsArrowUnlocked())
			{
				((Component)m_ArrowLabel).gameObject.SetActive(true);
				Vector3 val = targetPosition - position;
				Vector3 normalized = val.normalized;
				Vector3 forward = ((Component)GameManager.GetMainCamera()).transform.forward;
				forward.y = 0f;
				normalized.y = 0f;
				float num2 = Vector3.SignedAngle(forward, normalized, Vector3.up);
				((Component)m_ArrowLabel).transform.localRotation = Quaternion.Euler(65f, 0f, 0f - num2);
			}
			else
			{
				((Component)m_ArrowLabel).gameObject.SetActive(false);
			}
		}
		if ((UnityEngine.Object)(object)m_HeightLabel != (UnityEngine.Object)null)
		{
			if (MapTrackManager.IsHeightUnlocked())
			{
				float num3 = targetPosition.y - position.y;
				if (Mathf.Abs(num3) < 1.5f)
				{
					m_HeightLabel.text = "";
				}
				else
				{
					string arg = ((num3 > 0f) ? "▲" : "▼");
					m_HeightLabel.text = $"{arg} {Mathf.Abs(num3):F0}m";
					((UIWidget)m_HeightLabel).color = ((num3 > 0f) ? new Color(1f, 0.4f, 0.4f) : new Color(0.4f, 0.7f, 1f));
				}
			}
			else
			{
				m_HeightLabel.text = "";
			}
		}
		if (num < 3f)
		{
			MapTrackManager.ClearTarget();
		}
	}

	private static void UpdateMapMarker()
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		Panel_Map panel = InterfaceManager.GetPanel<Panel_Map>();
		if ((UnityEngine.Object)(object)panel == (UnityEngine.Object)null || !((Panel_Base)panel).IsEnabled())
		{
			if ((UnityEngine.Object)(object)m_MapMarker != (UnityEngine.Object)null && ((Component)m_MapMarker).gameObject.activeSelf)
			{
				((Component)m_MapMarker).gameObject.SetActive(false);
			}
			return;
		}
		if ((UnityEngine.Object)(object)m_MapMarker == (UnityEngine.Object)null)
		{
			CreateMarkerByCloning();
		}
		if ((UnityEngine.Object)(object)m_MapMarker != (UnityEngine.Object)null)
		{
			if (!((Component)m_MapMarker).gameObject.activeSelf)
			{
				((Component)m_MapMarker).gameObject.SetActive(true);
			}
			if ((UnityEngine.Object)(object)((Component)m_MapMarker).transform.parent != (UnityEngine.Object)(object)panel.m_MapElementsTransform)
			{
				((Component)m_MapMarker).transform.SetParent(panel.m_MapElementsTransform, false);
			}
			((Component)m_MapMarker).transform.localPosition = new Vector3(MapTrackManager.MapPosition.x + 2f, MapTrackManager.MapPosition.y + 2f, 0f);
		}
	}

	private static void CreateHUDByCloning()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		Panel_HUD panel = InterfaceManager.GetPanel<Panel_HUD>();
		if ((UnityEngine.Object)(object)panel != (UnityEngine.Object)null)
		{
			UILabel componentInChildren = ((Component)panel).GetComponentInChildren<UILabel>();
			if ((UnityEngine.Object)(object)componentInChildren != (UnityEngine.Object)null)
			{
				m_HUDObj = new GameObject("RPGEvo_MapTrack_HUD");
				m_HUDObj.transform.SetParent(((Component)panel).transform, false);
				m_HUDObj.transform.localPosition = new Vector3(0f, 340f, 0f);
				GameObject val = UnityEngine.Object.Instantiate<GameObject>(((Component)componentInChildren).gameObject);
				((UnityEngine.Object)val).name = "DistanceLabel";
				val.transform.SetParent(m_HUDObj.transform, false);
				val.transform.localPosition = Vector3.zero;
				m_DistanceLabel = val.GetComponent<UILabel>();
				((UIWidget)m_DistanceLabel).pivot = (UIWidget.Pivot)4;
				SetupLabelStyle(m_DistanceLabel, 24, new Color(1f, 0.5f, 0f), useOutline: true);
				CleanupComponents(val);
				GameObject val2 = UnityEngine.Object.Instantiate<GameObject>(((Component)componentInChildren).gameObject);
				((UnityEngine.Object)val2).name = "ArrowLabel";
				val2.transform.SetParent(m_HUDObj.transform, false);
				val2.transform.localPosition = new Vector3(-280f, 0f, 0f);
				m_ArrowLabel = val2.GetComponent<UILabel>();
				((UIWidget)m_ArrowLabel).pivot = (UIWidget.Pivot)4;
				SetupLabelStyle(m_ArrowLabel, 50, new Color(1f, 0.5f, 0f), useOutline: true);
				m_ArrowLabel.text = "⬆";
				CleanupComponents(val2);
				GameObject val3 = UnityEngine.Object.Instantiate<GameObject>(((Component)componentInChildren).gameObject);
				((UnityEngine.Object)val3).name = "HeightLabel";
				val3.transform.SetParent(m_HUDObj.transform, false);
				val3.transform.localPosition = new Vector3(-210f, 0f, 0f);
				m_HeightLabel = val3.GetComponent<UILabel>();
				((UIWidget)m_HeightLabel).pivot = (UIWidget.Pivot)4;
				SetupLabelStyle(m_HeightLabel, 20, Color.white, useOutline: true);
				m_HeightLabel.text = "";
				CleanupComponents(val3);
			}
		}
	}

	private static void SetupLabelStyle(UILabel label, int fontSize, Color color, bool useOutline)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if ((UnityEngine.Object)(object)label != (UnityEngine.Object)null)
		{
			label.fontSize = fontSize;
			((UIWidget)label).color = color;
			((UIWidget)label).depth = 100;
			if (useOutline)
			{
				label.effectStyle = (UILabel.Effect)2;
				label.effectColor = Color.black;
				label.effectDistance = new Vector2(1.5f, 1.5f);
			}
			else
			{
				label.effectStyle = (UILabel.Effect)0;
			}
		}
	}

	private static void CleanupComponents(GameObject go)
	{
		Il2CppArrayBase<MonoBehaviour> components = go.GetComponents<MonoBehaviour>();
		foreach (MonoBehaviour item in components)
		{
			string name = ((MemberInfo)((UnityEngine.Object)item).GetIl2CppType()).Name;
			if (name != "UILabel" && name != "UIWidget" && name != "RectTransform" && name != "Transform")
			{
				UnityEngine.Object.Destroy((UnityEngine.Object)(object)item);
			}
		}
	}

	private static void CreateMarkerByCloning()
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		Panel_HUD panel = InterfaceManager.GetPanel<Panel_HUD>();
		UILabel val = ((panel != null) ? ((Component)panel).GetComponentInChildren<UILabel>() : null);
		if ((UnityEngine.Object)(object)val != (UnityEngine.Object)null)
		{
			GameObject val2 = UnityEngine.Object.Instantiate<GameObject>(((Component)val).gameObject);
			((UnityEngine.Object)val2).name = "RPGEvo_MapTrack_Marker";
			m_MapMarker = val2.GetComponent<UILabel>();
			if ((UnityEngine.Object)(object)m_MapMarker != (UnityEngine.Object)null)
			{
				m_MapMarker.text = "↙";
				SetupLabelStyle(m_MapMarker, 15, Color.red, useOutline: false);
				((UIWidget)m_MapMarker).depth = 5000;
			}
			CleanupComponents(val2);
		}
	}

	private static void HideAllUI()
	{
		if ((UnityEngine.Object)(object)m_HUDObj != (UnityEngine.Object)null && m_HUDObj.activeSelf)
		{
			m_HUDObj.SetActive(false);
		}
		if ((UnityEngine.Object)(object)m_MapMarker != (UnityEngine.Object)null && ((Component)m_MapMarker).gameObject.activeSelf)
		{
			((Component)m_MapMarker).gameObject.SetActive(false);
		}
	}
}
