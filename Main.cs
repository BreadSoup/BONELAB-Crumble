using MelonLoader;
using SLZ.VRMK;
using BoneLib;
using UnityEngine;
using SLZ.Rig;

namespace Crumble
{
    internal partial class Main : MelonMod
    {
        PhysGrounder feet = null;
        bool SceneLoaded = false;
        bool HasRagdolledFromCrumble = false;
        bool PreviousFrame;
        bool CurrentFrame;
        public static float Threshold = 7;
        public static float Markiplier = 1.5f; //https://shorturl.at/opMO3
        public static float RagdollHealthPercentage = 25;

        float ThresholdDefault = 7;
        float MarkiplierDefault = 1.5f;



        public override void OnInitializeMelon()
        {
            BoneLib.Hooking.OnLevelInitialized += (_) => { OnSceneAwake(); };
            Crumble.Preferences.MelonPreferencesCreator();
            Crumble.Preferences.BonemenuCreator();
        }

        public void OnSceneAwake()
        { 
            SceneLoaded = true;
            feet = BoneLib.Player.physicsRig.feet.GetComponent<PhysGrounder>();
            PreviousFrame = feet.isGrounded;
        }

        public override void OnUpdate()
        {
            if (Preferences.IsEnabled)
            {
                if (SceneLoaded)
                {
                    float CurrentHealthPercentage = (Player.rigManager.health.curr_Health / Player.rigManager.health.max_Health) * 100;
                    // I dont think anything is getting past this check
                    if (CurrentHealthPercentage >= RagdollHealthPercentage && !Player.physicsRig._legsKinematic && Player.rigManager.health.curr_Health > 0 && HasRagdolledFromCrumble)
                    {
                        Player.physicsRig.UnRagdollRig();
                    }

                    if (HasRagdolledFromCrumble) //this will be a check to stop damage before landing from ragdoll
                    {

                    }
                    
                    CurrentFrame = feet.isGrounded;

                    if (CurrentFrame && !PreviousFrame)
                    {
                        if (BoneLib.Player.physicsRig.wholeBodyVelocity.y < -Threshold)
                        {
                            float damage = Mathf.Abs(BoneLib.Player.physicsRig.wholeBodyVelocity.y + Threshold);
                            damage *= Markiplier; // I might be able to put this on the line above but I don't know the order of operations and I dont care enough to find out because this works
                            Player.rigManager.health.TAKEDAMAGE(damage);
                            float HealthPercentage = (Player.rigManager.health.curr_Health / Player.rigManager.health.max_Health) * 100;
                            if (HealthPercentage <= RagdollHealthPercentage)
                            {
                              BoneLib.Player.physicsRig.RagdollRig(); 
                              HasRagdolledFromCrumble = true;
                            }
                        }
                    }

                    PreviousFrame = CurrentFrame;
                }
            }
        }
    }
}
