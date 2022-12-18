using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.Sound;
using Color = UnityEngine.Color;

namespace ChiefCurtains.ItemTags
{
    public class Gizmo_ItemTag : Command_Toggle
    {
        public Comp_ItemTag parent;

        public Gizmo_ItemTag(Comp_ItemTag parent)
        {
            this.parent = parent;
            defaultLabel = "Tag This";
            defaultDesc = "Left Click to toggle the default tag. Right Click to choose a specific tag.";
            icon = TexUtil.IconTagsButtonUI;
            defaultIconColor = Color.white;
            toggleAction = new Action(() => { }); // no-op to prevent Command_Toggle calling null
            isActive = parent.isActive;
        }

        public override bool InheritInteractionsFrom(Gizmo other)
        {
            return base.InheritInteractionsFrom(other);
        }

        public override void ProcessInput(Event ev)
        {
            base.ProcessInput(ev);

            if (ev.button == 0)
            {
                parent.ToggleDefaultItemTag();
            }

            if (ev.button == 1)
            {
                var floatMenu = new FloatMenu(GetMenuOptions());
                Find.WindowStack.Add(floatMenu);
            }
        }

        public List<FloatMenuOption> GetMenuOptions()
        {
            var list = new List<FloatMenuOption>();
            foreach (var globalItemTag in ModSettings_ItemTag.GlobalItemTags)
            {
                var text = parent.ItemTags.Contains(globalItemTag) ? "Enable " + globalItemTag.name : "Disable " + globalItemTag.name;
                Action action = () => parent.ToggleItemTag(globalItemTag);
                list.Add(new FloatMenuOption(text, action));
            }
            return list;
        }
    }
}