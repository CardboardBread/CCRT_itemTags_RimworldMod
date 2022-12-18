using ChiefCurtains.ItemTags;
using RimWorld;
using Verse;

namespace ChiefCurtains
{
    public abstract class DesignatorBase_ItemTag : Designator
    {
        public override int DraggableDimensions => 2;

        protected DesignatorBase_ItemTag()
        {
            this.useMouseIcon = true;
            this.soundDragSustain = SoundDefOf.Designate_DragStandard;
            this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            this.soundSucceeded = SoundDefOf.Designate_Claim;
            this.useMouseIcon = true;
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 cell)
        {
            if (!cell.InBounds(Map))
            {
                return false;
            }
            foreach (Thing thing in cell.GetThingList(Map))
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
            foreach (Thing thing in cell.GetThingList(Map))
            {
                if (CanDesignateThing(thing).Accepted)
                {
                    DesignateThing(thing);
                }
            }
        }

        public override AcceptanceReport CanDesignateThing(Thing thing)
        {
            if (thing.Position.Fogged(thing.Map))
            {
                return false; // bool implicit operator
            }
            else
            {
                Comp_ItemTag compItemTags = (thing is ThingWithComps thingWithComps) ? thingWithComps.GetComp<Comp_ItemTag>() : null;
                return compItemTags != null; // bool implicit operator
            }
        }

        public bool visible = true;
    }
}
