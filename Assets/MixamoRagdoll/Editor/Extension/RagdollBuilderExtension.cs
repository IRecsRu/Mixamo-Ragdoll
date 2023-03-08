using System.Collections.Generic;
using EditorFolder.MixamoRagdoll.Data;
using UnityEngine;

namespace EditorFolder.MixamoRagdoll.Extension
{
	public static class RagdollBuilderExtension
	{
		public static void FillData(this Core.RagdollBuilder builder, Dictionary<RigPoints, Transform> bones, float totalMass)
		{
			builder.pelvis = bones[RigPoints.Pelvis];

			builder.leftHips =  bones[RigPoints.LeftHips];
			builder.leftKnee =  bones[RigPoints.LeftKnee];
			builder.leftFoot =  bones[RigPoints.LeftFoot];

			builder.rightHips = bones[RigPoints.RightHips];
			builder.rightKnee =  bones[RigPoints.RightKnee];
			builder.rightFoot =  bones[RigPoints.RightFoot];

			builder.leftArm =  bones[RigPoints.LeftArm];
			builder.leftElbow = bones[RigPoints.LeftElbow];

			builder.rightArm =  bones[RigPoints.RightArm];
			builder.rightElbow =  bones[RigPoints.RightElbow];

			builder.middleSpine =  bones[RigPoints.MiddleSpine];
			builder.head =  bones[RigPoints.Head];

			builder.totalMass = totalMass;
		}
	}
}