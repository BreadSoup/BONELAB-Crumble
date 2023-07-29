using BoneLib.BoneMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using MelonLoader;

namespace Crumble
{
    internal class Preferences
    {

        public static MelonPreferences_Category MelonPrefCategory { get; private set; }
        public static MelonPreferences_Entry<bool> MelonPrefEnabled { get; private set; }
        public static bool IsEnabled { get; private set; }
        public static MelonPreferences_Entry<float> MelonPrefDamageThreshold { get; private set; }
        public static MelonPreferences_Entry<float> MelonPrefDamageMutiplier { get; private set; }
        public static MelonPreferences_Entry<float> MelonPrefRagdollPercentage { get; private set; }
        public static MelonPreferences_Entry<bool> MelonPrefRagdollFromFallDamage { get; private set; }
        public static bool RagdollFromFallDamage { get; private set; }
        public static MelonPreferences_Entry<bool> MelonPrefRagdollFlingingFix { get; private set; }
        public static bool RagdollFlingingFix { get; private set; }

        public static void MelonPreferencesCreator()
        { 
            MelonPrefCategory = MelonPreferences.CreateCategory("Crumble");
            MelonPrefEnabled = MelonPrefCategory.CreateEntry<bool>("IsEnabled", true, null, null, false, false, null, null);
            IsEnabled = MelonPrefEnabled.Value;
            MelonPrefDamageThreshold = MelonPrefCategory.CreateEntry<float>("Damage Threshold", 7f, null, null, false, false, null, null);
            MelonPrefDamageMutiplier = MelonPrefCategory.CreateEntry<float>("Damage Multiplier", 1.5f, null, null, false, false, null, null);
            MelonPrefRagdollPercentage = MelonPrefCategory.CreateEntry<float>("Ragdoll Percentage", 25f, null, null, false, false, null, null);
            MelonPrefRagdollFromFallDamage = MelonPrefCategory.CreateEntry<bool>("Ragdoll From Fall Damage", true, null, null, false, false, null, null);
            RagdollFromFallDamage = MelonPrefRagdollFromFallDamage.Value;
            MelonPrefRagdollFlingingFix = MelonPrefCategory.CreateEntry<bool>("Ragdoll Flinging Fix", true, null, null, false, false, null, null);
            RagdollFlingingFix = MelonPrefRagdollFlingingFix.Value;

        }

        public static void BonemenuCreator()
        {
            var category = MenuManager.CreateCategory(
                "<color=#ff2424>C</color>" +
                "<color=#ff2926>r</color>" +
                "<color=#ff2e28>u</color>" +
                "<color=#ff332a>m</color>" +
                "<color=#ff372c>b</color>" +
                "<color=#ff3a2e>l</color>" +
                "<color=#ff3e30>e</color>"
                , Color.white);
            category.CreateBoolElement("Mod Toggle", "#FF5E00", IsEnabled, new Action<bool>(OnSetEnabled));
            var DamageThreshold = category.CreateFloatElement("Damage Threshold", "#FC221b", Main.Threshold, 1f, 0f, 100f, (dt) =>
            {
                Main.Threshold = dt;
                MelonPrefDamageThreshold.Value = dt;
                MelonPrefCategory.SaveToFile(false);
            });

            var DamageMultiplier = category.CreateFloatElement("Damage Multiplier", "#FC221b", Main.Markiplier, 0.1f, 0f, 100f, (dm) =>
            {
              Main.Markiplier = dm;
              MelonPrefDamageMutiplier.Value = dm;
              MelonPrefCategory.SaveToFile(false);
            });
            var RagdollHealthPercentage = category.CreateFloatElement("Ragdoll Percentage", Color.yellow, Main.RagdollHealthPercentage, 5f, 0f, 100f, (rp) =>
            {
                Main.RagdollHealthPercentage = rp;
                MelonPrefRagdollPercentage.Value = rp;
                MelonPrefCategory.SaveToFile(false);
            });
            
            category.CreateBoolElement("Ragdoll From Fall Damage", Color.yellow, RagdollFromFallDamage, new Action<bool>(OnRagdollFromFallDamage));
            category.CreateBoolElement("Ragdoll Flinging Fix", Color.yellow, RagdollFlingingFix, new Action<bool>(OnRagdollFlingingFix));


        }

        public static void OnSetEnabled(bool value) //wish I could figure out how to use overflows with bonemenu
        {
            IsEnabled = value;
            MelonPrefEnabled.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }
        public static void OnRagdollFromFallDamage(bool value) 
        {
            RagdollFromFallDamage = value;
            MelonPrefRagdollFromFallDamage.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }
        public static void OnRagdollFlingingFix(bool value) 
        {
            RagdollFlingingFix = value;
            MelonPrefRagdollFlingingFix.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }

    }
}
