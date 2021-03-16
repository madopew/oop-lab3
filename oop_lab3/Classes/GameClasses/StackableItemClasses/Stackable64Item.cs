using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;

namespace oop_lab3.Classes.StackableItemClasses
{
    [Serializable]
    public abstract class Stackable64Item : StackableItem
    {
        public override int StackMax => 64;
    }
}
