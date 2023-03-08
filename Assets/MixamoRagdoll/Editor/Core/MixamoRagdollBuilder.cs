using System;
using System.Collections;
using EditorFolder.MixamoRagdoll.Data;
using EditorFolder.MixamoRagdoll.Extension;
using MixamoRagdoll;
using UnityEditor;
using UnityEngine;

namespace EditorFolder.MixamoRagdoll.Core
{
    public class MixamoRagdollBuilder : ScriptableWizard
    {
        public Transform Root;
        public MixamoRigNames Names;
        public float TotalMass = 20;
        public bool AddRagdollController;

        public MixamoModelRoot ModelRoot;
        private Transform _lastRoot;

        [MenuItem("DSOneGames/Tools/Mixamo Ragdoll", false, 2000)]
        static void CreateWizard()
        {
            MixamoRagdollBuilder builder = DisplayWizard<MixamoRagdollBuilder>("Create Mixamo Ragdoll");
            LoadNames(builder);
        }

        private static void LoadNames(MixamoRagdollBuilder builder)
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(MixamoRigNames)}");

            if (guids.Length == 0)
                throw new Exception("Create an instance of MixamoRigNames. Menu item Tools/Mixamo Ragdoll");

            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            builder.Names = AssetDatabase.LoadAssetAtPath<MixamoRigNames>(path);
            builder.OnWizardUpdate();
        }

        void OnWizardUpdate()
        {
            UpdateRoot();
            ShowHelpString();
            CheckError();
        }

        private void UpdateRoot()
        {
            if (Root == null || Root == _lastRoot)
                return;

            ModelRoot = new MixamoModelRoot(Root);
            _lastRoot = Root;
        }

        private void ShowHelpString()
        {
            helpString = "Transfer the rig model downloaded from Mixamo to the stage. "
                         + "After that, transfer to the Root field. It is possible as the Main object and Hips. "
                         + "Model must be in T-pose.\n";

            if (Names == null)
            {
                helpString += "Add a ScriptableObject MixamoRigNames to the Names field, "
                              + "if it is not created, create it via the Tools/MixamoRagdoll context menu";
            }
        }

        private void CheckError()
        {
            string error = "";

            if (Root == null)
                error += "Root is null\n";
            if (Names == null)
                error += "Names is null\n";

            errorString = error;
            isValid = errorString.Length == 0;
        }

        void OnWizardCreate()
        {
            BonesCase bonesCase = this.CreateRagdollCase();
            RagdollBuilder ragdollBuilder = DisplayWizard<RagdollBuilder>("Create Ragdoll");
            ragdollBuilder.FillData(bonesCase.Bones, TotalMass);
            ragdollBuilder.WizardCreate();
            ragdollBuilder.Close();
            TryAddRagdollController(bonesCase);
        }

        private void TryAddRagdollController(BonesCase bonesCase)
        {
            if (AddRagdollController)
            {
                GameObject pelvis = bonesCase.Bones[RigPoints.Pelvis].gameObject;
                RagdollController ragdollController = pelvis.AddComponent<RagdollController>();
                ragdollController ??= pelvis.GetComponent<RagdollController>();
                Rigidbody[] rigidbodies = pelvis.GetComponentsInChildren<Rigidbody>();
                Rigidbody main = bonesCase.Bones[RigPoints.MiddleSpine].GetComponent<Rigidbody>();
                ragdollController.SetRigidbodies(rigidbodies, main);
                ragdollController.EnableKinematic();
            }
        }
    }
}