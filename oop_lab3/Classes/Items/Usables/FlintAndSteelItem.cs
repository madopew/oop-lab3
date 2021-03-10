using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.StackableItemClasses;

namespace oop_lab3.Classes.Items.Usables
{
    public sealed class FlintAndSteelItem : Stackable16Item
    {
        public override ItemType Type => ItemType.FlintAndSteel;
        public bool Lit { get; set; }

        public FlintAndSteelItem()
        {
            this.Lit = false;
        }
    }
}
