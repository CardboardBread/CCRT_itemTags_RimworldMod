using Verse;

namespace ChiefCurtains.ItemTags
{
    [StaticConstructorOnStartup]
    public static class StartupPatches_ItemTag
    {
        static StartupPatches_ItemTag()
        {
            // This allows tagging of all haulable items, can be tricky so we will revisit.
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
