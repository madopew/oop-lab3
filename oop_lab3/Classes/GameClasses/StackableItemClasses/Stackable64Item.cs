using System;

namespace oop_lab3.Classes.GameClasses.StackableItemClasses
{
    [Serializable]
    public abstract class Stackable64Item : StackableItem
    {
        public override int StackMax => 64;
    }
}
