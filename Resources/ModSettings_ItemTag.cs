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
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Item Tag Overlay", ref ccrt_enableItemTags, "Disable/Enable Item Tags");
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag A: \"" + newNameA + "\" Tag", ref ccrt_enableTagA);
            tmpTagNameA = list.TextEntryLabeled("Tag A:         \"" + newNameA + "\" : ", tmpTagNameA, 1);
            if (list.ButtonText("Change Tag A Name", null, 1f))
            {
                newNameA = tmpTagNameA;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag B: \"" + newNameB + "\" Tag", ref ccrt_enableTagB);
            tmpTagNameB = list.TextEntryLabeled("Tag B:         \"" + newNameB + "\" : ", tmpTagNameB, 1);
            if (list.ButtonText("Change Tag B Name", null, 1f))
            {
                newNameB = tmpTagNameB;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag C: \"" + newNameC + "\" Tag", ref ccrt_enableTagC);
            tmpTagNameC = list.TextEntryLabeled("Tag C:         \"" + newNameC + "\" : ", tmpTagNameC, 1);
            if (list.ButtonText("Change Tag C Name", null, 1f))
            {
                newNameC = tmpTagNameC;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag D: \"" + newNameD + "\" Tag", ref ccrt_enableTagD);
            tmpTagNameD = list.TextEntryLabeled("Tag D:         \"" + newNameD + "\" : ", tmpTagNameD, 1);
            if (list.ButtonText("Change Tag D Name", null, 1f))
            {
                newNameD = tmpTagNameD;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag E: \"" + newNameE + "\" Tag", ref ccrt_enableTagE);
            tmpTagNameE = list.TextEntryLabeled("Tag E:         \"" + newNameE + "\" : ", tmpTagNameE, 1);
            if (list.ButtonText("Change Tag E Name", null, 1f))
            {
                newNameE = tmpTagNameE;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag F: \"" + newNameF + "\" Tag", ref ccrt_enableTagF);
            tmpTagNameF = list.TextEntryLabeled("Tag F:         \"" + newNameF + "\" : ", tmpTagNameF, 1);
            if (list.ButtonText("Change Tag F Name", null, 1f))
            {
                newNameF = tmpTagNameF;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag G: \"" + newNameG + "\" Tag", ref ccrt_enableTagG);
            tmpTagNameG = list.TextEntryLabeled("Tag G:         \"" + newNameG + "\" : ", tmpTagNameG, 1);
            if (list.ButtonText("Change Tag G Name", null, 1f))
            {
                newNameG = tmpTagNameG;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag H: \"" + newNameH + "\" Tag", ref ccrt_enableTagH);
            tmpTagNameH = list.TextEntryLabeled("Tag H:         \"" + newNameH + "\" : ", tmpTagNameH, 1);
            if (list.ButtonText("Change Tag H Name", null, 1f))
            {
                newNameH = tmpTagNameH;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag I: \"" + newNameI + "\" Tag", ref ccrt_enableTagI);
            tmpTagNameI = list.TextEntryLabeled("Tag I:         \"" + newNameI + "\" : ", tmpTagNameI, 1);
            if (list.ButtonText("Change Tag I Name", null, 1f))
            {
                newNameI = tmpTagNameI;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag J: \"" + newNameJ + "\" Tag", ref ccrt_enableTagJ);
            tmpTagNameJ = list.TextEntryLabeled("Tag J:         \"" + newNameJ + "\" : ", tmpTagNameJ, 1);
            if (list.ButtonText("Change Tag J Name", null, 1f))
            {
                newNameJ = tmpTagNameJ;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag K: \"" + newNameK + "\" Tag", ref ccrt_enableTagK);
            tmpTagNameK = list.TextEntryLabeled("Tag K:         \"" + newNameK + "\" : ", tmpTagNameK, 1);
            if (list.ButtonText("Change Tag K Name", null, 1f))
            {
                newNameK = tmpTagNameK;
            }
            list.GapLine(12f);
            list.CheckboxLabeled("Disable Tag L: \"" + newNameL + "\" Tag", ref ccrt_enableTagL);
            tmpTagNameL = list.TextEntryLabeled("Tag L:         \"" + newNameL + "\" : ", tmpTagNameL, 1);
            if (list.ButtonText("Change Tag L Name", null, 1f))
            {
                newNameL = tmpTagNameL;
            }
            Widgets.EndScrollView();
        }

        public static Vector2 ScrollPos = Vector2.zero;
        public static float Gap = 12f;
        public static float LineGap = 3f;
    }
}