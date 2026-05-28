using System.Collections.Generic;

namespace RPGSkillsEvo;

public static class NodeDatabase
{
	public static List<SkillNode> AllNodes;

	static NodeDatabase()
	{
		AllNodes = new List<SkillNode>();
		AllNodes.Add(new SkillNode("CORE", "중앙 코어", "Core", 0, 0, 1, null, "CORE", 1, EffectType.Unlock));
		AllNodes.Add(new SkillNode("W6", "힘 능력 개방", "Strength Awakening", -6, 0, 1, "CORE", "Power", 1, EffectType.Unlock));
		AllNodes.Add(new SkillNode("W7", "가방 무게상한 증가 I", "Carry Weight I", -7, 0, 5, "W6", "Backpack UP", 1, EffectType.WeightUp, 1f, PenaltyType.SpeedDown, 2f));
		AllNodes.Add(new SkillNode("W7N1", "무게 패널티 상쇄 I", "Weight Penalty Reduce I", -7, -1, 5, "W7", "Backpack UP", 1, EffectType.SpeedPenaltyOffset, 1f));
		AllNodes.Add(new SkillNode("W8", "가방 무게상한 증가 II", "Carry Weight II", -8, 0, 5, "W7", "Backpack UP+", 2, EffectType.WeightUp, 2f, PenaltyType.SpeedDown, 4f));
		AllNodes.Add(new SkillNode("W8N1", "무게 패널티 상쇄 II", "Weight Penalty Reduce II", -8, -1, 5, "W8", "Backpack UP+", 2, EffectType.SpeedPenaltyOffset, 2f));
		AllNodes.Add(new SkillNode("W9", "가방 무게상한 증가 III", "Carry Weight III", -9, 0, 5, "W8", "Backpack UP++", 3, EffectType.WeightUp, 5f, PenaltyType.SpeedDown, 6f));
		AllNodes.Add(new SkillNode("W9N1", "무게 패널티 상쇄 III", "Weight Penalty Reduce III", -9, -1, 5, "W9", "Backpack UP++", 3, EffectType.SpeedPenaltyOffset, 3f));
		AllNodes.Add(new SkillNode("W10", "가방 무게상한 증가 Master", "Carry Weight Master", -10, 0, 999, "W9", "Backpack Master", 5, EffectType.WeightUp, 5f));
		AllNodes.Add(new SkillNode("W6N1", "보호 증가 I", "Protection I", -6, -1, 5, "W6", "Shield", 1, EffectType.ProtectionUp, 1f, PenaltyType.VitalityDown, 1f));
		AllNodes.Add(new SkillNode("W6N2", "보호 증가 II", "Protection II", -6, -2, 5, "W6N1", "Shield", 3, EffectType.ProtectionUp, 3f, PenaltyType.VitalityDown, 1f));
		AllNodes.Add(new SkillNode("E6", "민첩 능력 개방", "Agility Awakening", 6, 0, 1, "CORE", "UpSpeed", 1, EffectType.Unlock));
		AllNodes.Add(new SkillNode("E7", "걷기 속도 I", "Walk Speed I", 7, 0, 5, "E6", "Walking", 1, EffectType.WalkSpeed, 2f));
		AllNodes.Add(new SkillNode("E7N1", "질주 속도 I", "Sprint Speed I", 7, -1, 5, "E7", "Running", 1, EffectType.SprintSpeed, 2f));
		AllNodes.Add(new SkillNode("E7S1", "은신 속도 I", "Crouch Speed I", 7, 1, 5, "E7", "Crouching", 1, EffectType.CrouchSpeed, 4f));
		AllNodes.Add(new SkillNode("E8", "걷기 속도 II", "Walk Speed II", 8, 0, 5, "E7", "Walking", 2, EffectType.WalkSpeed, 4f));
		AllNodes.Add(new SkillNode("E7N1E1", "질주 속도 II", "Sprint Speed II", 8, -1, 5, "E7N1", "Running", 2, EffectType.SprintSpeed, 4f));
		AllNodes.Add(new SkillNode("E7S1E1", "은신 속도 II", "Crouch Speed II", 8, 1, 5, "E7S1", "Crouching", 2, EffectType.CrouchSpeed, 8f));
		AllNodes.Add(new SkillNode("E9", "걷기 속도 III", "Walk Speed III", 9, 0, 5, "E8", "Walking", 2, EffectType.WalkSpeed, 8f));
		AllNodes.Add(new SkillNode("E7N1E2", "질주 속도 III", "Sprint Speed III", 9, -1, 5, "E7N1E1", "Running", 2, EffectType.SprintSpeed, 8f));
		AllNodes.Add(new SkillNode("E7S1E2", "은신 속도 III", "Crouch Speed III", 9, 1, 5, "E7S1E1", "Crouching", 2, EffectType.CrouchSpeed, 16f));
		AllNodes.Add(new SkillNode("E6S1", "바람 저항 능력 개방", "Wind Resist Awakening", 6, 1, 1, "E6", "Wind", 5, EffectType.WindResistUnlock));
		AllNodes.Add(new SkillNode("E6S2", "바람 저항 I", "Wind Resist I", 6, 2, 5, "E6S1", "Wind", 1, EffectType.WindResist, 4f));
		AllNodes.Add(new SkillNode("E6S3", "바람 저항 II", "Wind Resist II", 6, 3, 5, "E6S2", "Wind", 1, EffectType.WindResist, 6f));
		AllNodes.Add(new SkillNode("E6S4", "바람 저항 III", "Wind Resist III", 6, 4, 5, "E6S3", "Wind Master", 1, EffectType.WindResist, 10f));
		AllNodes.Add(new SkillNode("S6", "탐색 능력 개방", "Exploration Awakening", 0, 6, 1, "CORE", "Search", 5, EffectType.Unlock));
		AllNodes.Add(new SkillNode("S6W1", "오토루팅 능력 개방", "Auto Loot Awakening", -1, 6, 1, "S6", "Magnet", 5, EffectType.AutoLootUnlock));
		AllNodes.Add(new SkillNode("S6W1S1", "루팅 반경 확장 I", "Loot Radius Expand I", -1, 7, 5, "S6W1", "Magnet", 1, EffectType.LootRadius, 5f));
		AllNodes.Add(new SkillNode("S6W2", "루팅 슬롯 확장 I", "Loot Slot Expand I", -2, 6, 5, "S6W1", "Magnet", 1, EffectType.LootSlot, 1f));
		AllNodes.Add(new SkillNode("S6W2S1", "루팅 반경 확장 II", "Loot Radius Expand II", -2, 7, 5, "S6W2", "Magnet", 1, EffectType.LootRadius, 5f));
		AllNodes.Add(new SkillNode("S6W3", "루팅 슬롯 확장 II", "Loot Slot Expand II", -3, 6, 5, "S6W2", "Magnet", 2, EffectType.LootSlot, 1f));
		AllNodes.Add(new SkillNode("S6W3S1", "루팅 반경 확장 III", "Loot Radius Expand III", -3, 7, 9, "S6W3", "Magnet", 2, EffectType.LootRadius, 5f));
		AllNodes.Add(new SkillNode("S7", "아이콘 추적 능력 개방", "Map Track Awakening", 0, 7, 1, "S6", "Search", 5, EffectType.MapTrackUnlock));
		AllNodes.Add(new SkillNode("S8", "추적 화살표 개방", "Track Arrow", 0, 8, 1, "S7", "Search", 10, EffectType.MapTrackArrow));
		AllNodes.Add(new SkillNode("S9", "추적 높낮이 개방", "Track Altitude", 0, 9, 1, "S8", "Search", 10, EffectType.MapTrackHeight));
		AllNodes.Add(new SkillNode("N6", "전투 능력 개방", "Combat Awakening", 0, -6, 1, "CORE", "Tactical", 1, EffectType.Unlock));
		AllNodes.Add(new SkillNode("N6W1", "퀵슬롯 능력 개방", "Quickslot Awakening", -1, -6, 1, "N6", "QuickbarIcon", 5, EffectType.QuickSlotUnlock));
		AllNodes.Add(new SkillNode("N6W1N1", "프리셋 능력 개방", "Preset Awakening", -1, -7, 1, "N6W1", "QuickbarIcon", 5, EffectType.PresetUnlock));
		AllNodes.Add(new SkillNode("N6W1N1W1", "퀵슬롯 증가", "Quickslot Expand", -2, -7, 5, "N6W1N1", "QuickbarIcon", 2, EffectType.QuickSlot, 1f));
		AllNodes.Add(new SkillNode("N6W1N2", "프리셋 슬롯 증가", "Preset Expand", -1, -8, 1, "N6W1N1", "QuickbarIcon", 3, EffectType.PresetSlot, 1f));
		AllNodes.Add(new SkillNode("N6E1", "확대경 능력 개방", "Scope Awakening", 1, -6, 1, "N6", "Scope", 5, EffectType.RevolverAimMove));
		AllNodes.Add(new SkillNode("N6E1N1", "라이플 확대경 개방", "Rifle Scope", 1, -7, 1, "N6E1", "Scope", 5, EffectType.RifleZoomUnlock));
		AllNodes.Add(new SkillNode("N6E1N2", "라이플 확대경 거리 증가 I", "Rifle Scope Range I", 1, -8, 5, "N6E1N1", "Scope", 2, EffectType.RifleZoomRange1, 1f));
		AllNodes.Add(new SkillNode("N6E1N3", "라이플 확대경 거리 증가 II", "Rifle Scope Range II", 1, -9, 5, "N6E1N2", "Scope", 3, EffectType.RifleZoomRange2, 2f));
		AllNodes.Add(new SkillNode("N6E1N1E1", "리볼버 확대경 개방", "Revolver Scope", 2, -7, 1, "N6E1N1", "Scope", 5, EffectType.RevolverZoomUnlock));
		AllNodes.Add(new SkillNode("N6E1N1E1N1", "리볼버 확대경 거리 증가", "Revolver Scope Range", 2, -8, 3, "N6E1N1E1", "Scope", 1, EffectType.RevolverZoomRange, 1f));
		AllNodes.Add(new SkillNode("WS5", "생존 능력 개방", "Survival Awakening", -5, 5, 1, "CORE", "Heart", 5, EffectType.Unlock));
		AllNodes.Add(new SkillNode("WS5S1", "체온 증가 I", "Warmth I", -5, 6, 5, "WS5", "Thermometer", 1, EffectType.WarmthUp, 1f));
		AllNodes.Add(new SkillNode("WS5S2", "체온 증가 II", "Warmth II", -5, 7, 5, "WS5S1", "Thermometer", 2, EffectType.WarmthUp, 1f));
		AllNodes.Add(new SkillNode("WS5W1", "피로 감소 I", "Fatigue Reduction I", -6, 5, 5, "WS5", "", 2, EffectType.FatigueDown, 2f));
		AllNodes.Add(new SkillNode("WS5W2", "피로 감소 II", "Fatigue Reduction II", -7, 5, 5, "WS5W1", "", 3, EffectType.FatigueDown, 2f));
		AllNodes.Add(new SkillNode("WS6", "허기 감소 I", "Hunger Reduction I", -6, 6, 5, "WS5", "", 1, EffectType.HungerDown, 1f));
		AllNodes.Add(new SkillNode("WS7", "허기 감소 II", "Hunger Reduction II", -7, 7, 5, "WS6", "", 2, EffectType.HungerDown, 1f));
		AllNodes.Add(new SkillNode("WS5WN1", "혹독한 환경속 진화 I", "Harsh Evolution I", -6, 4, 5, "WS5", "Heart", 1, EffectType.VitalityUp, 1f, PenaltyType.WeightDown, 1f));
		AllNodes.Add(new SkillNode("WS5WN1W1", "혹독한 환경속 진화 II", "Harsh Evolution II", -7, 4, 5, "WS5WN1", "Heart", 2, EffectType.VitalityUp, 2f, PenaltyType.WeightDown, 1f));
		AllNodes.Add(new SkillNode("WS5WN1W2", "생존 전문가", "Survival Expert", -8, 4, 5, "WS5WN1W1", "Heart", 5, EffectType.VitalityUp, 5f, PenaltyType.WeightDown, 2f));
		AllNodes.Add(new SkillNode("WS5N1", "출혈 저항 I", "Bleed Resist I", -5, 4, 5, "WS5", "Heart", 2, EffectType.BleedResist, 5f));
		AllNodes.Add(new SkillNode("WS5N2", "출혈 저항 II", "Bleed Resist II", -5, 3, 5, "WS5N1", "Heart", 3, EffectType.BleedResist, 5f));
		AllNodes.Add(new SkillNode("WS5E1", "채집 보너스 I", "Harvest Bonus I", -4, 5, 5, "WS5", "Heart", 2, EffectType.HarvestBonus, 5f));
		AllNodes.Add(new SkillNode("WS5E2", "채집 보너스 II", "Harvest Bonus II", -4, 4, 5, "WS5E1", "Heart", 3, EffectType.HarvestBonus, 5f));
		AllNodes.Add(new SkillNode("ES5", "종합 관리능력 개방", "Management Awakening", 5, 5, 1, "CORE", "BackPackBarrier", 5, EffectType.Unlock));
		AllNodes.Add(new SkillNode("ES5S1", "내구도 효율 I", "Durability Efficiency I", 5, 6, 5, "ES5", "BackPackBarrier", 2, EffectType.DecayEfficiency, 1f));
		AllNodes.Add(new SkillNode("ES5S2", "내구도 효율 II", "Durability Efficiency II", 5, 7, 5, "ES5S1", "BackPackBarrier", 5, EffectType.DecayEfficiency, 3f));
		AllNodes.Add(new SkillNode("ES5N1", "수리 속도 I", "Craft Speed I", 5, 4, 5, "ES5", "BackPackBarrier", 2, EffectType.CraftSpeed, 5f));
		AllNodes.Add(new SkillNode("ES5N2", "수리 속도 II", "Craft Speed II", 5, 3, 5, "ES5N1", "BackPackBarrier", 3, EffectType.CraftSpeed, 5f));
		AllNodes.Add(new SkillNode("ES6", "버프 지속시간 증가 I", "Buff Duration I", 6, 6, 5, "ES5", "", 2, EffectType.BuffDuration, 4f, PenaltyType.VitalityDown, 1f));
		AllNodes.Add(new SkillNode("ES7", "버프 지속시간 증가 II", "Buff Duration II", 7, 7, 5, "ES6", "", 4, EffectType.BuffDuration, 6f, PenaltyType.VitalityDown, 1f));
		AllNodes.Add(new SkillNode("ES8", "버프 중독", "Buff Addiction", 8, 8, 5, "ES7", "", 6, EffectType.BuffDuration, 10f, PenaltyType.VitalityDown, 2f));
			// ThirstDown — extends from WS7 (Hunger II)
			AllNodes.Add(new SkillNode("WS7N1", "갈증 감소 I", "Thirst Reduction I", -7, 8, 5, "WS7", "Heart", 2, EffectType.ThirstDown, 5f));
			AllNodes.Add(new SkillNode("WS7N2", "갈증 감소 II", "Thirst Reduction II", -7, 9, 5, "WS7N1", "Heart", 3, EffectType.ThirstDown, 5f));
			// ToolDurability — west branch of ES5 (Management)
			AllNodes.Add(new SkillNode("ES5W1", "도구 내구도 I", "Tool Durability I", 4, 5, 5, "ES5", "BackPackBarrier", 2, EffectType.ToolDurability, 5f));
			AllNodes.Add(new SkillNode("ES5W2", "도구 내구도 II", "Tool Durability II", 4, 4, 5, "ES5W1", "BackPackBarrier", 3, EffectType.ToolDurability, 5f));
			// FishingBonus — east branch of S6 (Exploration)
			AllNodes.Add(new SkillNode("S6E1", "낚시 보너스 I", "Fishing Bonus I", 1, 6, 5, "S6", "Search", 2, EffectType.FishingBonus, 10f));
			AllNodes.Add(new SkillNode("S6E2", "낚시 보너스 II", "Fishing Bonus II", 1, 7, 5, "S6E1", "Search", 3, EffectType.FishingBonus, 10f));
			// SprintStamina — extends from Sprint Speed III (E7N1E2)
			AllNodes.Add(new SkillNode("E7N1E3", "질주 지구력 I", "Sprint Stamina I", 10, -1, 5, "E7N1E2", "Running", 2, EffectType.SprintStamina, 10f));
			AllNodes.Add(new SkillNode("E7N1E4", "질주 지구력 II", "Sprint Stamina II", 11, -1, 5, "E7N1E3", "Running", 3, EffectType.SprintStamina, 10f));
	}

	public static SkillNode GetByID(string id)
	{
		return AllNodes.Find((SkillNode n) => n.ID == id);
	}

	public static SkillNode GetByCoord(int x, int y)
	{
		return AllNodes.Find((SkillNode n) => n.GridX == x && n.GridY == y);
	}
}
