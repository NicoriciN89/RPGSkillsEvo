using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

public static class PlayerLevel
{
	[HarmonyPatch(typeof(BaseAi), "ApplyDamage", new Type[]
	{
		typeof(float),
		typeof(float),
		typeof(DamageSource),
		typeof(string)
	})]
	public class ApplyDamage_Patch
	{
		[HarmonyPostfix]
		private static void Postfix(BaseAi __instance)
		{
			if ((UnityEngine.Object)(object)__instance == (UnityEngine.Object)null)
			{
				return;
			}
			int instanceID = ((UnityEngine.Object)__instance).GetInstanceID();
			if (processedDeaths.Contains(instanceID))
			{
				return;
			}
			float currentHP = __instance.m_CurrentHP;
			if (!(currentHP > 0f))
			{
				processedDeaths.Add(instanceID);
				string text = ((UnityEngine.Object)((Component)__instance).gameObject).name.ToLower();
				float num = 0f;
				if (text.Contains("rabbit"))
				{
					num = 5f;
				}
				else if (text.Contains("wolf"))
				{
					num = 10f;
				}
				else if (text.Contains("doe"))
				{
					num = 10f;
				}
				else if (text.Contains("stag"))
				{
					num = 12f;
				}
				else if (text.Contains("ptarmigan"))
				{
					num = 8f;
				}
				else if (text.Contains("bear"))
				{
					num = 20f;
				}
				else if (text.Contains("cougar"))
				{
					num = 30f;
				}
				else if (text.Contains("moose"))
				{
					num = 50f;
				}
				if (num > 0f)
				{
					AddXP(num * Settings.XpKillMultiplier);
				}
			}
		}
	}

	public static float CurrentXP = 0f;

	public static int Level = 1;

	public static int SkillPoints = 1;

	private static HashSet<int> processedDeaths = new HashSet<int>();

	public static float RequiredXP => 10f + (float)(Level - 1) * 5f;

	public static void Reset()
	{
		CurrentXP = 0f;
		Level = 1;
		SkillPoints = Settings.StartPoints;
		processedDeaths.Clear();
	}

	public static void AddXP(float amount)
	{
		CurrentXP += amount;
		UpHUD.AddXPNotice(amount);
		while (CurrentXP >= RequiredXP)
		{
			CurrentXP -= RequiredXP;
			Level++;
			SkillPoints += Settings.PointsPerLevel;
			UpHUD.ShowLevelUp(Level);
			GameAudioManager.PlaySound("PLAY_REWARDLEVELUP", GameManager.GetPlayerObject());
		}
	}
}
