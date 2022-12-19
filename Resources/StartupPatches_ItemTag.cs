using ChiefCurtains.ItemTags;
using System.Collections.Generic;
using Verse;

namespace ChiefCurtains.ItemTags
{
    [StaticConstructorOnStartup]
    public static class StartupPatches_ItemTag
    {
        // This allows tagging of All items, can be tricky so we will revisit. 
        static StartupPatches_ItemTag()
        {
            foreach (var thingDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (thingDef.EverHaulable)
                {
                    thingDef.comps.Add(new CompProperties_ItemTag());
                }
            }
        }
    }
}
