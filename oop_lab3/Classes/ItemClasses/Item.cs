using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using oop_lab3.Classes.Items.Blocks;
using oop_lab3.Classes.Items.Craftables;
using oop_lab3.Classes.Items.Placeables;
using oop_lab3.Classes.Items.Usables;
using oop_lab3.Classes.Items.Weapons;

namespace oop_lab3.Classes.ItemClasses
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
