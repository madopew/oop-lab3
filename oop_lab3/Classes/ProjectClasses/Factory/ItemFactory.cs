using System;
using System.Collections.Generic;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.Items.Blocks;
using oop_lab3.Classes.GameClasses.Items.Craftables;
using oop_lab3.Classes.GameClasses.Items.Placeables;
using oop_lab3.Classes.GameClasses.Items.Usables;
using oop_lab3.Classes.GameClasses.Items.Weapons;

namespace oop_lab3.Classes.ProjectClasses.Factory
{
    public static class ItemFactory
    {
        private static readonly Dictionary<ItemType, Func<Item>> CreationDictionary = new Dictionary<ItemType, Func<Item>>
        {
            {ItemType.Bed, () => new BedBlockItem()},
            {ItemType.Dirt, () => new DirtBlockItem()},
            {ItemType.FlintAndSteel, () => new FlintAndSteelItem()},
            {ItemType.Stick, () => new StickItem()},
            {ItemType.Sword, () => new SwordItem()},
        };
        public static Item CreateItem(ItemType type)
        {
            if (!Enum.IsDefined(typeof(ItemType), type))
            {
                throw new ArgumentException("This item type is not defined");
            }

            return CreationDictionary[type]();
        }
    }
}
