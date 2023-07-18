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
        public TMPro.TMP_Text textMesh;
        public static void BonemenuCreator()
        {
            var category = MenuManager.CreateCategory(
                "<color=#FF0000>c</color>" +
                "<color=#FF2900>r</color>" +
                "<color=#FF5200>u</color>" +
                "<color=#FF7B00>m</color>" +
                "<color=#FFA400>b</color>" +
                "<color=#FFCD00>l</color>" +
                "<color=#FFFA00>e</color>"
                , Color.white);

        }
    }


}
