using ChiefCurtains.Resources;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    public class ModSettings_ItemTag : ModSettings
    {
        public static List<ItemTag> GlobalItemTags = new List<ItemTag>();
        public static ItemTag DefaultItemTag = new ItemTag("Default", Color.white); // TODO: might overwrite save data
        public static bool EnableItemTags;

        public static ItemTag ItemTagFromSaveKey(string saveKey)
        {
            var itemTagName = saveKey.Substring(Constants.filterSaveKeyPrefix.Length);
            return GlobalItemTags.Find(x => x.name == itemTagName);
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref GlobalItemTags, nameof(GlobalItemTags), LookMode.Deep);
            Scribe_Deep.Look(ref DefaultItemTag, nameof(DefaultItemTag));
        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard list = new Listing_Standard();
            Rect rect = new Rect(0f, 0f, inRect.width, 1200f);
            rect.xMax *= 0.8f;
            list.Begin(rect);
            GUI.EndGroup();
            Widgets.BeginScrollView(inRect, ref ScrollPos, rect, true);
            list.Label("Visibility Toggle");
            list.GapLine();
            list.CheckboxLabeled("Disable Item Tag Overlay", ref EnableItemTags, "Disable/Enable Item Tags");
            list.GapLine();
            foreach (var itemTag in GlobalItemTags)
            {
                list.CheckboxLabeled("Enable Tag: " + itemTag.name, ref itemTag.enabled);
                itemTag.name = list.TextEntryLabeled("Tag: ", itemTag.name, 1);
                list.GapLine();
            }
            Widgets.EndScrollView();
        }

        public static Vector2 ScrollPos = Vector2.zero;
        public static float Gap = 12f;
        public static float LineGap = 3f;
    }
}
