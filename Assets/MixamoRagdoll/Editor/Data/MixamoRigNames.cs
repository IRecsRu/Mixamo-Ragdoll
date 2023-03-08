using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFolder.MixamoRagdoll.Data
{
	[CreateAssetMenu(menuName = "DSOneGames/Tools/MixamoRagdoll", fileName = "MixamoRigNames", order = 0)]
	public class MixamoRigNames : ScriptableObject
	{
		public string Name;
		public List<RigKey> RigKeys;

		private void OnValidate()
		{
			foreach(RigKey key in RigKeys)
				key.SetName();

			if(RigKeys.Count < 13)
			{
				RigKeys = new List<RigKey>();

				for( int i = 1; i < 14; i++ )
				{
					RigKeys.Add(new RigKey()
					{
						PointType = (RigPoints)i,
						Name = ((RigPoints)i).ToString(),
					});
				}
			}
		}
	}

	[Serializable]
	public class RigKey
	{
		[HideInInspector]public string Name;
		[HideInInspector]	public RigPoints PointType;
		public List<string> KeysName;

		public void SetName()
		{
			if(!Name.Equals(PointType.ToString()))
				Name = PointType.ToString();
		}
	}

}