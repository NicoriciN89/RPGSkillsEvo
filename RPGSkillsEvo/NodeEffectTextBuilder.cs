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
		case EffectType.BuffDuration:
		{
			string text = Loc.Get("RPG.DESC.BUFF_DURATION", node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += Loc.Get("RPG.DESC.VITALITY_PENALTY_SUFFIX", node.PenaltyPerLevel);
			}
			return text;
		}
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
		case EffectType.BuffDuration:
		{
			string text = Loc.Get("RPG.VAL.BUFF_DURATION", (float)lvl * node.EffectPerLevel, Status.GetBuffDuration() * 100f);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += Loc.Get("RPG.VAL.VITALITY_PENALTY", (float)lvl * node.PenaltyPerLevel);
			}
			return text;
		}
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
		case EffectType.BuffDuration:
		{
			string text = Loc.Get("RPG.VAL.BUFF_DURATION", (float)num * node.EffectPerLevel);
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += Loc.Get("RPG.VAL.VITALITY_PENALTY", (float)num * node.PenaltyPerLevel);
			}
			return text;
		}
		default:
			return "-";
		}
	}

	public static string BuildDescriptionEn(SkillNode node)
	{
		switch (node.Effect)
		{
		case EffectType.Unlock:
			if (node.ID == "WS5")
			{
				return "Unlocks " + node.NameEn + ".\nStats are displayed as numbers on the HUD.";
			}
			return "Unlocks " + node.NameEn + ".";
		case EffectType.AutoLootUnlock:
			return "Unlocks the ability to automatically loot items.";
		case EffectType.QuickSlotUnlock:
			return "Unlocks the Quickslot feature.\nUse items quickly with hotkeys.";
		case EffectType.PresetUnlock:
			return "Unlocks the Outfit Preset feature.\nQuickly apply saved outfit sets.";
		case EffectType.WindResistUnlock:
			return "Unlocks wind resistance.\nReduces movement speed penalty from wind.";
		case EffectType.RevolverAimMove:
			return "Allows movement while aiming with a revolver.\nMovement speed reduced by 10% while aiming.";
		case EffectType.RifleZoomUnlock:
			return "Allows mouse wheel zoom while aiming with a rifle.\nDefault max zoom is 5x.";
		case EffectType.RifleZoomRange1:
			return $"Increases max rifle scope zoom.\n+{node.EffectPerLevel:F0}x max zoom per point.";
		case EffectType.RifleZoomRange2:
			return $"Greatly increases max rifle scope zoom.\n+{node.EffectPerLevel:F0}x max zoom per point.";
		case EffectType.RevolverZoomUnlock:
			return "Allows mouse wheel zoom while aiming with a revolver.\nDefault max zoom is 2x.";
		case EffectType.RevolverZoomRange:
			return $"Increases max revolver scope zoom.\n+{node.EffectPerLevel:F0}x max zoom per point.\nCan be extended up to 5x.";
		case EffectType.WeightUp:
		{
			string text4 = $"Increases carry weight limit.\n+{node.EffectPerLevel}kg per point.";
			if (node.Penalty == PenaltyType.SpeedDown)
			{
				text4 += $"\n-{node.PenaltyPerLevel}% speed per point.";
			}
			return text4;
		}
		case EffectType.SpeedPenaltyOffset:
			return $"Offsets speed penalty from weight.\n-{node.EffectPerLevel}% speed penalty per point.";
		case EffectType.WalkSpeed:
			return $"Increases walking speed.\n+{node.EffectPerLevel}% per point.";
		case EffectType.SprintSpeed:
			return $"Increases sprinting speed.\n+{node.EffectPerLevel}% per point.";
		case EffectType.CrouchSpeed:
			return $"Increases crouching speed.\n+{node.EffectPerLevel}% per point.";
		case EffectType.LootSlot:
			return $"Increases Auto Loot slots.\n+{(int)node.EffectPerLevel} slot per point.";
		case EffectType.LootRadius:
			return $"Increases Auto Loot detection radius.\n+{node.EffectPerLevel}m per point.";
		case EffectType.QuickSlot:
			return $"Increases Quickslot count.\n+{(int)node.EffectPerLevel} slot per point.";
		case EffectType.PresetSlot:
			return $"Increases Outfit Preset slots.\n+{(int)node.EffectPerLevel} slot per point.";
		case EffectType.MapTrackUnlock:
			return "Right-click any map icon to begin tracking.\nTarget name and distance shown on screen.";
		case EffectType.MapTrackArrow:
			return "Adds a directional arrow to the tracking HUD.\nVisually indicates the direction of your target.";
		case EffectType.MapTrackHeight:
			return "Adds altitude info to the tracking HUD.\nShows whether the target is above or below you.";
		case EffectType.WindResist:
			return $"Reduces wind-related movement penalty.\n{node.EffectPerLevel}% wind effect ignored per point.";
		case EffectType.WarmthUp:
			return $"Increases body warmth.\n+{node.EffectPerLevel}°C per point.";
		case EffectType.FatigueDown:
			return $"Reduces fatigue from all actions.\n-{node.EffectPerLevel}% fatigue per point.";
		case EffectType.HungerDown:
			return $"Reduces hunger from all actions.\n-{node.EffectPerLevel}% hunger per point.";
		case EffectType.VitalityUp:
		{
			string text3 = $"Increases max HP/Fatigue/Thirst.\n+{node.EffectPerLevel} max per point.";
			if (node.Penalty == PenaltyType.WeightDown)
			{
				text3 += $"\n-{node.PenaltyPerLevel}kg carry weight per point.";
			}
			return text3;
		}
		case EffectType.ProtectionUp:
		{
			string text2 = $"Reduces damage taken.\n+{node.EffectPerLevel}% protection per point.";
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text2 += $"\n-{node.PenaltyPerLevel} max HP/Fatigue/Thirst per point.";
			}
			return text2;
		}
		case EffectType.DecayEfficiency:
			return $"Reduces durability loss for food and clothing.\n+{node.EffectPerLevel}% decay suppression per point.";
		case EffectType.CraftSpeed:
			return $"Reduces repair and crafting time.\n-{node.EffectPerLevel}% time per point.";
		case EffectType.BleedResist:
			return $"Increases bleed-out time.\n+{node.EffectPerLevel}% bleed duration per point.";
		case EffectType.HarvestBonus:
			return $"Increases natural plant harvest yield.\n+{node.EffectPerLevel}% extra items per point.";
		case EffectType.ThirstDown:
			return $"Reduces dehydration drain rate.\n-{node.EffectPerLevel}% thirst per point.";
		case EffectType.ToolDurability:
			return $"Reduces condition loss from tool and weapon use.\n-{node.EffectPerLevel}% wear per point.";
		case EffectType.FishingBonus:
			return $"Increases caught fish weight.\n+{node.EffectPerLevel}% fish size per point.";
		case EffectType.BuffDuration:
		{
			string text = $"Increases buff duration for fatigue and weight buffs.\n+{node.EffectPerLevel}% buff duration per point.";
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += $"\n-{node.PenaltyPerLevel} max HP/Fatigue/Thirst per point.";
			}
			return text;
		}
		default:
			return "";
		}
	}

	public static string BuildCurrentValEn(SkillNode node, int lvl)
	{
		if (lvl == 0)
		{
			return "Not invested";
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
			return "Unlocked";
		case EffectType.WeightUp:
		{
			string text4 = $"Weight +{(float)lvl * node.EffectPerLevel}kg";
			if (node.Penalty == PenaltyType.SpeedDown)
			{
				text4 += $" / Speed -{(float)lvl * node.PenaltyPerLevel}%";
			}
			return text4;
		}
		case EffectType.SpeedPenaltyOffset:
			return $"Penalty -{(float)lvl * node.EffectPerLevel}% reduced";
		case EffectType.WalkSpeed:
			return $"Walk +{(float)lvl * node.EffectPerLevel}%";
		case EffectType.SprintSpeed:
			return $"Sprint +{(float)lvl * node.EffectPerLevel}%";
		case EffectType.CrouchSpeed:
			return $"Crouch +{(float)lvl * node.EffectPerLevel}%";
		case EffectType.LootSlot:
			return $"+{lvl} slot (Total: {AutoLootData.GetActiveSlotCount()})";
		case EffectType.LootRadius:
			return $"+{(float)lvl * node.EffectPerLevel}m (Total: {AutoLootData.GetActiveLootRadius():F0}m)";
		case EffectType.QuickSlot:
			return $"+{lvl} slot (Total: {QuickbarData.GetActiveSlotCount()})";
		case EffectType.PresetSlot:
			return $"+{lvl} slot (Total: {QuickbarData.GetActivePresetCount()})";
		case EffectType.WindResist:
			return $"{(float)lvl * node.EffectPerLevel}% wind ignored";
		case EffectType.RifleZoomRange1:
			return $"Rifle +{(float)lvl * node.EffectPerLevel:F0}x (Max: {GunZoomManager.GetRifleMaxZoom():F0}x)";
		case EffectType.RifleZoomRange2:
			return $"Rifle +{(float)lvl * node.EffectPerLevel:F0}x (Max: {GunZoomManager.GetRifleMaxZoom():F0}x)";
		case EffectType.RevolverZoomRange:
			return $"Revolver +{(float)lvl * node.EffectPerLevel:F0}x (Max: {GunZoomManager.GetRevolverMaxZoom():F0}x)";
		case EffectType.WarmthUp:
			return $"Warmth +{(float)lvl * node.EffectPerLevel}°C";
		case EffectType.FatigueDown:
			return $"Fatigue -{(float)lvl * node.EffectPerLevel}%";
		case EffectType.HungerDown:
			return $"Hunger -{(float)lvl * node.EffectPerLevel}%";
		case EffectType.VitalityUp:
		{
			string text3 = $"Max +{(float)lvl * node.EffectPerLevel}";
			if (node.Penalty == PenaltyType.WeightDown)
			{
				text3 += $" / Weight -{(float)lvl * node.PenaltyPerLevel}kg";
			}
			return text3;
		}
		case EffectType.ProtectionUp:
		{
			string text2 = $"Protection +{(float)lvl * node.EffectPerLevel}%";
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text2 += $" / Max -{(float)lvl * node.PenaltyPerLevel}";
			}
			return text2;
		}
		case EffectType.DecayEfficiency:
			return $"Decay suppression +{(float)lvl * node.EffectPerLevel}% (Total: {Status.GetDecayEfficiency() * 100f:F0}%)";
		case EffectType.CraftSpeed:
			return $"Repair time -{(float)lvl * node.EffectPerLevel}% (Total: -{Status.GetCraftSpeed() * 100f:F0}%)";
		case EffectType.BleedResist:
			return $"Bleed time +{(float)lvl * node.EffectPerLevel}% (Total: +{Status.GetBleedResist() * 100f:F0}%)";
		case EffectType.HarvestBonus:
			return $"Harvest +{(float)lvl * node.EffectPerLevel}% (Total: +{Status.GetHarvestBonus() * 100f:F0}%)";
		case EffectType.ThirstDown:
			return $"Thirst -{(float)lvl * node.EffectPerLevel}% (Total: -{Status.GetThirstDown() * 100f:F0}%)";
		case EffectType.ToolDurability:
			return $"Wear -{(float)lvl * node.EffectPerLevel}% (Total: -{Status.GetToolDurability() * 100f:F0}%)";
		case EffectType.FishingBonus:
			return $"Fish +{(float)lvl * node.EffectPerLevel}% (Total: +{Status.GetFishingBonus() * 100f:F0}%)";
		case EffectType.BuffDuration:
		{
			string text = $"Buff duration +{(float)lvl * node.EffectPerLevel}% (Total: {Status.GetBuffDuration() * 100f:F0}%)";
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += $" / Max -{(float)lvl * node.PenaltyPerLevel}";
			}
			return text;
		}
		default:
			return "Not invested";
		}
	}

	public static string BuildNextValEn(SkillNode node, int lvl, bool isMax)
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
			string text4 = $"Weight +{(float)num * node.EffectPerLevel}kg";
			if (node.Penalty == PenaltyType.SpeedDown)
			{
				text4 += $" / Speed -{(float)num * node.PenaltyPerLevel}%";
			}
			return text4;
		}
		case EffectType.SpeedPenaltyOffset:
			return $"Penalty -{(float)num * node.EffectPerLevel}% reduced";
		case EffectType.WalkSpeed:
			return $"Walk +{(float)num * node.EffectPerLevel}%";
		case EffectType.SprintSpeed:
			return $"Sprint +{(float)num * node.EffectPerLevel}%";
		case EffectType.CrouchSpeed:
			return $"Crouch +{(float)num * node.EffectPerLevel}%";
		case EffectType.LootSlot:
			return $"+{num} slot (Total: {AutoLootData.GetActiveSlotCount() + 1})";
		case EffectType.LootRadius:
			return $"+{(float)num * node.EffectPerLevel}m (Total: {AutoLootData.GetActiveLootRadius() + node.EffectPerLevel:F0}m)";
		case EffectType.QuickSlot:
			return $"+{num} slot (Total: {QuickbarData.GetActiveSlotCount() + 1})";
		case EffectType.PresetSlot:
			return $"+{num} slot (Total: {QuickbarData.GetActivePresetCount() + 1})";
		case EffectType.WindResist:
			return $"{(float)num * node.EffectPerLevel}% wind ignored";
		case EffectType.RifleZoomRange1:
			return string.Format("Rifle +{0:F0}x (Total: {1:F0}x)", (float)num * node.EffectPerLevel, 5f + (float)num * node.EffectPerLevel + (float)GetNodeLevel("N6E1N3") * 2f);
		case EffectType.RifleZoomRange2:
			return string.Format("Rifle +{0:F0}x (Total: {1:F0}x)", (float)num * node.EffectPerLevel, 5f + (float)GetNodeLevel("N6E1N2") * 1f + (float)num * node.EffectPerLevel);
		case EffectType.RevolverZoomRange:
			return $"Revolver +{(float)num * node.EffectPerLevel:F0}x (Total: {2f + (float)num * node.EffectPerLevel:F0}x)";
		case EffectType.WarmthUp:
			return $"Warmth +{(float)num * node.EffectPerLevel}°C";
		case EffectType.FatigueDown:
			return $"Fatigue -{(float)num * node.EffectPerLevel}%";
		case EffectType.HungerDown:
			return $"Hunger -{(float)num * node.EffectPerLevel}%";
		case EffectType.VitalityUp:
		{
			string text3 = $"Max +{(float)num * node.EffectPerLevel}";
			if (node.Penalty == PenaltyType.WeightDown)
			{
				text3 += $" / Weight -{(float)num * node.PenaltyPerLevel}kg";
			}
			return text3;
		}
		case EffectType.ProtectionUp:
		{
			string text2 = $"Protection +{(float)num * node.EffectPerLevel}%";
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text2 += $" / Max -{(float)num * node.PenaltyPerLevel}";
			}
			return text2;
		}
		case EffectType.DecayEfficiency:
			return $"Decay suppression +{(float)num * node.EffectPerLevel}%";
		case EffectType.CraftSpeed:
			return $"Repair time -{(float)num * node.EffectPerLevel}%";
		case EffectType.BleedResist:
			return $"Bleed time +{(float)num * node.EffectPerLevel}%";
		case EffectType.HarvestBonus:
			return $"Harvest +{(float)num * node.EffectPerLevel}%";
		case EffectType.ThirstDown:
			return $"Thirst -{(float)num * node.EffectPerLevel}%";
		case EffectType.ToolDurability:
			return $"Wear -{(float)num * node.EffectPerLevel}%";
		case EffectType.FishingBonus:
			return $"Fish +{(float)num * node.EffectPerLevel}%";
		case EffectType.BuffDuration:
		{
			string text = $"Buff duration +{(float)num * node.EffectPerLevel}%";
			if (node.Penalty == PenaltyType.VitalityDown)
			{
				text += $" / Max -{(float)num * node.PenaltyPerLevel}";
			}
			return text;
		}
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
