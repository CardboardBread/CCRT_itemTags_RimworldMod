using RimWorld;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // Draggable Button in the Architect Menu under the "Icon Tags" group.
    public class Designator_ItemTag : Designator
    {
        public override int DraggableDimensions => 2;
        public override bool Visible => ModSettings_ItemTag.EnableItemTags && itemTag.enabled;

        public ItemTag itemTag;

        public Designator_ItemTag(ItemTag itemTag)
        {
            this.itemTag = itemTag;
            defaultLabel = itemTag.name;
            defaultDesc = itemTag.FilterDescription();
            icon = TexUtil.IconTex;
            defaultIconColor = itemTag.color;
            soundDragSustain = SoundDefOf.Designate_DragStandard;
            soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            soundSucceeded = SoundDefOf.Designate_Claim;
            useMouseIcon = true;
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 cell)
        {
            if (!cell.InBounds(Map))
            {
                return false;
            }

            foreach (var thing in cell.GetThingList(Map))
            {
                if (CanDesignateThing(thing).Accepted)
                {
                    return true;
                }
            }

            return false;
        }

        public override void DesignateSingleCell(IntVec3 cell)
        {
            foreach (var thing in cell.GetThingList(Map))
            {
                if (CanDesignateThing(thing).Accepted)
                {
                    DesignateThing(thing);
                }
            }
        }

        public override AcceptanceReport CanDesignateThing(Thing thing)
        {
            if (!thing.IsThingFogged() && thing is ThingWithComps thingWithComps)
            {
                return thingWithComps.GetComp<Comp_ItemTag>() != null;
            }

            return false;
        }

        public override void DesignateThing(Thing thing)
        {
            if (CanDesignateThing(thing).Accepted && thing is ThingWithComps thingWithComps)
            {
                thingWithComps.GetComp<Comp_ItemTag>()?.ToggleItemTag(itemTag);
            }
        }
    }

    public class Designator_ItemTag_Default : Designator_ItemTag
    {
        public Designator_ItemTag_Default() : base(ModSettings_ItemTag.DefaultItemTag)
        {
        }
    }
}
