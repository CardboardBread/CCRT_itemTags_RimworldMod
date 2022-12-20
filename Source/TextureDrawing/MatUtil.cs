using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // Material cache and statically accessible materials.
    public static class MatUtil
    {
        public static Dictionary<Color, Material> MaterialCache = new Dictionary<Color, Material>();
        public static Material GetMaterial(Color color)
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
