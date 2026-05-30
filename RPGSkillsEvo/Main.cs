using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace RPGSkillsEvo;

public class Main : MelonMod
{
	public static bool isWaitingForKey;

	private static bool IsInGame()
	{
		return !GameManager.s_ActiveIsMainMenu && !GameManager.s_ActiveIsEmpty && !string.IsNullOrEmpty(GameManager.m_ActiveScene);
	}

	public override void OnInitializeMelon()
	{
		Settings.Init();
		MelonLogger.Msg("RPG Skills Evo: Integrated Hub System Initialized.");
		Status.RefreshCache();
		AutoLootUserCustom.Refresh();
		QuickbarHUDRenderer.Init();
	}

	public override void OnSceneWasLoaded(int buildIndex, string sceneName)
	{
		AutoLootManager.OnSceneLoaded();
		GearMessageStackingPatch.ClearCounts();
		TooltipManager.Hide();
		AutoLootUI.CloseMenu();
		QuickbarUI.CloseMenu();
		SkillsUI.ResetInternalState();
		InterfaceUI.ForceClose();
		MapTrackManager.ClearTarget();
		Patch_Panel_Map_MapTrack.OnSceneLoaded();
		MapTrackHUDRenderer.OnSceneLoaded();
		GunZoomManager.Reset();
		StatsHUDRenderer.ResetLabels();
		MaxConditionManager.ResetBase();
		ActivityXPFlag.CookingAwarded = false;
		if (!IsInGame())
		{
			PlayerLevel.Reset();
		}
	}

	public override void OnUpdate()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Invalid comparison between Unknown and I4
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		if (Input.GetKeyDown(DataHub.MenuHotkey) && IsInGame())
		{
			if (InterfaceUI.IsOpen)
			{
				InterfaceUI.CloseMenu();
			}
			else
			{
				InterfaceUI.OpenMenu();
			}
		}
		if (InterfaceUI.IsOpen)
		{
			Cursor.visible = true;
			Cursor.lockState = (CursorLockMode)0;
			if (isWaitingForKey)
			{
				Event current = Event.current;
				if (current != null && current.isKey && (int)current.keyCode != 0 && (int)current.keyCode != 27)
				{
					DataHub.MenuHotkey = current.keyCode;
					isWaitingForKey = false;
				}
				else if (current != null && current.isKey && (int)current.keyCode == 27)
				{
					isWaitingForKey = false;
				}
			}
		}
		MapTrackHUDRenderer.OnUpdate();
		StatsHUDRenderer.OnUpdate();
		if (IsInGame())
		{
			AutoLootManager.OnUpdate();
			DebugHelper.OnUpdate();
			DebugScanManager.OnUpdate();
		}
		if (GunZoomManager.isZooming)
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0f)
			{
				if (GunZoomManager.isRifle && GunZoomManager.IsRifleZoomUnlocked())
				{
					float num = 1f / GunZoomManager.GetRifleMaxZoom();
					if (axis > 0f)
					{
						GunZoomManager.rifleMult /= GunZoomManager.zoomIncrement;
					}
					else
					{
						GunZoomManager.rifleMult *= GunZoomManager.zoomIncrement;
					}
					GunZoomManager.rifleMult = Mathf.Clamp(GunZoomManager.rifleMult, num, 1f);
				}
				else if (GunZoomManager.isRevolver && GunZoomManager.IsRevolverZoomUnlocked())
				{
					float num2 = 1f / GunZoomManager.GetRevolverMaxZoom();
					if (axis > 0f)
					{
						GunZoomManager.revolverMult /= GunZoomManager.zoomIncrement;
					}
					else
					{
						GunZoomManager.revolverMult *= GunZoomManager.zoomIncrement;
					}
					GunZoomManager.revolverMult = Mathf.Clamp(GunZoomManager.revolverMult, num2, 1f);
				}
			}
			float num3 = (GunZoomManager.isRifle ? GunZoomManager.rifleMult : GunZoomManager.revolverMult);
			GunZoomManager.currentLerpMult = Mathf.Lerp(GunZoomManager.currentLerpMult, num3, Time.deltaTime * GunZoomManager.zoomSpeed);
		}
		else
		{
			GunZoomManager.currentLerpMult = 1f;
		}
		if (InterfaceUI.IsOpen || GameManager.m_IsPaused || !QuickbarData.IsQuickSlotUnlocked())
		{
			return;
		}
		int activeSlotCount = QuickbarData.GetActiveSlotCount();
		for (int i = 0; i < activeSlotCount; i++)
		{
			if (Input.GetKeyDown(QuickbarData.Slots[i].HotKey))
			{
				QuickbarActionManager.ExecuteSlot(QuickbarData.Slots[i]);
				break;
			}
		}
		if (!QuickbarData.IsPresetUnlocked())
		{
			return;
		}
		int activePresetCount = QuickbarData.GetActivePresetCount();
		for (int j = 0; j < activePresetCount; j++)
		{
			if (Input.GetKeyDown(QuickbarData.PresetHotKeys[j]))
			{
				if (QuickbarData.Presets[j].ClothingNames.Count > 0)
				{
					QuickbarPresetManager.ApplyPreset(QuickbarData.Presets[j]);
				}
				break;
			}
		}
	}

	public override void OnGUI()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		InterfaceUI.OnGUI();
		QuickbarHUDRenderer.OnGUI();
		UpHUD.OnGUI();
		DebugScanManager.OnGUI();
		if (!GunZoomManager.isZooming)
		{
			return;
		}
		bool flag = GunZoomManager.isRifle && GunZoomManager.IsRifleZoomUnlocked();
		bool flag2 = GunZoomManager.isRevolver && GunZoomManager.IsRevolverZoomUnlocked();
		if (flag || flag2)
		{
			float num = (GunZoomManager.isRifle ? GunZoomManager.rifleMult : GunZoomManager.revolverMult);
			if (num < 0.99f)
			{
				float num2 = 1f / num;
				string text = $"Zoom: {num2:F1}x";
				GUIStyle val = new GUIStyle();
				val.fontSize = 50;
				val.normal.textColor = Color.yellow;
				val.alignment = (TextAnchor)4;
				float num3 = (float)Screen.width * 0.5f;
				float num4 = (float)Screen.height * 0.2f;
				GUI.Label(new Rect(num3 - 200f, num4, 400f, 60f), text, val);
			}
		}
	}
}
