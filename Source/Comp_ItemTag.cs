using RimWorld;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // This class holds the state of tags for any taggable (haulable) thing.
    public class Comp_ItemTag : ThingComp
    {
        // References to tags in the global list, presence/absence is how tagging is tracked.
        private HashSet<ItemTag> itemTagsInt = new HashSet<ItemTag>();

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            // Base behaviour for gizmos.
            foreach (var gizmo in base.CompGetGizmosExtra())
            {
                yield return gizmo;
            }
            // Single button for toggling item tags.
            yield return new Gizmo_ItemTag(this);
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            // Save enabled tags as references to global list.
            Scribe_Collections.Look(ref itemTagsInt, nameof(itemTagsInt), LookMode.Reference);
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            // Try and register the item as a tagged item to render when spawned.
            base.PostSpawnSetup(respawningAfterLoad);
            overlayDrawer = parent.Map.GetComponent<OverlayDrawer_ItemTag>();
            UpdateOverlayHandle();
        }

        public override void PostDeSpawn(Map map)
        {

            // Force deregister an item when despawned e.g. furniture minified, to prevent weird duplicate tagged overlays being rendered. 
            // Saves memory and attempts to prevent floating tags in the place of destroyed or discarded entities.
            base.PostDeSpawn(map);
            overlayDrawer.Deregister(parent, this, false);
        }

        private void UpdateOverlayHandle()
        {
            if (!parent.Spawned)
            {
                return;
            }

            // Register/unregister the item to draw a tagged icon over.
            // Make sure to add any additional tags to this section or else the overlay will bug out.
            overlayDrawer.Deregister(parent, this);
            if (parent.Spawned && IsActive())
            {
                overlayDrawer.Register(parent, this);
            }
        }

        public void ToggleDefaultItemTag() => ToggleItemTag(ModSettings_ItemTag.DefaultItemTag);

        public void ToggleItemTag(ItemTag itemTag)
        {
            if (ItemTags.Contains(itemTag))
            {
                ItemTags.Remove(itemTag);
            }
            else
            {
                ItemTags.Add(itemTag);
            }
            UpdateOverlayHandle();
        }

        public bool IsTagged(ItemTag itemTag) => itemTag.enabled && ItemTags.Contains(itemTag);

        public bool IsActive() => ItemTags.Count > 0 && IsAnyItemTagEnabled();

        public bool IsAnyItemTagEnabled()
        {
            foreach (var tag in ItemTags)
            {
                if (tag.enabled) return true;
            }
            return false;
        }

        // Telling the game where to find the textures for cachedMatToDraw
        public Material MatToDraw => ItemTags.First().material; // TODO: draw every tag on the parent ThingWithComps

        public HashSet<ItemTag> ItemTags
        {
            get
            {
                if (parent is MinifiedThing minifiedParent)
                {
                    Comp_ItemTag innerComp = minifiedParent.InnerThing.TryGetComp<Comp_ItemTag>();
                    if (innerComp != null)
                    {
                        return innerComp.ItemTags;
                    }
                }
                return itemTagsInt;
            }
        }

        private OverlayDrawer_ItemTag overlayDrawer;
    }

    public class CompProperties_ItemTag : CompProperties
    {
        public CompProperties_ItemTag()
        {
            compClass = typeof(Comp_ItemTag);
        }
    }
}
