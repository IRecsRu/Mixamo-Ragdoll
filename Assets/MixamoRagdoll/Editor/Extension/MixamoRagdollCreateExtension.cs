using System;
using System.Linq;
using EditorFolder.MixamoRagdoll.Core;
using EditorFolder.MixamoRagdoll.Data;
using UnityEngine;

namespace EditorFolder.MixamoRagdoll.Extension
{
	public static class MixamoRagdollCreateExtension
	{
		public static BonesCase CreateRagdollCase(this MixamoRagdollBuilder builder)
		{
			BonesCase bonesCase = new BonesCase();

			foreach(RigKey key in builder.Names.RigKeys)
				bonesCase.Add(key.PointType, GetTransform(builder.ModelRoot, key));

			return bonesCase;
		}

		private static Transform GetTransform( MixamoModelRoot ModelRoot, RigKey key)
		{
			foreach(string name in key.KeysName.Where(name => ModelRoot.Bones.ContainsKey(name)))
				return ModelRoot.Bones[name];

			throw new Exception($"There is no such key {key.PointType}, enter it in the MixamoRigNames file");
		}
	}
}