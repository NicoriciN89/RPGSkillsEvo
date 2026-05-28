# RPG Skills Evo — The Long Dark Mod

An independent mod for *The Long Dark* adding RPG-style skill progression, localization, and quality-of-life features.

> **Note:** This is an independent project, not an official continuation or co-developed version of any other mod.

---

## Features

- RPG-style skill tree with experience and skill points
- Configurable XP rates, kill XP multiplier, starting/per-level skill points
- Auto-loot system with custom item lists
- Quickbar for fast item access
- Numeric HUD values (HP, temperature, fatigue, thirst, hunger)
- Full localization in 19 languages (English, Russian, Ukrainian, German, French, Spanish, Italian, Dutch, Polish, Czech, Korean, Japanese, Chinese Simplified/Traditional, Turkish, Brazilian Portuguese, Portuguese, Finnish, Norwegian, Swedish)

---

## Requirements

- [The Long Dark](https://store.steampowered.com/app/305620/) (latest version)
- [MelonLoader](https://github.com/LavaGang/MelonLoader) v0.8.0+
- [ModSettings](https://www.nexusmods.com/thelongdark/mods/111) mod

---

## Building from source

1. Install The Long Dark and MelonLoader.
2. Open `RPG Skills Evo.csproj` and update all `<HintPath>` values to match your local installation path (default: `e:\games\TheLongDark\...`).
3. Run `dotnet build "RPG Skills Evo.csproj" -c Release`.
4. Copy `bin/Release/net472/RPG Skills Evo.dll` to your `Mods/` folder.

---

## License

MIT — see [LICENSE](LICENSE).
