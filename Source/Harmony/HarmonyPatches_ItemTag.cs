using HarmonyLib;
using RimWorld;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // Setting up the harmony instance.
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            // Tells the startup patch to run anthing in the Solution starting with [HarmonyPatch(typeof(""))]
            Mod_ItemTag.HarmonyInstance.PatchAll();
        }

    }

    // Use the FilterDef's mod extensions to get a ItemTag reference to pass to the FilterWorker.
    [HarmonyPatch(typeof(SpecialThingFilterDef), nameof(SpecialThingFilterDef.Worker), MethodType.Getter)]
    public static class Patch_SpecialThingFilterDef_Worker_get
    {
        public static void Postfix(SpecialThingFilterDef __instance, SpecialThingFilterWorker __result)
        {
            if (__result is SpecialThingFilterWorker_ItemTag itemTagFilter && __instance.HasModExtension<DefModExtension_ItemTag>())
            {
                if (itemTagFilter.itemTag == null)
                {
                    var extension = __instance.GetModExtension<DefModExtension_ItemTag>();
                    itemTagFilter.itemTag = extension.itemTag;
                }
            }
        }
    }

    // Adding game-specific visibility to the 'Global Controls' save data.
    [HarmonyPatch(typeof(PlaySettings), nameof(PlaySettings.ExposeData))]
    public static class Patch_PlaySettings_ExposeData
    {
        public static void Postfix()
        {
            Scribe_Values.Look<bool>(ref ModSettings_ItemTag.EnableItemTags, Constants.GlobalControlsSaveKey, true, false);
        }
    }

    // Adding the toggle icon to the 'Global Controls', controlling game-specific visibility.
    [HarmonyPatch(typeof(PlaySettings), nameof(PlaySettings.DoPlaySettingsGlobalControls))]
    public static class Patch_PlaySettings_DoPlaySettingsGlobalControls
    {
        public static void Postfix(ref WidgetRow row, bool worldView)
        {
            if (!worldView)
            {
                row.ToggleableIcon(ref ModSettings_ItemTag.EnableItemTags, TexUtil.ShowTaggedOverlay, "Toggle Tagged Overlay", null, null);
            }
        }
    }
}
