using ChiefCurtains.ItemTags;
using RimWorld.Planet;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ChiefCurtains
{
    // This makes the tagged icons appear in the overworld. Pretty much shamelessly ripped from XeoNovaDan.
    [StaticConstructorOnStartup]
    public class OverlayDrawer_ItemTag : MapComponent
    {
        public OverlayDrawer_ItemTag(Map map) : base(map) // Copied from XeoNovaDan.
        {
            drawBatch = new DrawBatch();
            overlayDrawRegister = new List<Pair<Thing, Comp_ItemTag>>();
            overlaysToDraw = new List<Pair<Thing, Comp_ItemTag>>();
        }

        public override void MapComponentUpdate() // Copied from XeoNovaDan.
        {
            base.MapComponentUpdate();
            if (!WorldRendererUtility.WorldRenderedNow && Find.CurrentMap == map)
            {
                DrawAlltaggedOverlays();
            }
        }

        public void DrawtaggedOverlay(Pair<Thing, Comp_ItemTag> overlay) // Copied from XeoNovaDan.
        {
            if (!overlaysToDraw.Contains(overlay))
            {
                overlaysToDraw.Add(overlay);
            }
        }

        public void DrawAlltaggedOverlays() // Copied from XeoNovaDan.
        {
            if (ModSettings_ItemTag.EnableItemTags)
            {
                // Almost 1:1 structure with the vanilla Overlay Drawer code.
                try
                {
                    foreach (var overlay in overlayDrawRegister)
                    {
                        if (!overlay.First.Fogged())
                        {
                            DrawtaggedOverlay(overlay);
                        }
                    }
                    foreach (var overlay in overlaysToDraw)
                    {
                        RendertaggedOverlay(overlay);
                    }
                }
                finally
                {
                    overlaysToDraw.Clear();
                }
                drawBatch.Flush();
            }
        }

        private void RendertaggedOverlay(Pair<Thing, Comp_ItemTag> overlay) // Copied from XeoNovaDan.
        {
            // Render tagged icon overlay over the bottom right hand corner of the item on map.
            var thing = overlay.First;
            Vector3 drawPos = thing.DrawPos;
            var rotSize = thing.RotatedSize;
            drawPos.z -= 0.3f * rotSize.z;
            drawPos.x += 0.3f * rotSize.x;
            drawPos.y = BaseAlt + 0.16216215f;
            drawBatch.DrawMesh(MeshPool.plane05, Matrix4x4.TRS(drawPos, Quaternion.identity, Vector3.one), overlay.Second.MatToDraw, 0, true);
        }

        public void Register(Thing thing, Comp_ItemTag itemTagComp, bool checkRegister = true) // Copied from XeoNovaDan.
        {
            var overlay = new Pair<Thing, Comp_ItemTag>(thing, itemTagComp);
            if (!checkRegister || !overlayDrawRegister.Contains(overlay))
            {
                overlayDrawRegister.Add(overlay);
            }
        }

        public void Deregister(Thing thing, Comp_ItemTag itemTagComp, bool checkRegister = true) // Copied from XeoNovaDan.
        {
            var overlay = new Pair<Thing, Comp_ItemTag>(thing, itemTagComp);
            if (!checkRegister || overlayDrawRegister.Contains(overlay))
            {
                overlayDrawRegister.Remove(overlay);
            }
        }

        private static readonly float BaseAlt = AltitudeLayer.MetaOverlays.AltitudeFor();

        public DrawBatch drawBatch;
        public List<Pair<Thing, Comp_ItemTag>> overlaysToDraw;
        public List<Pair<Thing, Comp_ItemTag>> overlayDrawRegister;
    }
}
