using System;

namespace RPGSkillsEvo;

public static class Status
{
	private static float cachedWeight;

	private static float cachedWalk;

	private static float cachedSprint;

	private static float cachedCrouch;

	private static float cachedSpeedPenalty;

	private static float cachedWindResist;

	private static float cachedWarmth;

	private static float cachedFatigueReduction;

	private static float cachedHungerReduction;

	private static float cachedVitality;

	private static float cachedWeightDownPenalty;

	private static float cachedProtection;

	private static float cachedVitalityDownPenalty;

	private static float cachedDecayEfficiency;

	private static float cachedBuffDuration;

	private static float cachedCraftSpeed;

	private static float cachedBleedResist;

	private static float cachedHarvestBonus;
	private static float cachedThirstDown;
	private static float cachedToolDurability;
	private static float cachedFishingBonus;
	private static float cachedSprintStamina;
	private static int cachedActiveLootSlots;
	private static int cachedActiveQuickSlots;
	private static int cachedActivePresetSlots;
	private static float cachedActiveLootRadius;
	private static float cachedFireStartBonus;
	private static float cachedColdAdapt;
	private static float cachedBowSteadiness;
	private static float cachedCarcassHarvest;

	public static void RefreshCache()
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		float num12 = 0f;
		float num13 = 0f;
		float num14 = 0f;
		float num15 = 0f;
		float num16 = 0f;
		float num17cs = 0f;
		float num18br = 0f;
		float num19hb = 0f;
		float num20td = 0f;
		float num21tool = 0f;
		float num22fish = 0f;
		float num23ss = 0f;
		int numLootSlots = 0;
		int numQuickSlots = 0;
		int numPresetSlots = 0;
		float numLootRadius = 5f;
		float numFireStart = 0f;
		float numColdAdapt = 0f;
		float numBowSteady = 0f;
		float numCarcass = 0f;
		foreach (SkillNode allNode in NodeDatabase.AllNodes)
		{
			int num17 = (DataHub.RealNodes.ContainsKey(allNode.ID) ? DataHub.RealNodes[allNode.ID] : 0);
			if (num17 > 0)
			{
				switch (allNode.Effect)
				{
				case EffectType.WeightUp:
					num += (float)num17 * allNode.EffectPerLevel;
					break;
				case EffectType.WalkSpeed:
					num2 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.SprintSpeed:
					num3 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.CrouchSpeed:
					num4 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.SpeedPenaltyOffset:
					num6 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.WindResist:
					num7 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.WarmthUp:
					num8 += (float)num17 * allNode.EffectPerLevel;
					break;
				case EffectType.FatigueDown:
					num9 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.HungerDown:
					num10 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.VitalityUp:
					num11 += (float)num17 * allNode.EffectPerLevel;
					break;
				case EffectType.ProtectionUp:
					num13 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.DecayEfficiency:
					num15 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.BuffDuration:
					num16 += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.CraftSpeed:
					num17cs += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.BleedResist:
					num18br += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.HarvestBonus:
					num19hb += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.ThirstDown:
					num20td += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.ToolDurability:
					num21tool += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.FishingBonus:
					num22fish += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.SprintStamina:
					num23ss += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.LootSlot:
					numLootSlots += num17;
					break;
				case EffectType.QuickSlot:
					numQuickSlots += num17;
					break;
				case EffectType.PresetSlot:
					numPresetSlots += num17;
					break;
				case EffectType.LootRadius:
					numLootRadius += (float)num17 * allNode.EffectPerLevel;
					break;
				case EffectType.FireStartBonus:
					numFireStart += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.ColdAdapt:
					numColdAdapt += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.BowSteadiness:
					numBowSteady += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				case EffectType.CarcassHarvest:
					numCarcass += (float)num17 * allNode.EffectPerLevel * 0.01f;
					break;
				}
				if (allNode.Penalty == PenaltyType.SpeedDown)
				{
					num5 += (float)num17 * allNode.PenaltyPerLevel * 0.01f;
				}
				if (allNode.Penalty == PenaltyType.WeightDown)
				{
					num12 += (float)num17 * allNode.PenaltyPerLevel;
				}
				if (allNode.Penalty == PenaltyType.VitalityDown)
				{
					num14 += (float)num17 * allNode.PenaltyPerLevel;
				}
			}
		}
		cachedWeight = num;
		cachedWalk = num2;
		cachedSprint = num3;
		cachedCrouch = num4;
		cachedSpeedPenalty = Math.Max(0f, num5 - num6);
		cachedWindResist = Math.Min(1f, num7);
		cachedWarmth = Math.Min(10f, num8);
		cachedFatigueReduction = Math.Min(0.5f, num9);
		cachedHungerReduction = Math.Min(0.5f, num10);
		cachedVitality = num11;
		cachedWeightDownPenalty = num12;
		cachedProtection = Math.Min(0.95f, num13);
		cachedVitalityDownPenalty = num14;
		cachedDecayEfficiency = Math.Min(0.2f, num15);
		cachedBuffDuration = Math.Min(1f, num16);
		cachedCraftSpeed = Math.Min(0.5f, num17cs);
		cachedBleedResist = Math.Min(0.5f, num18br);
		cachedHarvestBonus = Math.Min(1f, num19hb);
		cachedThirstDown = Math.Min(0.5f, num20td);
		cachedToolDurability = Math.Min(0.5f, num21tool);
		cachedFishingBonus = Math.Min(1f, num22fish);
		cachedSprintStamina = Math.Min(1f, num23ss);
		cachedActiveLootSlots = Math.Min(AutoLootData.BaseSlotCount + numLootSlots, AutoLootData.MaxSlotCount);
		cachedActiveQuickSlots = Math.Min(QuickbarData.BaseSlotCount + numQuickSlots, QuickbarData.MaxSlotCount);
		cachedActivePresetSlots = Math.Min(QuickbarData.BasePresetCount + numPresetSlots, QuickbarData.MaxPresetCount);
		cachedActiveLootRadius = numLootRadius;
		cachedFireStartBonus = Math.Min(0.5f, numFireStart);
		cachedColdAdapt = Math.Min(0.5f, numColdAdapt);
		cachedBowSteadiness = Math.Min(0.5f, numBowSteady);
		cachedCarcassHarvest = Math.Min(0.5f, numCarcass);
	}

	public static float GetWeightBonus()
	{
		return cachedWeight;
	}

	public static float GetWalkSpeedBonus()
	{
		return cachedWalk;
	}

	public static float GetSprintSpeedBonus()
	{
		return cachedSprint;
	}

	public static float GetCrouchSpeedBonus()
	{
		return cachedCrouch;
	}

	public static float GetSpeedPenalty()
	{
		return cachedSpeedPenalty;
	}

	public static float GetWindResist()
	{
		return cachedWindResist;
	}

	public static float GetWarmthBonus()
	{
		return cachedWarmth;
	}

	public static float GetFatigueReduction()
	{
		return cachedFatigueReduction;
	}

	public static float GetHungerReduction()
	{
		return cachedHungerReduction;
	}

	public static float GetVitalityBonus()
	{
		return cachedVitality;
	}

	public static float GetWeightDownPenalty()
	{
		return cachedWeightDownPenalty;
	}

	public static float GetProtectionBonus()
	{
		return cachedProtection;
	}

	public static float GetVitalityDownPenalty()
	{
		return cachedVitalityDownPenalty;
	}

	public static float GetDecayEfficiency()
	{
		return cachedDecayEfficiency;
	}

	public static float GetBuffDuration()
	{
		return cachedBuffDuration;
	}

	public static float GetCraftSpeed()
	{
		return cachedCraftSpeed;
	}

	public static float GetBleedResist()
	{
		return cachedBleedResist;
	}

	public static float GetHarvestBonus()
	{
		return cachedHarvestBonus;
	}

	public static float GetThirstDown()
	{
		return cachedThirstDown;
	}

	public static float GetToolDurability()
	{
		return cachedToolDurability;
	}

	public static float GetFishingBonus()
	{
		return cachedFishingBonus;
	}

	public static float GetSprintStamina()
	{
		return cachedSprintStamina;
	}

	public static int GetActiveLootSlotCount() => cachedActiveLootSlots;
	public static int GetActiveQuickSlotCount() => cachedActiveQuickSlots;
	public static int GetActivePresetSlotCount() => cachedActivePresetSlots;
	public static float GetActiveLootRadius() => cachedActiveLootRadius;
	public static float GetFireStartBonus() => cachedFireStartBonus;
	public static float GetColdAdapt() => cachedColdAdapt;
	public static float GetBowSteadiness() => cachedBowSteadiness;
	public static float GetCarcassHarvest() => cachedCarcassHarvest;
}
