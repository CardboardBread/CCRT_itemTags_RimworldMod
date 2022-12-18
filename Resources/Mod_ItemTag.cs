﻿using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    public class Mod_ItemTag : Mod
    {
        // Telling the game that this is a Mod and here is where to locate settings and harmony patches.
        public static ModSettings_ItemTag Settings;
        public static Harmony harmonyInstance;

        public override string SettingsCategory()
        {
            return "Class Specific Item Tags";
        }

        public Mod_ItemTag(ModContentPack content) : base(content)
        {
            // Building Settings in Mod Settings Menu.
            Settings = GetSettings<ModSettings_ItemTag>();
            // Starting Harmony Instance.
            harmonyInstance = new Harmony(this.GetType().Namespace);
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Settings.DoWindowContents(inRect);
        }
    }
}
