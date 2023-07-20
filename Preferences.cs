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

        public static void MelonPreferencesCreator()
        { 
            MelonPrefCategory = MelonPreferences.CreateCategory("Crumble");
            MelonPrefEnabled = MelonPrefCategory.CreateEntry<bool>("IsEnabled", true, null, null, false, false, null, null);
            IsEnabled = MelonPrefEnabled.Value;
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
            category.CreateBoolElement("Mod Toggle", Color.yellow, IsEnabled, new Action<bool>(OnSetEnabled));
            var DamageThreshold = category.CreateFloatElement("Damage Threshold", Color.red, Main.Threshold, 1f, 0f, 100f, (dt) =>
            {
                Main.Threshold = dt;
            });

            var DamageMultiplier = category.CreateFloatElement("Damage Multiplier", Color.red, Main.Markiplier, 0.1f, 0f, 100f, (dm) =>
            {
              Main.Markiplier = dm;
            });
            var RagdollHealthPercentage = category.CreateFloatElement("Ragdoll Percentage", Color.red, Main.RagdollHealthPercentage, 5f, 0f, 100f, (rp) =>
            {
                Main.RagdollHealthPercentage = rp;
            });
        }

        public static void OnSetEnabled(bool value) // Some extra stuff for the on enabled button
        {
            IsEnabled = value;
            MelonPrefEnabled.Value = value;
            MelonPrefCategory.SaveToFile();
        }
    }
}
