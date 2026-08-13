using BoneLib.BoneMenu;
using MelonLoader;
using UnityEngine;

namespace Crumble
{
    internal static class Preferences
    {
        private static MelonPreferences_Category MelonPrefCategory { get; set; }
        private static MelonPreferences_Entry<bool> MelonPrefEnabled { get; set; }
        internal static bool IsEnabled { get; private set; }
        private static MelonPreferences_Entry<float> MelonPrefDamageThreshold { get; set; }
        private static MelonPreferences_Entry<float> MelonPrefDamageMultiplier { get; set; }
        private static MelonPreferences_Entry<float> MelonPrefRagdollPercentage { get; set; }
        private static MelonPreferences_Entry<bool> MelonPrefRagdollFromFallDamage { get; set; }
        public static bool RagdollFromFallDamage { get; private set; }
        private static MelonPreferences_Entry<bool> MelonPrefRagdollFlingingFix { get; set; }
        public static bool RagdollFlingingFix { get; private set; }

        internal static void MelonPreferencesCreator()
        { 
            MelonPrefCategory = MelonPreferences.CreateCategory("Crumble");
            MelonPrefEnabled = MelonPrefCategory.CreateEntry("IsEnabled", true);
            IsEnabled = MelonPrefEnabled.Value;
            MelonPrefDamageThreshold = MelonPrefCategory.CreateEntry("Damage Threshold", 7f);
            MelonPrefDamageMultiplier = MelonPrefCategory.CreateEntry("Damage Multiplier", 1.5f);
            MelonPrefRagdollPercentage = MelonPrefCategory.CreateEntry("Ragdoll Percentage", 25f);
            MelonPrefRagdollFromFallDamage = MelonPrefCategory.CreateEntry("Ragdoll From Fall Damage", true);
            RagdollFromFallDamage = MelonPrefRagdollFromFallDamage.Value;
            MelonPrefRagdollFlingingFix = MelonPrefCategory.CreateEntry("Ragdoll Flinging Fix", true);
            RagdollFlingingFix = MelonPrefRagdollFlingingFix.Value;

        }

        internal static void BoneMenuCreator()
        {
            var category = Page.Root.CreatePage(
                "<color=#ff2424>C</color>" +
                "<color=#ff2926>r</color>" +
                "<color=#ff2e28>u</color>" +
                "<color=#ff332a>m</color>" +
                "<color=#ff372c>b</color>" +
                "<color=#ff3a2e>l</color>" +
                "<color=#ff3e30>e</color>"
                , Color.white);
            category.CreateBool("Mod Toggle", new Color(1f, 0.3686f, 0f), IsEnabled, OnSetEnabled);
            category.CreateFloat("Damage Threshold", new Color(0.9882f, 0.1333f, 0.1059f), Main.Threshold, 1f, 0f, 100f, dt =>
            {
                Main.Threshold = dt;
                MelonPrefDamageThreshold.Value = dt;
                MelonPrefCategory.SaveToFile(false);
            });

            category.CreateFloat("Damage Multiplier", new Color(0.9882f, 0.1333f, 0.1059f), Main.Markiplier, 0.1f, 0f, 100f, dm =>
            {
                Main.Markiplier = dm;
                MelonPrefDamageMultiplier.Value = dm;
                MelonPrefCategory.SaveToFile(false);
            });
            category.CreateFloat("Ragdoll Percentage", Color.yellow, Main.RagdollHealthPercentage, 5f, 0f, 100f, rp =>
            {
                Main.RagdollHealthPercentage = rp;
                MelonPrefRagdollPercentage.Value = rp;
                MelonPrefCategory.SaveToFile(false);
            });
            
            category.CreateBool("Ragdoll From Fall Damage", Color.yellow, RagdollFromFallDamage, OnRagdollFromFallDamage);
            category.CreateBool("Ragdoll Flinging Fix", Color.yellow, RagdollFlingingFix, OnRagdollFlingingFix);


        }

        private static void OnSetEnabled(bool value) //wish I could figure out how to use overflows with BoneMenu
        {
            IsEnabled = value;
            MelonPrefEnabled.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }

        private static void OnRagdollFromFallDamage(bool value) 
        {
            RagdollFromFallDamage = value;
            MelonPrefRagdollFromFallDamage.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }

        private static void OnRagdollFlingingFix(bool value) 
        {
            RagdollFlingingFix = value;
            MelonPrefRagdollFlingingFix.Value = value;
            MelonPrefCategory.SaveToFile(false);
        }

    }
}
