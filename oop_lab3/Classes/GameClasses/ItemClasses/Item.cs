using System;
using System.Xml.Serialization;
using oop_lab3.Classes.GameClasses.Items.Blocks;
using oop_lab3.Classes.GameClasses.Items.Craftables;
using oop_lab3.Classes.GameClasses.Items.Placeables;
using oop_lab3.Classes.GameClasses.Items.Usables;
using oop_lab3.Classes.GameClasses.Items.Weapons;

namespace oop_lab3.Classes.GameClasses.ItemClasses
{
    [Serializable]
    [XmlInclude(typeof(BedBlockItem))]
    [XmlInclude(typeof(SwordItem))]
    [XmlInclude(typeof(DirtBlockItem))]
    [XmlInclude(typeof(FlintAndSteelItem))]
    [XmlInclude(typeof(StickItem))]
    public abstract class Item
    {
        public abstract ItemType Type { get; }

        public string Name => Enum.GetName(typeof(ItemType), this.Type);
    }
}
