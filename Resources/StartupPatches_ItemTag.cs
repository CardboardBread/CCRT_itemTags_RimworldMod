using ChiefCurtains.ItemTags;
using System.Collections.Generic;
using Verse;

namespace ChiefCurtains
{
    [StaticConstructorOnStartup]
    public static class StartupPatches_ItemTag
    {
        // This allows tagging of All items, can be tricky so we will revisit. 
        static StartupPatches_ItemTag()
        {
            foreach (var t in DefDatabase<ThingDef>.AllDefs)
            {
                if (t.EverHaulable)
                {
                    t.comps.Add(new CompProperties_ItemTag());
                }
            }
        }
    }
}
