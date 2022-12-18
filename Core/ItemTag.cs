using ChiefCurtains.Resources;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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

        // User Configurable properties
        public string name;
        public Color color;
        public Material material;
        public bool enabled;

        public SpecialThingFilterDef selfFilter;

        public ItemTag(string name, Color color, Material material = null, bool enabled = true)
        {
            this.name = name == null ? GetNewName() : name;
            this.color = color;
            this.material = material == null ? MaterialUtil.GetMaterialWith(color) : material;
            this.enabled = enabled;

            this.selfFilter = new SpecialThingFilterDef()
            {
                defName = name + nameof(SpecialThingFilterDef),
                label = "Allow Tag " + name,
                description = "Allow things that are Tagged " + name,
                parentCategory = ThingCategoryDef.Named("Root"),
                allowedByDefault = true,
                saveKey = Constants.filterSaveKeyPrefix + name,
                workerClass = typeof(SpecialThingFilterWorker_ItemTag),
            };
            DefDatabase<SpecialThingFilterDef>.Add(selfFilter);
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref name, nameof(name));
            Scribe_Values.Look(ref color, nameof(color));
            Scribe_Values.Look(ref material, nameof(material));
            Scribe_Values.Look(ref enabled, nameof(enabled));
            Scribe_Values.Look(ref selfFilter, nameof(selfFilter));
        }

        public string GetUniqueLoadID() => name;
    }
}
