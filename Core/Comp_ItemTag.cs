using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using static System.Collections.Specialized.BitVector32;
using Color = UnityEngine.Color;

namespace ChiefCurtains.ItemTags
{
    // This class holds the state of tags for any taggable (haulable) thing.
    public class Comp_ItemTag : ThingComp
    {
        private HashSet<ItemTag> m_itemTags = new HashSet<ItemTag>();

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            // Base behaviour for gizmos.
            foreach (Gizmo gizmo in base.CompGetGizmosExtra())
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
            Scribe_Collections.Look(ref m_itemTags, nameof(m_itemTags), LookMode.Reference);
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            // Try and register the item as a tagged item to render when spawned.
            base.PostSpawnSetup(respawningAfterLoad);
            cachedTaggedOverlayDrawer = parent.Map.GetComponent<OverlayDrawer_ItemTag>();
            UpdateOverlayHandle();
        }

        public override void PostDeSpawn(Map map)
        {

            // Force deregister an item when despawned e.g. furniture minified, to prevent weird duplicate tagged overlays being rendered. 
            // Saves memory and attempts to prevent floating tags in the place of destroyed or discarded entities.
            base.PostDeSpawn(map);
            cachedTaggedOverlayDrawer.Deregister(parent, this, false);
        }

        private void UpdateOverlayHandle()
        {
            if (!parent.Spawned)
            {
                return;
            }

            // Register/unregister the item to draw a tagged icon over.
            // Make sure to add any additional tags to this section or else the overlay will bug out.
            cachedTaggedOverlayDrawer.Deregister(parent, this);
            if (parent.Spawned && isActive())
            {
                cachedTaggedOverlayDrawer.Register(parent, this);
            }
        }
        
        private MinifiedThing MinifiedParent => parent as MinifiedThing;

        private bool isMinified() => MinifiedParent != null;

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

        public bool isActive() => ItemTags.Count > 0 && isAnyItemTagEnabled();

        public bool isAnyItemTagEnabled()
        {
            foreach (var tag in ItemTags)
            {
                if (tag.enabled) return true;
            }
            return false;
        }

        // Telling the game where to find the textures for cachedMatToDraw
        public Material MatToDraw => ItemTags.FirstOrFallback(ModSettings_ItemTag.DefaultItemTag).material;

        public HashSet<ItemTag> ItemTags
        {
            get
            {
                if (isMinified())
                {
                    // TODO: parent.GetInnerIfMinified();
                    var innerComp = MinifiedParent.InnerThing.TryGetComp<Comp_ItemTag>();
                    if (innerComp != null)
                    {
                        return innerComp.ItemTags;
                    }
                }
                return m_itemTags;
            }
        }

        private OverlayDrawer_ItemTag cachedTaggedOverlayDrawer;
    }

    public class CompProperties_ItemTag : CompProperties
    {
        public CompProperties_ItemTag()
        {
            compClass = typeof(Comp_ItemTag);
        }
    }
}
