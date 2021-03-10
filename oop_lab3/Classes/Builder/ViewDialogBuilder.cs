using System;
using System.Windows;
using System.Windows.Controls;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.Items.Placeables;
using oop_lab3.Classes.Items.Usables;
using oop_lab3.Classes.Items.Weapons;

namespace oop_lab3.Classes.Builder
{
    public class ViewDialogBuilder : DialogBuilder
    {

        public override void Build()
        {
            if (ParentWindow is null || Panel is null || Item is null)
            {
                throw new InvalidOperationException("Not all fields are initialized");
            }

            base.AddTextBlock($"Type: {this.Item.Type.ToString()}", "ItemType");

            this.AddStackable();
            this.AddSpecific();
            base.AddCloseButton("OK", "CloseButton");
        }

        private void AddStackable()
        {
            IStackable stackItem = this.Item as IStackable;
            if (stackItem != null)
            {
                base.AddTextBlock($"Amount: {stackItem.Amount}", "ItemAmount");
                base.AddTextBlock($"Max: {stackItem.StackMax}", "ItemMaxAmount");
            }
        }

        private void AddSpecific()
        {
            switch (this.Item)
            {
                case BedBlockItem bed:
                    base.AddTextBlock($"Color: {bed.Color}", "ItemColor");
                    break;
                case FlintAndSteelItem flint:
                    base.AddTextBlock($"Is lit: {flint.Lit}", "ItemLit");
                    break;
                case SwordItem sword:
                    base.AddTextBlock($"Enchantments: {sword.Enchantments}", "ItemEnchantments");
                    break;
            }
        }
    }
}