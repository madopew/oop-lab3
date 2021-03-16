using System;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.NonstackableItemClasses;

namespace oop_lab3.Classes.GameClasses.Items.Weapons
{
    [Serializable]
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
