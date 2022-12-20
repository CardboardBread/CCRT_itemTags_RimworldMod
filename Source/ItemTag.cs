using Humanizer;
using RimWorld;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Verse;

namespace ChiefCurtains.ItemTags
{
    public class ItemTag : IExposable, ILoadReferenceable
    {
        // Finds a number that no existing global item tag is named with, as a default name for new global item tags.
        public static string GetNewName(int step = 1)
        {
            var currentWords = (ModSettings_ItemTag.GlobalItemTags.Count + step).ToWords();
            foreach (var globalTag in ModSettings_ItemTag.GlobalItemTags)
            {
                if (globalTag.name == currentWords)
                {
                    return GetNewName(step + 1);
                }
            }
            return currentWords;
        }

        // Finds a color that no existing global item tag is using.
        public static Color GetNewColor(int step = 0)
        {
            var currentColor = ColorUtil.ColorList[step];
            foreach (var globalTag in ModSettings_ItemTag.GlobalItemTags)
            {
                if (globalTag.color == currentColor)
                {
                    return GetNewColor(step + 1);
                }
            }
            return currentColor;
        }

        // Finds an unused positive integer.
        public static int GetNewID(int step = 0)
        {
            var currentID = ModSettings_ItemTag.GlobalItemTags.Count + step;
            foreach (var globalTag in ModSettings_ItemTag.GlobalItemTags)
            {
                if (globalTag.id == currentID)
                {
                    return GetNewID(step + 1);
                }
            }
            return currentID;
        }

        public string FilterDefName() => $"{Constants.FilterDefNamePrefix}{id}";
        public string FilterLabel() => $"Allow Tag: {name}";
        public string FilterDescription() => $"Allow things that are tagged with: {name}.";
        public string FilterSaveKey() => FilterDefName();
        public string DesignatorDescription() => $"Mark things as tagged by: {name}.";

        public readonly int id;

        // User Configurable properties
        public string name;
        public Color color;
        public Material material;
        public bool enabled;

        public SpecialThingFilterDef filter;
        public DefModExtension_ItemTag extension;
        public Designator_ItemTag designator;

        public ItemTag(string name, Color? color = null, Material material = null, bool enabled = true)
        {
            filter = new SpecialThingFilterDef()
            {
                parentCategory = ThingCategoryDef.Named("Root"),
                allowedByDefault = true,
                workerClass = typeof(SpecialThingFilterWorker_ItemTag)
            };
            extension = new DefModExtension_ItemTag(this);
            filter.modExtensions.Add(extension);

            designator = new Designator_ItemTag(this);

            this.name = name ?? GetNewName();
            this.color = color ?? GetNewColor();
            this.material = material ?? MatUtil.GetMaterial(this.color);
            this.enabled = enabled;
            id = GetNewID();

            DefDatabase<SpecialThingFilterDef>.Add(filter);
            DefDatabase<DesignationCategoryDef>.GetNamed(Constants.DesignatorCategoryName)?.AllResolvedDesignators.Add(designator);
        }

        public void UpdateDependents()
        {
            filter.defName = FilterDefName();
            filter.label = FilterLabel();
            filter.description = FilterDescription();
            filter.saveKey = FilterSaveKey();
            designator.defaultLabel = name;
            designator.defaultDesc = DesignatorDescription();
            designator.defaultIconColor = color;
        }

        void IExposable.ExposeData()
        {
            Scribe_Values.Look(ref name, nameof(Name));
            Scribe_Values.Look(ref color, nameof(Color));
            Scribe_Values.Look(ref material, nameof(material));
            Scribe_Values.Look(ref enabled, nameof(enabled));
            Scribe_Defs.Look(ref filter, nameof(filter));
        }

        string ILoadReferenceable.GetUniqueLoadID() => $"{Constants.ModelSaveKeyPrefix}{id}";
    }

    // Allows passing a direct reference to an item tag from FilterDef to FilterWorker
    public class DefModExtension_ItemTag : DefModExtension
    {
        public ItemTag itemTag;

        public DefModExtension_ItemTag(ItemTag itemTag)
        {
            this.itemTag = itemTag;
        }
    }
}
