using System.Collections.Generic;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

public class QuickPresetData
{
	public string PresetName = "New Preset";

	public Dictionary<ClothSlotID, int> ClothingInstanceIDs = new Dictionary<ClothSlotID, int>();

	public Dictionary<ClothSlotID, string> ClothingNames = new Dictionary<ClothSlotID, string>();

	public int GetInstanceID(ClothSlotID id)
	{
		return ClothingInstanceIDs.ContainsKey(id) ? ClothingInstanceIDs[id] : (-1);
	}

	public string GetName(ClothSlotID id)
	{
		return ClothingNames.ContainsKey(id) ? ClothingNames[id] : "";
	}

	public void SetClothing(ClothSlotID id, GearItem gi)
	{
		if ((UnityEngine.Object)(object)gi == (UnityEngine.Object)null)
		{
			ClothingInstanceIDs.Remove(id);
			ClothingNames.Remove(id);
		}
		else
		{
			ClothingInstanceIDs[id] = gi.m_InstanceID;
			ClothingNames[id] = ((UnityEngine.Object)gi).name;
		}
	}

	public void CopyFrom(QuickPresetData other)
	{
		PresetName = other.PresetName;
		ClothingInstanceIDs = new Dictionary<ClothSlotID, int>(other.ClothingInstanceIDs);
		ClothingNames = new Dictionary<ClothSlotID, string>(other.ClothingNames);
	}
}
