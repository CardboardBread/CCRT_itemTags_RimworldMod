using ChiefCurtains.ItemTags;
using System;
using System.Runtime.CompilerServices;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // General filter for any item tag, requires the field `itemTag` to be injected before use. See the Harmony patch `Patch_SpecialThingFilterDef_Worker_get` for details.
    public class SpecialThingFilterWorker_ItemTag : SpecialThingFilterWorker
    {
        public ItemTag itemTag;

        public override bool CanEverMatch(ThingDef def)
        {
            return def.HasComp(typeof(Comp_ItemTag));
        }

        public override bool Matches(Thing t)
        {
            var itemTagComp = t.TryGetComp<Comp_ItemTag>();
            if (itemTagComp != null)
            {
                return itemTagComp.ItemTags.Contains(itemTag);
            }
            else
            {
                return false;
            }
        }
    }

    // Making sure there is an ability to filter out ANY tagged items from a stockpile.
    public class SpecialThingFilterWorker_NoTag : SpecialThingFilterWorker
    { 
        public override bool AlwaysMatches(ThingDef def)
        {
            return !def.HasComp(typeof(Comp_ItemTag));
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return !def.EverHaulable;
        }

        public override bool Matches(Thing t)
        {
            var itemTagComp = t.TryGetComp<Comp_ItemTag>();
            if (itemTagComp != null)
            {
                return !itemTagComp.isActive();
            }
            else
            {
                return true;
            }
        }
    }

    // Inversion of SpecialThingFilterWorker_NoTag, for matching any tag instead of a particular one. Recommended to avoid players using anti-patterns.
    public class SpecialThingFilterWorker_AnyTag : SpecialThingFilterWorker
    {
        public override bool AlwaysMatches(ThingDef def)
        {
            return def.HasComp(typeof(Comp_ItemTag));
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.EverHaulable;
        }

        public override bool Matches(Thing t)
        {
            var itemTagComp = t.TryGetComp<Comp_ItemTag>();
            if (itemTagComp != null)
            {
                return itemTagComp.isActive();
            }
            else
            {
                return false;
            }
        }
    }
}
