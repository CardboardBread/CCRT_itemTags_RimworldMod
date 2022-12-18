using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    public static class MaterialUtil
    {
        private static Dictionary<Color, Material> MaterialCache = new Dictionary<Color, Material>();
        public static Material GetMaterialWith(Color color)
        {
            if (MaterialCache.ContainsKey(color))
            {
                return MaterialCache[color];
            }
            else
            {
                var newMat = MaterialPool.MatFrom("UI/Designators/CCRT_IconTag", ShaderDatabase.MetaOverlay, color);
                MaterialCache.Add(color, newMat);
                return newMat;
            }
        }
    }
}
