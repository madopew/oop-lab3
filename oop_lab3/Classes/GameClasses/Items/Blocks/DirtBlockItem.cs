using System;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.StackableItemClasses;

namespace oop_lab3.Classes.GameClasses.Items.Blocks
{
    [Serializable]
    public sealed class DirtBlockItem : Stackable64Item
    {
        public override ItemType Type => ItemType.Dirt;
    }
}
