using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.NonstackableItemClasses;

namespace oop_lab3.Classes.Items.Weapons
{
    public sealed class SwordItem : NonstackableItem, IEnchantable
    {
        public override ItemType Type => ItemType.Sword;

        public Enchantments Enchantments { get; set; }

        public void Disenchant()
        {
            this.Enchantments = Enchantments.None;
        }

        public void Enchant(Enchantments enchantments)
        {
            if (!Enum.IsDefined(typeof(Enchantments), enchantments))
            {
                throw new ArgumentException("Incorrect enchantment", nameof(enchantments));
            }

            this.Enchantments |= enchantments;
        }
    }
}
