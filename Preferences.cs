using BoneLib.BoneMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace bonelab_template
{
    internal class Preferences
    {

        public static MelonPreferences_Category MelonPrefCategory { get; private set; }
        public static MelonPreferences_Entry<bool> MelonPrefEnabled { get; private set; }

        public static void MelonPreferencesCreator
        {
            MelonPrefCategory = MelonPreferences.CreateCategory("Crumble");
            MelonPrefEnabled = MelonPrefCategory.CreateEntry<bool>("IsEnabled", true, null, null, false, false, null, null);
            IsEnabled = MelonPrefEnabled.Value;
        }

        public TMPro.TMP_Text textMesh;
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
            var colorR = category.CreateFloatElement("Damage Threshold", Color.red, Main.Threshold, 1f, 0f, 100f, (dt) =>
            {
                Main.Threshold = dt;
            });
        }
    }


}
