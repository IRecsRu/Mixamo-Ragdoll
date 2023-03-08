using System.Collections.Generic;
using UnityEngine;

namespace EditorFolder.MixamoRagdoll.Data
{
	public class BonesCase
	{
		public Dictionary<RigPoints, Transform> Bones = new Dictionary<RigPoints, Transform>();

		public void Add(RigPoints type, Transform bone)
		{
			if(!Bones.ContainsKey(type))
				Bones.Add(type, bone);
			else
				Bones[type] = bone;
		}
	}
}