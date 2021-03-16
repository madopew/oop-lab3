using System;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.StackableItemClasses;

namespace oop_lab3.Classes.GameClasses.Items.Craftables
{
    [Serializable]
    public sealed class StickItem : Stackable16Item
    {
        public override ItemType Type => ItemType.Stick;
    }
}
