using BoneLib;
using MelonLoader;
using SLZ.VRMK;
using UnityEngine;

namespace Crumble
{
    internal partial class Main : MelonMod
    {
        private PhysGrounder _feet;
        private bool _sceneLoaded;
        private bool _hasRagdolledFromCrumble;
        private bool _previousRagdollState;
        private bool _currentRagdollState;
        private bool _previousFrame;
        private bool _currentFrame;
        public static float Threshold = 7;
        public static float Markiplier = 1.5f; //https://shorturl.at/opMO3
        public static float RagdollHealthPercentage = 25;
        private static readonly Vector3 Add = new Vector3(0f, 0.5f, 0f);




        public override void OnInitializeMelon()
        {
            Hooking.OnLevelInitialized += _ => { OnSceneAwake(); };
            Preferences.MelonPreferencesCreator();
            Preferences.BoneMenuCreator();
        }

        private void OnSceneAwake()
        { 
            _sceneLoaded = true;
            _feet = Player.physicsRig.feet.GetComponent<PhysGrounder>();
            _previousRagdollState = Player.physicsRig._legsKinematic;
            _previousFrame = _feet.isGrounded;
        }

        public override void OnUpdate()
        {
            if (Preferences.IsEnabled)
            {
                if (_sceneLoaded)
                {
                    float currentHealthPercentage = (Player.rigManager.health.curr_Health / Player.rigManager.health.max_Health) * 100;
                    // I dont think anything is getting past this check
                    if (currentHealthPercentage >= RagdollHealthPercentage && !Player.physicsRig._legsKinematic && Player.rigManager.health.curr_Health > 0 && _hasRagdolledFromCrumble)
                    {
                        Player.physicsRig.UnRagdollRig();
                    }

                    if (_hasRagdolledFromCrumble && Player.physicsRig._legsKinematic) //Just so I dont mess with other mods that ragdoll might not be needed but better to be safe
                    {
                        _hasRagdolledFromCrumble = false;
                    }

                    _currentRagdollState = Player.physicsRig._legsKinematic;
                    if (!_previousRagdollState && _currentRagdollState && Preferences.RagdollFlingingFix)
                    {
                            Vector3 teleport = Player.physicsRig.feet.transform.position + Add;
                            Player.rigManager.Teleport(teleport);
                    }

                    _previousRagdollState = _currentRagdollState;
                    
                    _currentFrame = _feet.isGrounded;

                    if (_currentFrame && !_previousFrame)
                    {
                        if (Player.physicsRig.wholeBodyVelocity.y < -Threshold)
                        {
                            float damage = Mathf.Abs(Player.physicsRig.wholeBodyVelocity.y + Threshold);
                            damage *= Markiplier; // I might be able to put this on the line above but I don't know the order of operations and I dont care enough to find out because this works
                            Player.rigManager.health.TAKEDAMAGE(damage);
                            float healthPercentage = (Player.rigManager.health.curr_Health / Player.rigManager.health.max_Health) * 100;
                            if (healthPercentage <= RagdollHealthPercentage && Preferences.RagdollFromFallDamage)
                            {
                              Player.physicsRig.RagdollRig(); 
                              _hasRagdolledFromCrumble = true;
                            }
                        }
                    }

                    _previousFrame = _currentFrame;
                }
            }
        }
    }
}
