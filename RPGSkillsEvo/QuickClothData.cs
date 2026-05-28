using System.Collections.Generic;
using Il2Cpp;
using UnityEngine;

namespace RPGSkillsEvo;

public static class QuickClothData
{
	public struct SlotInfo
	{
		public ClothingRegion Region;

		public ClothingLayer Layer;
	}

	private static readonly Dictionary<ClothSlotID, SlotInfo> SlotDefinitions = new Dictionary<ClothSlotID, SlotInfo>
	{
		{
			ClothSlotID.Head_Inner,
			new SlotInfo
			{
				Region = (ClothingRegion)2,
				Layer = (ClothingLayer)0
			}
		},
		{
			ClothSlotID.Head_Outer,
			new SlotInfo
			{
				Region = (ClothingRegion)2,
				Layer = (ClothingLayer)1
			}
		},
		{
			ClothSlotID.Chest_InnerBase,
			new SlotInfo
			{
				Region = (ClothingRegion)4,
				Layer = (ClothingLayer)0
			}
		},
		{
			ClothSlotID.Chest_InnerMid,
			new SlotInfo
			{
				Region = (ClothingRegion)4,
				Layer = (ClothingLayer)1
			}
		},
		{
			ClothSlotID.Chest_InnerOuter,
			new SlotInfo
			{
				Region = (ClothingRegion)4,
				Layer = (ClothingLayer)2
			}
		},
		{
			ClothSlotID.Chest_Outer,
			new SlotInfo
			{
				Region = (ClothingRegion)4,
				Layer = (ClothingLayer)3
			}
		},
		{
			ClothSlotID.Hands,
			new SlotInfo
			{
				Region = (ClothingRegion)3,
				Layer = (ClothingLayer)0
			}
		},
		{
			ClothSlotID.Accessory1,
			new SlotInfo
			{
				Region = (ClothingRegion)7,
				Layer = (ClothingLayer)0
			}
		},
		{
			ClothSlotID.Accessory2,
			new SlotInfo
			{
				Region = (ClothingRegion)7,
				Layer = (ClothingLayer)1
			}
		},
		{
			ClothSlotID.Legs_Underwear1,
			new SlotInfo
			{
				Region = (ClothingRegion)5,
				Layer = (ClothingLayer)0
			}
		},
		{
			ClothSlotID.Legs_Underwear2,
			new SlotInfo
			{
				Region = (ClothingRegion)5,
				Layer = (ClothingLayer)1
			}
		},
		{
			ClothSlotID.Legs_Inner,
			new SlotInfo
			{
				Region = (ClothingRegion)5,
				Layer = (ClothingLayer)2
			}
		},
		{
			ClothSlotID.Legs_Outer,
			new SlotInfo
			{
				Region = (ClothingRegion)5,
				Layer = (ClothingLayer)3
			}
		},
		{
			ClothSlotID.Feet_Socks1,
			new SlotInfo
			{
				Region = (ClothingRegion)6,
				Layer = (ClothingLayer)0
			}
		},
		{
			ClothSlotID.Feet_Socks2,
			new SlotInfo
			{
				Region = (ClothingRegion)6,
				Layer = (ClothingLayer)1
			}
		},
		{
			ClothSlotID.Feet_Boots,
			new SlotInfo
			{
				Region = (ClothingRegion)6,
				Layer = (ClothingLayer)2
			}
		}
	};

	public static ClothingRegion GetRegion(ClothSlotID id)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		return (ClothingRegion)((!SlotDefinitions.ContainsKey(id)) ? 2 : ((int)SlotDefinitions[id].Region));
	}

	public static ClothingLayer GetLayer(ClothSlotID id)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		return (ClothingLayer)(SlotDefinitions.ContainsKey(id) ? ((int)SlotDefinitions[id].Layer) : 0);
	}

	public static bool IsValidForSlot(GearItem gi, ClothSlotID id)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected I4, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected I4, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected I4, but got Unknown
		if ((UnityEngine.Object)(object)gi == (UnityEngine.Object)null || (UnityEngine.Object)(object)gi.m_ClothingItem == (UnityEngine.Object)null)
		{
			return false;
		}
		if (!SlotDefinitions.TryGetValue(id, out var value))
		{
			return false;
		}
		if (gi.m_ClothingItem.m_Region != value.Region)
		{
			return false;
		}
		int num = (int)value.Layer;
		int num2 = (int)gi.m_ClothingItem.m_MinLayer;
		int num3 = (int)gi.m_ClothingItem.m_MaxLayer;
		return num >= num2 && num <= num3;
	}

	public static string GetShortName(ClothSlotID id)
	{
		if (1 == 0)
		{
		}
		string result = id switch
		{
			ClothSlotID.Head_Outer => "Head\nOuter", 
			ClothSlotID.Head_Inner => "Head\nInner", 
			ClothSlotID.Chest_Outer => "Chest\nOuter", 
			ClothSlotID.Chest_InnerOuter => "Chest\nInnerOut", 
			ClothSlotID.Chest_InnerMid => "Chest\nMid", 
			ClothSlotID.Chest_InnerBase => "Chest\nBase", 
			ClothSlotID.Legs_Outer => "Pants\nOuter", 
			ClothSlotID.Legs_Inner => "Pants\nInner", 
			ClothSlotID.Legs_Underwear1 => "Legs\nBase", 
			ClothSlotID.Legs_Underwear2 => "Legs\nOuter", 
			ClothSlotID.Feet_Socks1 => "Socks\n1", 
			ClothSlotID.Feet_Socks2 => "Socks\n2", 
			ClothSlotID.Feet_Boots => "Boots", 
			ClothSlotID.Accessory1 => "Acc 1", 
			ClothSlotID.Accessory2 => "Acc 2", 
			_ => id.ToString().Replace("_", "\n"), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
