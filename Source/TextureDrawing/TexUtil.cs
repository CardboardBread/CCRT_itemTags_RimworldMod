using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // Main reference for all textures. One texture with multiple colors sourced from ColorReference.
    public static class TexUtil
    {
        public static Texture2D IconTagsButtonUI => GetTexture("UI/Buttons/CCRT_IconTagsButtonUI");
        public static Texture2D IconTex => GetTexture("UI/Designators/CCRT_IconTag");
        public static Texture2D IconReset => GetTexture("UI/Designators/CCRT_IconResetTag");
        public static Texture2D ShowTaggedOverlay => GetTexture("UI/Buttons/CCRT_IconShowTaggedOverlay");

        public static Dictionary<string, Texture2D> TextureCache = new Dictionary<string, Texture2D>();

        public static Texture2D GetTexture(string name, bool reportFailure = true)
        {
            if (TextureCache.ContainsKey(name))
            {
                return TextureCache[name];
            }
            else
            {
                var newTex = ContentFinder<Texture2D>.Get(name, reportFailure);
                TextureCache.Add(name, newTex);
                return newTex;
            }
        }
    }
}
