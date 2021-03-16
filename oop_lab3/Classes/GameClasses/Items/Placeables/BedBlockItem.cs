using System;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.NonstackableItemClasses;
using oop_lab3.Classes.GameClasses.Other;

namespace oop_lab3.Classes.GameClasses.Items.Placeables
{
    [Serializable]
    public sealed class BedBlockItem : NonstackableItem
    {
        public override ItemType Type => ItemType.Bed;
        public Color Color { get; set; }

        public BedBlockItem(Color color)
        {
            this.Color = color;
        }

        public BedBlockItem()
        {
            this.Color = new Color(255, 0, 0);
        }
    }
}
