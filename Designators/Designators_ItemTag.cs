using ChiefCurtains.ItemTags;
using RimWorld;
using Verse;

namespace ChiefCurtains
{
    // Draggable Button in the Architect Menu under the "Icon Tags" group. 
    internal class Designator_ItemTag : DesignatorBase_ItemTag
    {
        public override bool Visible => ModSettings_ItemTag.EnableItemTags ? visible : !visible;

        public ItemTag itemTag;

        public Designator_ItemTag(ItemTag itemTag)
        {
            this.itemTag = itemTag;
            this.defaultLabel = itemTag.name;
            this.defaultDesc = null;
            this.icon = TexUtil.IconTex;
            this.defaultIconColor = itemTag.color;
            this.soundSucceeded = SoundDefOf.Designate_Claim;
            this.useMouseIcon = true;
        }

        public override void DesignateThing(Thing thing)
        {
            if (CanDesignateThing(thing).Accepted)
            {   
                ThingWithComps thingWithComps = thing as ThingWithComps;
                Comp_ItemTag compItemTags = thingWithComps.GetComp<Comp_ItemTag>();
                compItemTags.ToggleItemTag(itemTag);
            }
        }
    }
}
