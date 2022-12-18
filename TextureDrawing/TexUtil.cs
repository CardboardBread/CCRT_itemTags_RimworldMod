using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // Main reference for all textures. One texture with multiple colors sourced from ColorReference.
    [StaticConstructorOnStartup]
    public static class TexUtil
    {
        public static readonly Texture2D IconTagsButtonUI = ContentFinder<Texture2D>.Get("UI/Buttons/CCRT_IconTagsButtonUI");
        public static readonly Texture2D IconTex = ContentFinder<Texture2D>.Get("UI/Designators/CCRT_IconTag");
        public static readonly Texture2D IconReset = ContentFinder<Texture2D>.Get("UI/Designators/CCRT_IconResetTag");
        public static readonly Texture2D ShowTaggedOverlay = ContentFinder<Texture2D>.Get("UI/Buttons/CCRT_IconShowTaggedOverlay");
    }
}
