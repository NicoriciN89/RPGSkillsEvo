using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace RPGSkillsEvo;

[HarmonyPatch(typeof(Panel_Map), "OnMapClicked")]
internal class Patch_Panel_Map_MapTrack
{
	private static Il2CppArrayBase<MapDetail> s_cachedMapDetails;

	public static void OnSceneLoaded() => s_cachedMapDetails = null;

	private static void Postfix(Panel_Map __instance)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		if (!MapTrackManager.IsUnlocked() || !Input.GetMouseButtonDown(1))
		{
			return;
		}
		MapIcon mapIconBeingHovered = __instance.m_MapIconBeingHovered;
		if ((UnityEngine.Object)(object)mapIconBeingHovered == (UnityEngine.Object)null)
		{
			return;
		}
		MapElementSaveData val = null;
		foreach (var current in __instance.m_MapElementData)
		{
			foreach (var current2 in current.Value)
			{
				if ((UnityEngine.Object)(object)__instance.GetMapIconFromMapElement(current2) == (UnityEngine.Object)(object)mapIconBeingHovered)
				{
					val = current2;
					break;
				}
			}
			if (val != null)
			{
				break;
			}
		}
		if (val == null)
		{
			return;
		}
		if (MapTrackManager.IsTracking && Vector2.Distance(val.m_PositionOnMap, MapTrackManager.MapPosition) < 0.01f)
		{
			MapTrackManager.ClearTarget();
			GameAudioManager.PlayGuiConfirm();
			return;
		}
		string mapNameOfCurrentScene = __instance.GetMapNameOfCurrentScene();
		Vector3 val2 = Vector3.zero;
		float num = float.MaxValue;
		if (s_cachedMapDetails == null)
			s_cachedMapDetails = Resources.FindObjectsOfTypeAll<MapDetail>();
		foreach (MapDetail item in s_cachedMapDetails)
		{
			if (item.m_LocID == val.m_LocationNameLocID && ((Component)item).gameObject.activeInHierarchy)
			{
				Vector3 worldPosition = item.GetWorldPosition();
				Vector3 val4 = __instance.WorldPositionToMapPosition(mapNameOfCurrentScene, worldPosition);
				float num2 = Vector2.Distance(val.m_PositionOnMap, new Vector2(val4.x, val4.y));
				if (num2 < num)
				{
					num = num2;
					val2 = worldPosition;
				}
			}
		}
		if (val2 != Vector3.zero)
		{
			MapTrackManager.SetTarget(val2, val.m_PositionOnMap, mapIconBeingHovered.m_Label.text);
			GameAudioManager.PlayGuiConfirm();
		}
	}
}
