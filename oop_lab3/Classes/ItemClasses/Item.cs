using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab3.Classes.ItemClasses
{
    public abstract class Item
    {
        public abstract ItemType Type { get; }

        public string Name => Enum.GetName(typeof(ItemType), this.Type);
    }
}
