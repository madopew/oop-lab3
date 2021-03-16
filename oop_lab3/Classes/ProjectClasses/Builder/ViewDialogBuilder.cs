using System;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.Items.Placeables;
using oop_lab3.Classes.GameClasses.Items.Usables;
using oop_lab3.Classes.GameClasses.Items.Weapons;

namespace oop_lab3.Classes.ProjectClasses.Builder
{
    public class ViewDialogBuilder : DialogBuilder
    {

        public override void Build()
        {
            if (ParentWindow is null || Panel is null || Item is null)
            {
                throw new InvalidOperationException("Not all fields are initialized");
            }

            AddTextBlock($"Type: {this.Item.Type.ToString()}", "ItemType");

            this.AddStackable();
            this.AddSpecific();
            AddCloseButton("OK", "CloseButton");
        }

        private void AddStackable()
        {
            if (this.Item is IStackable stackItem)
            {
                AddTextBlock($"Amount: {stackItem.Amount}", "ItemAmount");
                AddTextBlock($"Max: {stackItem.StackMax}", "ItemMaxAmount");
            }
        }

        private void AddSpecific()
        {
            switch (this.Item)
            {
                case BedBlockItem bed:
                    AddTextBlock($"Color: {bed.Color}", "ItemColor");
                    break;
                case FlintAndSteelItem flint:
                    AddTextBlock($"Is lit: {flint.Lit}", "ItemLit");
                    break;
                case SwordItem sword:
                    AddTextBlock($"Enchantments: {sword.Enchantments}", "ItemEnchantments");
                    break;
            }
        }
    }
}