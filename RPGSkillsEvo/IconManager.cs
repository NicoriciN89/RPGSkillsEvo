using System.Collections.Generic;
using System.IO;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader.Utils;
using UnityEngine;

namespace RPGSkillsEvo;

public static class IconManager
{
	private static Dictionary<string, Texture2D> cachedIcons = new Dictionary<string, Texture2D>();

	public static Texture2D GetIcon(string iconID)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		if (string.IsNullOrEmpty(iconID))
		{
			return null;
		}
		if (cachedIcons.ContainsKey(iconID) && (UnityEngine.Object)(object)cachedIcons[iconID] != (UnityEngine.Object)null)
		{
			return cachedIcons[iconID];
		}
		string path = Path.Combine(MelonEnvironment.GameRootDirectory, "Mods", "RPG_Icons", iconID + ".png");
		if (File.Exists(path))
		{
			byte[] array = File.ReadAllBytes(path);
			Texture2D val = new Texture2D(2, 2, (TextureFormat)4, false);
			if (ImageConversion.LoadImage(val, (Il2CppStructArray<byte>)(array)))
			{
				((Texture)val).filterMode = (FilterMode)0;
				((Texture)val).wrapMode = (TextureWrapMode)1;
				Object.DontDestroyOnLoad((UnityEngine.Object)(object)val);
				cachedIcons[iconID] = val;
				return val;
			}
		}
		return null;
	}

	public static void ClearCache()
	{
		cachedIcons.Clear();
	}
}
