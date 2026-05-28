namespace RPGSkillsEvo;

public class SkillNode
{
	public string ID;

	public string Name;

	public string NameEn;

	public string IconID;

	public int GridX;

	public int GridY;

	public int MaxLevel;

	public int Cost;

	public string RequiredNodeID;

	public EffectType Effect = EffectType.None;

	public float EffectPerLevel = 0f;

	public PenaltyType Penalty = PenaltyType.None;

	public float PenaltyPerLevel = 0f;

	public SkillNode(string id, string name, string nameEn, int x, int y, int maxLvl, string reqId = null, string iconID = "", int cost = 1, EffectType effect = EffectType.None, float effectPerLevel = 0f, PenaltyType penalty = PenaltyType.None, float penaltyPerLevel = 0f)
	{
		ID = id;
		Name = name;
		NameEn = nameEn;
		GridX = x;
		GridY = y;
		MaxLevel = maxLvl;
		RequiredNodeID = reqId;
		IconID = iconID;
		Cost = cost;
		Effect = effect;
		EffectPerLevel = effectPerLevel;
		Penalty = penalty;
		PenaltyPerLevel = penaltyPerLevel;
	}

	public string GetLocalizedName()
	{
		return Loc.Get("RPG.NODE." + ID);
	}
}
