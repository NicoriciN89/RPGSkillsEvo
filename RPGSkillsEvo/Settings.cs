using ModSettings;

namespace RPGSkillsEvo;

internal class RPGSettings : JsonModSettings
{
    [Section("Experience")]

    [Name("XP per skill increment")]
    [Description("XP awarded each time a vanilla skill (fire, fishing, repair, etc.) increments.")]
    [Slider(0f, 10f, 21, NumberFormat = "{0:0.0}")]
    public float XpPerSkill = 1f;

    [Name("Kill XP multiplier")]
    [Description("Multiplier for XP from killing animals. Base: rabbit=5, wolf=10, bear=20, moose=50.")]
    [Slider(0f, 5f, 11, NumberFormat = "{0:0.0}x")]
    public float XpKillMultiplier = 1f;

    [Section("Skill Points")]

    [Name("Starting skill points")]
    [Description("Skill points given at the start of each new playthrough.")]
    [Slider(0, 20)]
    public int StartPoints = 1;

    [Name("Skill points per level-up")]
    [Description("Skill points granted each time you level up.")]
    [Slider(1, 20)]
    public int PointsPerLevel = 5;

    [Section("HUD")]

    [Name("Show HUD numbers")]
    [Description("Show numeric values (HP, temperature, fatigue, thirst, hunger) below the HUD stat icons.")]
    public bool ShowHUDNumbers = true;
}

internal static class Settings
{
    internal static RPGSettings options = new RPGSettings();

    internal static float XpPerSkill       => options.XpPerSkill;
    internal static float XpKillMultiplier => options.XpKillMultiplier;
    internal static int   StartPoints      => options.StartPoints;
    internal static int   PointsPerLevel   => options.PointsPerLevel;
    internal static bool  ShowHUDNumbers   => options.ShowHUDNumbers;

    internal static void Init()
    {
        options = new RPGSettings();
        options.AddToModSettings("RPG Skills Evo");
    }
}
