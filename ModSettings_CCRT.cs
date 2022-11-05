﻿using RimWorld;
using UnityEngine;
using Verse;

namespace CCRT_itemTags
{
    public class ModSettings_CCRT : ModSettings
    {
        // This bool MUST be true. It is called on severl times to enable the overlay. It is also what it toggled in settings and the overlay button.
        public static bool ccrt_enableItemTags = true;
        public static bool ccrt_enableTagA = true;
        public static bool ccrt_enableTagB = true;
        public static bool ccrt_enableTagC = true;
        public static bool ccrt_enableTagD = true;
        public static bool ccrt_enableTagE = true;
        public static bool ccrt_enableTagF = true;
        public static bool ccrt_enableTagG = true;
        public static bool ccrt_enableTagH = true;
        public static bool ccrt_enableTagI = true;
        public static bool ccrt_enableTagJ = true;
        public static bool ccrt_enableTagK = true;
        public static bool ccrt_enableTagL = true;
        public override void ExposeData()
        {
            //scribing the setting to the save file so it persists after reloading the save.
            Scribe_Values.Look(ref ccrt_enableItemTags, nameof(ccrt_enableItemTags), true);
            base.ExposeData();
        }
        public void DoSettingsWindowContents(Rect canvas)
        {
            //adding my save settings window with a single button. ha
            
            Listing_Standard list = new Listing_Standard();
            list.ColumnWidth = canvas.width;
            list.Begin(canvas);
            list.Label("Custom Tag Names");
            list.GapLine();
            list.CheckboxLabeled("Disable Item Tag Overlay", ref ccrt_enableItemTags, "Disable/Enable Item Tags");
            list.GapLine();
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagA".Translate() + "\" Tag", ref ccrt_enableTagA);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagB".Translate() + "\" Tag", ref ccrt_enableTagB);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagC".Translate() + "\" Tag", ref ccrt_enableTagC);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagD".Translate() + "\" Tag", ref ccrt_enableTagD);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagE".Translate() + "\" Tag", ref ccrt_enableTagE);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagF".Translate() + "\" Tag", ref ccrt_enableTagF);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagG".Translate() + "\" Tag", ref ccrt_enableTagG);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagH".Translate() + "\" Tag", ref ccrt_enableTagH);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagI".Translate() + "\" Tag", ref ccrt_enableTagI);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagJ".Translate() + "\" Tag", ref ccrt_enableTagJ);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagK".Translate() + "\" Tag", ref ccrt_enableTagK);
            list.CheckboxLabeled("Disable \"" + "CCRT_itemTags.TagL".Translate() + "\" Tag", ref ccrt_enableTagL);
            list.GapLine();
            list.SubLabel("As of this version, Tag Names can be modified in \\Steam\\steamapps\\workshop\\content\\294100\\2879583413\\1.4\\Languages\\English\\Keys", 20f);
            list.SubLabel("As of this version, Tag Filters can be modified in \\Steam\\steamapps\\workshop\\content\\294100\\2879583413\\1.4\\Languages\\English\\DefInjected\\SpecialThingFilterDef", 20f);
            list.End();
        }
    }
}