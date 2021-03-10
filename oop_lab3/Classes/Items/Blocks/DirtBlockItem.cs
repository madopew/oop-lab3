using oop_lab3.Classes.ItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.StackableItemClasses;

namespace oop_lab3.Classes.Items.Blocks
{
    public sealed class DirtBlockItem : Stackable64Item
    {
        public override ItemType Type => ItemType.Dirt;
    }
}
