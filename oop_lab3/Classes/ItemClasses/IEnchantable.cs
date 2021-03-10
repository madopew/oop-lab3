namespace oop_lab3.Classes.ItemClasses
{
    public interface IEnchantable
    {
        Enchantments Enchantments { get; set; }
        void Enchant(Enchantments enchantments);
        void Disenchant();
    }
}