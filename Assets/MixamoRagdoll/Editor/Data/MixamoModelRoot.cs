using System.Collections.Generic;
using UnityEngine;

namespace EditorFolder.MixamoRagdoll.Data
{
	public class MixamoModelRoot
	{
		public Dictionary<string, Transform> Bones = new Dictionary<string, Transform>();

		public MixamoModelRoot(Transform transform) =>
			Get(transform);

		private void Get(Transform transform)
		{
			foreach(Transform rTransform in transform)
			{
				Bones.Add(rTransform.name, rTransform);
				Get(rTransform);
			}
		}
	}
}