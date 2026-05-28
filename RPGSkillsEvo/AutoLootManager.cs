using System.Collections;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using UnityEngine;

namespace RPGSkillsEvo;

public static class AutoLootManager
{
	public static bool IsEnabled = false;

	public static KeyCode ToggleHotkey = (KeyCode)108;

	public static float ScanInterval = 2f;

	private static float scanTimer = 0f;

	private static float sceneCooldown = 2f;

	public static void OnSceneLoaded()
	{
		scanTimer = 0f;
		sceneCooldown = 2f;
	}

	public static void OnUpdate()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (GameManager.IsMainMenuActive() || GameManager.IsEmptySceneActive() || string.IsNullOrEmpty(GameManager.m_ActiveScene))
		{
			return;
		}
		if (Input.GetKeyDown(ToggleHotkey) && DataHub.RealNodes.ContainsKey("S6W1") && DataHub.RealNodes["S6W1"] > 0)
		{
			IsEnabled = !IsEnabled;
		}
		if (!IsEnabled || !DataHub.RealNodes.ContainsKey("S6W1") || DataHub.RealNodes["S6W1"] <= 0)
		{
			return;
		}
		if (sceneCooldown > 0f)
		{
			sceneCooldown -= Time.deltaTime;
			return;
		}
		scanTimer -= Time.deltaTime;
		if (!(scanTimer > 0f))
		{
			scanTimer = ScanInterval;
			ScanAndLoot();
		}
	}

	private static void ScanAndLoot()
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		Transform playerTransform = GameManager.GetPlayerTransform();
		if ((UnityEngine.Object)(object)playerTransform == (UnityEngine.Object)null)
		{
			return;
		}
		float activeLootRadius = AutoLootData.GetActiveLootRadius();
		Il2CppArrayBase<GearItem> val = Object.FindObjectsOfType<GearItem>();
		if (val == null)
		{
			return;
		}
		foreach (GearItem item in val)
		{
			if ((UnityEngine.Object)(object)item == (UnityEngine.Object)null || item.m_InPlayerInventory || Vector3.Distance(playerTransform.position, ((Component)item).transform.position) > activeLootRadius)
			{
				continue;
			}
			string name = ((UnityEngine.Object)item).name;
			if (name.StartsWith("GEAR_Arrow") && !name.Contains("Shaft") && !name.Contains("Head"))
			{
				ArrowItem component = ((Component)item).GetComponent<ArrowItem>();
				if ((UnityEngine.Object)(object)component != (UnityEngine.Object)null && component.InFlight(true))
				{
					continue;
				}
			}
			string name2 = name.Replace("(Clone)", "").Trim();
			if (AutoLootData.IsTargetItem(name2))
			{
				MelonCoroutines.Start(LootOrRetry(item));
			}
		}
	}

	private static IEnumerator LootOrRetry(GearItem item)
	{
		yield return (object)new WaitForSeconds(0.033f);
		if ((UnityEngine.Object)(object)item != (UnityEngine.Object)null && (UnityEngine.Object)(object)((Component)item).gameObject != (UnityEngine.Object)null && !TryLoot(item))
		{
			yield return (object)new WaitForSeconds(ScanInterval);
			if ((UnityEngine.Object)(object)item != (UnityEngine.Object)null && (UnityEngine.Object)(object)((Component)item).gameObject != (UnityEngine.Object)null)
			{
				TryLoot(item);
			}
		}
	}

	private static bool TryLoot(GearItem item)
	{
		if ((UnityEngine.Object)(object)item == (UnityEngine.Object)null || item.m_InPlayerInventory || (UnityEngine.Object)(object)((Component)item).gameObject == (UnityEngine.Object)null)
		{
			return false;
		}
		PlayerManager playerManagerComponent = GameManager.GetPlayerManagerComponent();
		if ((UnityEngine.Object)(object)playerManagerComponent == (UnityEngine.Object)null)
		{
			return false;
		}
		try
		{
			string displayName = item.DisplayName;
			if (playerManagerComponent.ProcessPickupItemInteraction(item, false, false, false))
			{
				GearMessage.AddMessageFadeIn(item, Loc.Get("RPG.UI.ITEM_ACQUIRED"), displayName, false, true);
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}
}
