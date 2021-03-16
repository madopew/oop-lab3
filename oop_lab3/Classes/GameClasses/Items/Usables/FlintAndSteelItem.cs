using System;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.NonstackableItemClasses;

namespace oop_lab3.Classes.GameClasses.Items.Usables
{
    [Serializable]
    public sealed class FlintAndSteelItem : NonstackableItem
    {
        public override ItemType Type => ItemType.FlintAndSteel;
        public bool Lit { get; set; }

        public FlintAndSteelItem()
        {
            this.Lit = false;
        }
    }
}
