using System;

namespace oop_lab3.Classes.GameClasses.StackableItemClasses
{
    [Serializable]
    public abstract class Stackable16Item : StackableItem
    {
        public override int StackMax => 16;
    }
}
