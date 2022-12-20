using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
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
            isActive = parent.IsActive;
        }

        public override bool InheritInteractionsFrom(Gizmo other)
        {
            return base.InheritInteractionsFrom(other);
        }

        public override void ProcessInput(Event ev)
        {
            base.ProcessInput(ev);

            // Left Click
            if (ev.button == 0)
            {
                parent.ToggleDefaultItemTag();
            }

            // Right Click
            if (ev.button == 1)
            {
                var floatMenu = new FloatMenu(GetMenuOptions());
                Find.WindowStack.Add(floatMenu);
            }
        }

        // Adapted from Locks: https://github.com/Aviuz/Locks
        public List<FloatMenuOption> GetMenuOptions()
        {
            var list = new List<FloatMenuOption>();
            foreach (var globalItemTag in ModSettings_ItemTag.GlobalItemTags)
            {
                var text = (parent.ItemTags.Contains(globalItemTag) ? "Enable " : "Disable ") + globalItemTag.name;
                void action() => parent.ToggleItemTag(globalItemTag); // TODO: possibly cache List<FloatMenuOption> and model actions to lessen cost of GetMenuOptions()
                list.Add(new FloatMenuOption(text, action));
            }
            return list;
        }
    }
}
