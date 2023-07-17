using MelonLoader;
using SLZ.VRMK;
using BoneLib;
using UnityEngine;

namespace bonelab_template
{
    internal partial class Main : MelonMod
    {
        bool SceneLoaded = false;
        PhysGrounder feet = null;
        bool PreviousFrame;
        bool CurrentFrame;
        float Threshold = 5;
        float Markiplier = 1.3f; //https://shorturl.at/opMO3

        public override void OnEarlyInitializeMelon()
        {
            base.OnEarlyInitializeMelon();
        }


        public override void OnInitializeMelon()
        {
            BoneLib.Hooking.OnLevelInitialized += (_) => { OnSceneAwake(); };
        }

        public void OnSceneAwake()
        { 
            SceneLoaded = true;
            feet = BoneLib.Player.physicsRig.feet.GetComponent<PhysGrounder>();
            PreviousFrame = feet.isGrounded;
        }

        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();
        }

        public override void OnUpdate()
        {
            if (SceneLoaded)
            {

                CurrentFrame = feet.isGrounded;

                if (CurrentFrame && !PreviousFrame)
                {
                    if (BoneLib.Player.physicsRig.wholeBodyVelocity.y < -Threshold)
                    {
                        float damage = Mathf.Abs(BoneLib.Player.physicsRig.wholeBodyVelocity.y + Threshold);
                        damage *= Markiplier; // I might be able to put this on the line above but I don't know the order of operations and I dont care enough to find out because this works
                        Player.rigManager.health.TAKEDAMAGE(damage);
                    }
                }

                PreviousFrame = CurrentFrame;
            }
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            base.OnLateUpdate();
        }
    }
}
