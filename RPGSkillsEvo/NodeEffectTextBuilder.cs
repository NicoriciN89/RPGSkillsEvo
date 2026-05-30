namespace RPGSkillsEvo;

public static class NodeEffectTextBuilder
{
	public static string BuildDescription(SkillNode node)
	{
		switch (node.Effect)
		{
		case EffectType.Unlock:
			if (node.ID == "WS5")
			{
				return Loc.Get("RPG.DESC.UNLOCK_SURVIVAL", node.GetLocalizedName());
			}
			return Loc.Get("RPG.DESC.UNLOCK", node.GetLocalizedName());
		case EffectType.AutoLootUnlock:
			return Loc.Get("RPG.DESC.AUTO_LOOT_UNLOCK");
		case EffectType.QuickSlotUnlock:
			return Loc.Get("RPG.DESC.QUICKSLOT_UNLOCK");
		case EffectType.PresetUnlock:
			return Loc.Get("RPG.DESC.PRESET_UNLOCK");
		case EffectType.WindResistUnlock:
			return Loc.Get("RPG.DESC.WIND_RESIST_UNLOCK");
		case EffectType.RevolverAimMove:
			return Loc.Get("RPG.DESC.REVOLVER_AIM_MOVE");
		case EffectType.RifleZoomUnlock:
			return Loc.Get("RPG.DESC.RIFLE_ZOOM_UNLOCK");
		case EffectType.RifleZoomRange1:
			return Loc.Get("RPG.DESC.RIFLE_ZOOM_RANGE1", node.EffectPerLevel);
		case EffectType.RifleZoomRange2:
			return Loc.Get("RPG.DESC.RIFLE_ZOOM_RANGE2", node.EffectPerLevel);
		case EffectType.RevolverZoomUnlock:
			return Loc.Get("RPG.DESC.REVOLVER_ZOOM_UNLOCK");
		case EffectType.RevolverZoomRange:
			return Loc.Get("RPG.DESC.REVOLVER_ZOOM_RANGE", node.EffectPerLevel);
		case EffectType.WeightUp:
		{
			string text4 = Loc.Get("RPG.DESC.WEIGHT_UP", node.EffectPerLevel);
			if (node.Penalty == PenaltyType.SpeedDown)
			{
				text4 += Loc.Get("RPG.DESC.SPEED_PENALTY_SUFFIX", node.PenaltyPerLevel);
			}
			return text4;
		}
		case EffectType.SpeedPenaltyOffset:
			return Loc.Get("RPG.DESC.SPEED_OFFSET", node.EffectPerLevel);
		case EffectType.WalkSpeed:
			return Loc.Get("RPG.DESC.WALK_SPEED", node.EffectPerLevel);
		case EffectType.SprintSpeed:
			return Loc.Get("RPG.DESC.SPRINT_SPEED", node.EffectPerLevel);
		case EffectType.CrouchSpeed:
			return Loc.Get("RPG.DESC.CROUCH_SPEED", node.EffectPerLevel);
		case EffectType.LootSlot:
			return Loc.Get("RPG.DESC.LOOT_SLOT", (int)node.EffectPerLevel);
		case EffectType.LootRadius:
			return Loc.Get("RPG.DESC.LOOT_RADIUS", node.EffectPerLevel);
		case EffectType.QuickSlot:
			return Loc.Get("RPG.DESC.QUICKSLOT", (int)node.EffectPerLevel);
		case EffectType.PresetSlot:
			return Loc.Get("RPG.DESC.PRESET_SLOT", (int)node.EffectPerLevel);
		case EffectType.MapTrackUnlock:
			return Loc.Get("RPG.DESC.MAP_TRACK_UNLOCK");
		case EffectType.MapTrackArrow:
			return Loc.Get("RPG.DESC.MAP_TRACK_ARROW");
		case EffectType.MapTrackHeight:
			return Loc.Get("RPG.DESC.MAP_TRACK_HEIGHT");
		case EffectType.WindResist:
			return Loc.Get("RPG.DESC.WIND_RESIST", node.EffectPerLevel);
		case EffectType.WarmthUp:
			return Loc.Get("RPG.DESC.WARMTH", node.EffectPerLevel);
		case EffectType.FatigueDown:
			return Loc.Get("RPG.DESC.FATIGUE_DOWN", node.EffectPerLevel);
		case EffectType.HungerDown:
			return Loc.Get("RPG.DESC.HUNGER_DOWN", node.EffectPerLevel);
		case EffectType.VitalityUp:
		{
			string text3 = Loc.Get("RPG.DESC.VITALITY_UP", node.EffectPerLevel);
			if (node.Penalty == PenaltyType.WeightDown)
			{
				text3 += Loc.Get("RPG.DESC.WEIGHT_PENALTY_SUFFIX", node.PenaltyPerLevel);
			}
			return text3;
		}
		case EffectType.ProtectionUp:
		{
			string text2 = Loc.Get("RPG.DESC.PROTECTION_UP", node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text2 += Loc.Get("RPG.DESC.VITALITY_PENALTY_SUFFIX", node.PenaltyPerLevel);
			}
			return text2;
		}
		case EffectType.DecayEfficiency:
			return Loc.Get("RPG.DESC.DECAY_EFFICIENCY", node.EffectPerLevel);
		case EffectType.CraftSpeed:
			return Loc.Get("RPG.DESC.CRAFT_SPEED", node.EffectPerLevel);
		case EffectType.BleedResist:
			return Loc.Get("RPG.DESC.BLEED_RESIST", node.EffectPerLevel);
		case EffectType.HarvestBonus:
			return Loc.Get("RPG.DESC.HARVEST_BONUS", node.EffectPerLevel);
		case EffectType.ThirstDown:
			return Loc.Get("RPG.DESC.THIRST_DOWN", node.EffectPerLevel);
		case EffectType.ToolDurability:
			return Loc.Get("RPG.DESC.TOOL_DURABILITY", node.EffectPerLevel);
		case EffectType.FishingBonus:
			return Loc.Get("RPG.DESC.FISHING_BONUS", node.EffectPerLevel);
		case EffectType.SprintStamina:
			return Loc.Get("RPG.DESC.SPRINT_STAMINA", node.EffectPerLevel);
		case EffectType.BuffDuration:
		{
			string text = Loc.Get("RPG.DESC.BUFF_DURATION", node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += Loc.Get("RPG.DESC.VITALITY_PENALTY_SUFFIX", node.PenaltyPerLevel);
			}
			return text;
		}
		case EffectType.FireStartBonus:
			return Loc.Get("RPG.DESC.FIRE_START", node.EffectPerLevel);
		case EffectType.ColdAdapt:
			return Loc.Get("RPG.DESC.COLD_ADAPT", node.EffectPerLevel);
		case EffectType.BowSteadiness:
			return Loc.Get("RPG.DESC.BOW_STEADINESS", node.EffectPerLevel);
		case EffectType.CarcassHarvest:
			return Loc.Get("RPG.DESC.CARCASS_HARVEST", node.EffectPerLevel);
		default:
			return "";
		}
	}

	public static string BuildCurrentVal(SkillNode node, int lvl)
	{
		if (lvl == 0)
		{
			return Loc.Get("RPG.VAL.NOT_INVESTED");
		}
		switch (node.Effect)
		{
		case EffectType.Unlock:
		case EffectType.AutoLootUnlock:
		case EffectType.QuickSlotUnlock:
		case EffectType.PresetUnlock:
		case EffectType.MapTrackUnlock:
		case EffectType.MapTrackArrow:
		case EffectType.MapTrackHeight:
		case EffectType.WindResistUnlock:
		case EffectType.RevolverAimMove:
		case EffectType.RifleZoomUnlock:
		case EffectType.RevolverZoomUnlock:
			return Loc.Get("RPG.VAL.UNLOCKED");
		case EffectType.WeightUp:
		{
			string text4 = Loc.Get("RPG.VAL.WEIGHT", (float)lvl * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.SpeedDown)
			{
				text4 += Loc.Get("RPG.VAL.SPEED_PENALTY", (float)lvl * node.PenaltyPerLevel);
			}
			return text4;
		}
		case EffectType.SpeedPenaltyOffset:
			return Loc.Get("RPG.VAL.SPEED_OFFSET", (float)lvl * node.EffectPerLevel);
		case EffectType.WalkSpeed:
			return Loc.Get("RPG.VAL.WALK", (float)lvl * node.EffectPerLevel);
		case EffectType.SprintSpeed:
			return Loc.Get("RPG.VAL.SPRINT", (float)lvl * node.EffectPerLevel);
		case EffectType.CrouchSpeed:
			return Loc.Get("RPG.VAL.CROUCH", (float)lvl * node.EffectPerLevel);
		case EffectType.LootSlot:
			return Loc.Get("RPG.VAL.LOOT_SLOT", lvl, AutoLootData.GetActiveSlotCount());
		case EffectType.LootRadius:
			return Loc.Get("RPG.VAL.LOOT_RADIUS", (float)lvl * node.EffectPerLevel, AutoLootData.GetActiveLootRadius());
		case EffectType.QuickSlot:
			return Loc.Get("RPG.VAL.QUICKSLOT", lvl, QuickbarData.GetActiveSlotCount());
		case EffectType.PresetSlot:
			return Loc.Get("RPG.VAL.PRESET_SLOT", lvl, QuickbarData.GetActivePresetCount());
		case EffectType.WindResist:
			return Loc.Get("RPG.VAL.WIND_RESIST", (float)lvl * node.EffectPerLevel);
		case EffectType.RifleZoomRange1:
			return Loc.Get("RPG.VAL.RIFLE_ZOOM", (float)lvl * node.EffectPerLevel, GunZoomManager.GetRifleMaxZoom());
		case EffectType.RifleZoomRange2:
			return Loc.Get("RPG.VAL.RIFLE_ZOOM", (float)lvl * node.EffectPerLevel, GunZoomManager.GetRifleMaxZoom());
		case EffectType.RevolverZoomRange:
			return Loc.Get("RPG.VAL.REVOLVER_ZOOM", (float)lvl * node.EffectPerLevel, GunZoomManager.GetRevolverMaxZoom());
		case EffectType.WarmthUp:
			return Loc.Get("RPG.VAL.WARMTH", (float)lvl * node.EffectPerLevel);
		case EffectType.FatigueDown:
			return Loc.Get("RPG.VAL.FATIGUE", (float)lvl * node.EffectPerLevel);
		case EffectType.HungerDown:
			return Loc.Get("RPG.VAL.HUNGER", (float)lvl * node.EffectPerLevel);
		case EffectType.VitalityUp:
		{
			string text3 = Loc.Get("RPG.VAL.VITALITY", (float)lvl * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.WeightDown)
			{
				text3 += Loc.Get("RPG.VAL.WEIGHT_PENALTY", (float)lvl * node.PenaltyPerLevel);
			}
			return text3;
		}
		case EffectType.ProtectionUp:
		{
			string text2 = Loc.Get("RPG.VAL.PROTECTION", (float)lvl * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text2 += Loc.Get("RPG.VAL.VITALITY_PENALTY", (float)lvl * node.PenaltyPerLevel);
			}
			return text2;
		}
		case EffectType.DecayEfficiency:
			return Loc.Get("RPG.VAL.DECAY", (float)lvl * node.EffectPerLevel, Status.GetDecayEfficiency() * 100f);
		case EffectType.CraftSpeed:
			return Loc.Get("RPG.VAL.CRAFT_SPEED", (float)lvl * node.EffectPerLevel, Status.GetCraftSpeed() * 100f);
		case EffectType.BleedResist:
			return Loc.Get("RPG.VAL.BLEED_RESIST", (float)lvl * node.EffectPerLevel, Status.GetBleedResist() * 100f);
		case EffectType.HarvestBonus:
			return Loc.Get("RPG.VAL.HARVEST_BONUS", (float)lvl * node.EffectPerLevel, Status.GetHarvestBonus() * 100f);
		case EffectType.ThirstDown:
			return Loc.Get("RPG.VAL.THIRST_DOWN", (float)lvl * node.EffectPerLevel, Status.GetThirstDown() * 100f);
		case EffectType.ToolDurability:
			return Loc.Get("RPG.VAL.TOOL_DURABILITY", (float)lvl * node.EffectPerLevel, Status.GetToolDurability() * 100f);
		case EffectType.FishingBonus:
			return Loc.Get("RPG.VAL.FISHING_BONUS", (float)lvl * node.EffectPerLevel, Status.GetFishingBonus() * 100f);
		case EffectType.SprintStamina:
			return Loc.Get("RPG.VAL.SPRINT_STAMINA", (float)lvl * node.EffectPerLevel, Status.GetSprintStamina() * 100f);
		case EffectType.BuffDuration:
		{
			string text = Loc.Get("RPG.VAL.BUFF_DURATION", (float)lvl * node.EffectPerLevel, Status.GetBuffDuration() * 100f);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += Loc.Get("RPG.VAL.VITALITY_PENALTY", (float)lvl * node.PenaltyPerLevel);
			}
			return text;
		}
		case EffectType.FireStartBonus:
			return Loc.Get("RPG.VAL.FIRE_START", (float)lvl * node.EffectPerLevel, Status.GetFireStartBonus() * 100f);
		case EffectType.ColdAdapt:
			return Loc.Get("RPG.VAL.COLD_ADAPT", (float)lvl * node.EffectPerLevel, Status.GetColdAdapt() * 100f);
		case EffectType.BowSteadiness:
			return Loc.Get("RPG.VAL.BOW_STEADINESS", (float)lvl * node.EffectPerLevel, Status.GetBowSteadiness() * 100f);
		case EffectType.CarcassHarvest:
			return Loc.Get("RPG.VAL.CARCASS_HARVEST", (float)lvl * node.EffectPerLevel, Status.GetCarcassHarvest() * 100f);
		default:
			return Loc.Get("RPG.VAL.NOT_INVESTED");
		}
	}

	public static string BuildNextVal(SkillNode node, int lvl, bool isMax)
	{
		if (isMax)
		{
			return "MAX";
		}
		int num = lvl + 1;
		switch (node.Effect)
		{
		case EffectType.Unlock:
		case EffectType.AutoLootUnlock:
		case EffectType.QuickSlotUnlock:
		case EffectType.PresetUnlock:
		case EffectType.MapTrackUnlock:
		case EffectType.MapTrackArrow:
		case EffectType.MapTrackHeight:
		case EffectType.WindResistUnlock:
		case EffectType.RevolverAimMove:
		case EffectType.RifleZoomUnlock:
		case EffectType.RevolverZoomUnlock:
			return "-";
		case EffectType.WeightUp:
		{
			string text4 = Loc.Get("RPG.VAL.WEIGHT", (float)num * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.SpeedDown)
			{
				text4 += Loc.Get("RPG.VAL.SPEED_PENALTY", (float)num * node.PenaltyPerLevel);
			}
			return text4;
		}
		case EffectType.SpeedPenaltyOffset:
			return Loc.Get("RPG.VAL.SPEED_OFFSET", (float)num * node.EffectPerLevel);
		case EffectType.WalkSpeed:
			return Loc.Get("RPG.VAL.WALK", (float)num * node.EffectPerLevel);
		case EffectType.SprintSpeed:
			return Loc.Get("RPG.VAL.SPRINT", (float)num * node.EffectPerLevel);
		case EffectType.CrouchSpeed:
			return Loc.Get("RPG.VAL.CROUCH", (float)num * node.EffectPerLevel);
		case EffectType.LootSlot:
			return Loc.Get("RPG.VAL.LOOT_SLOT", num, AutoLootData.GetActiveSlotCount() + 1);
		case EffectType.LootRadius:
			return Loc.Get("RPG.VAL.LOOT_RADIUS", (float)num * node.EffectPerLevel, AutoLootData.GetActiveLootRadius() + node.EffectPerLevel);
		case EffectType.QuickSlot:
			return Loc.Get("RPG.VAL.QUICKSLOT", num, QuickbarData.GetActiveSlotCount() + 1);
		case EffectType.PresetSlot:
			return Loc.Get("RPG.VAL.PRESET_SLOT", num, QuickbarData.GetActivePresetCount() + 1);
		case EffectType.WindResist:
			return Loc.Get("RPG.VAL.WIND_RESIST", (float)num * node.EffectPerLevel);
		case EffectType.RifleZoomRange1:
			return Loc.Get("RPG.VAL.RIFLE_ZOOM", (float)num * node.EffectPerLevel, 5f + (float)num * node.EffectPerLevel + (float)GetNodeLevel("N6E1N3") * 2f);
		case EffectType.RifleZoomRange2:
			return Loc.Get("RPG.VAL.RIFLE_ZOOM", (float)num * node.EffectPerLevel, 5f + (float)GetNodeLevel("N6E1N2") * 1f + (float)num * node.EffectPerLevel);
		case EffectType.RevolverZoomRange:
			return Loc.Get("RPG.VAL.REVOLVER_ZOOM", (float)num * node.EffectPerLevel, 2f + (float)num * node.EffectPerLevel);
		case EffectType.WarmthUp:
			return Loc.Get("RPG.VAL.WARMTH", (float)num * node.EffectPerLevel);
		case EffectType.FatigueDown:
			return Loc.Get("RPG.VAL.FATIGUE", (float)num * node.EffectPerLevel);
		case EffectType.HungerDown:
			return Loc.Get("RPG.VAL.HUNGER", (float)num * node.EffectPerLevel);
		case EffectType.VitalityUp:
		{
			string text3 = Loc.Get("RPG.VAL.VITALITY", (float)num * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.WeightDown)
			{
				text3 += Loc.Get("RPG.VAL.WEIGHT_PENALTY", (float)num * node.PenaltyPerLevel);
			}
			return text3;
		}
		case EffectType.ProtectionUp:
		{
			string text2 = Loc.Get("RPG.VAL.PROTECTION", (float)num * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text2 += Loc.Get("RPG.VAL.VITALITY_PENALTY", (float)num * node.PenaltyPerLevel);
			}
			return text2;
		}
		case EffectType.DecayEfficiency:
			return Loc.Get("RPG.VAL.DECAY", (float)num * node.EffectPerLevel);
		case EffectType.CraftSpeed:
			return Loc.Get("RPG.VAL.CRAFT_SPEED", (float)num * node.EffectPerLevel);
		case EffectType.BleedResist:
			return Loc.Get("RPG.VAL.BLEED_RESIST", (float)num * node.EffectPerLevel);
		case EffectType.HarvestBonus:
			return Loc.Get("RPG.VAL.HARVEST_BONUS", (float)num * node.EffectPerLevel);
		case EffectType.ThirstDown:
			return Loc.Get("RPG.VAL.THIRST_DOWN", (float)num * node.EffectPerLevel);
		case EffectType.ToolDurability:
			return Loc.Get("RPG.VAL.TOOL_DURABILITY", (float)num * node.EffectPerLevel);
		case EffectType.FishingBonus:
			return Loc.Get("RPG.VAL.FISHING_BONUS", (float)num * node.EffectPerLevel);
		case EffectType.SprintStamina:
			return Loc.Get("RPG.VAL.SPRINT_STAMINA", (float)num * node.EffectPerLevel);
		case EffectType.BuffDuration:
		{
			string text = Loc.Get("RPG.VAL.BUFF_DURATION", (float)num * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += Loc.Get("RPG.VAL.VITALITY_PENALTY", (float)num * node.PenaltyPerLevel);
			}
			return text;
		}
		case EffectType.FireStartBonus:
			return Loc.Get("RPG.VAL.FIRE_START", node.EffectPerLevel, Status.GetFireStartBonus() * 100f + node.EffectPerLevel);
		case EffectType.ColdAdapt:
			return Loc.Get("RPG.VAL.COLD_ADAPT", node.EffectPerLevel, Status.GetColdAdapt() * 100f + node.EffectPerLevel);
		case EffectType.BowSteadiness:
			return Loc.Get("RPG.VAL.BOW_STEADINESS", node.EffectPerLevel, Status.GetBowSteadiness() * 100f + node.EffectPerLevel);
		case EffectType.CarcassHarvest:
			return Loc.Get("RPG.VAL.CARCASS_HARVEST", node.EffectPerLevel, Status.GetCarcassHarvest() * 100f + node.EffectPerLevel);
		default:
			return "-";
		}
	}

	public static bool IsNodeMaxed(SkillNode node, int lvl)
	{
		return lvl >= node.MaxLevel;
	}

	private static int GetNodeLevel(string id)
	{
		return DataHub.RealNodes.ContainsKey(id) ? DataHub.RealNodes[id] : 0;
	}
}
