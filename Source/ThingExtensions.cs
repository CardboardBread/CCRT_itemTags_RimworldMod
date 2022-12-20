using Verse;

namespace ChiefCurtains.ItemTags
{
    public static class ThingExtensions
    {
        public static bool IsThingFogged(this Thing thing) => thing.Position.Fogged(thing.Map);
    }
}
