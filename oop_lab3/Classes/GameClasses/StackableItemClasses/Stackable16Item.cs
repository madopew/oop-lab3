using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab3.Classes.StackableItemClasses
{
    [Serializable]
    public abstract class Stackable16Item : StackableItem
    {
        public override int StackMax => 16;
    }
}
