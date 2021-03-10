using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.Items.Blocks;
using oop_lab3.Classes.Items.Craftables;
using oop_lab3.Classes.Items.Placeables;
using oop_lab3.Classes.Items.Usables;
using oop_lab3.Classes.Items.Weapons;

namespace oop_lab3.Classes.Factory
{
    public static class ItemFactory
    {
        private static readonly Dictionary<ItemType, Func<Item>> creationDictionary = new Dictionary<ItemType, Func<Item>>
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

            return creationDictionary[type]();
        }
    }
}
