using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.Other;
using oop_lab3.Classes.StackableItemClasses;

namespace oop_lab3.Classes.Items.Placeables
{
    public sealed class BedBlockItem : Stackable16Item
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
