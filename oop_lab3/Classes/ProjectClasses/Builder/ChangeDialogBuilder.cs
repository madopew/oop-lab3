using System;
using System.Linq;
using System.Windows.Controls;
using oop_lab3.Classes.GameClasses.ItemClasses;
using oop_lab3.Classes.GameClasses.Items.Placeables;
using oop_lab3.Classes.GameClasses.Items.Usables;
using oop_lab3.Classes.GameClasses.Items.Weapons;
using oop_lab3.Classes.GameClasses.Other;
using Xceed.Wpf.Toolkit;

namespace oop_lab3.Classes.ProjectClasses.Builder
{
    public class ChangeDialogBuilder : DialogBuilder
    {
        public override void Build()
        {
            if (ParentWindow is null || Panel is null || Item is null)
            {
                throw new InvalidOperationException("Not all fields are initialized");
            }

            AddTextBlock($"Type: {this.Item.Type.ToString()}", "ItemType");

            AddStackable();
            AddSpecific();

            AddCloseButton("Save", "SaveButton");
        }

        private void AddStackable()
        {
            if (Item is IStackable stackItem)
            {
                AddComboBoxWithLabel("Amount", "ItemAmount", Enumerable.Range(1, stackItem.StackMax),
                    stackItem.Amount - 1,
                    (o, e) =>
                    {
                        stackItem.Amount = ((ComboBox)o).SelectedIndex + 1;
                    });
            }
        }

        private void AddSpecific()
        {
            switch (this.Item)
            {
                case SwordItem sword:
                    var amount = Enum.GetValues(typeof(Enchantments)).Cast<int>().Sum() + 1;
                    AddComboBoxWithLabel("Enchantment", "ItemEnchantment", Enumerable.Range(0, amount).Cast<Enchantments>(),
                        (int)sword.Enchantments,
                        (o, e) =>
                        {
                            sword.Enchantments = (Enchantments)((ComboBox)o).SelectedIndex;
                        });
                    break;
                case FlintAndSteelItem flint:
                    AddCheckBoxWithLabel("Is lit", "ItemLit", flint.Lit,
                        (o, e) =>
                        {
                            flint.Lit = ((CheckBox) o).IsChecked ?? false;
                        });
                    break;
                case BedBlockItem bed:
                    AddColorPicker("ItemColor", bed.Color, (o, e) =>
                    {
                        var selectedColor = ((ColorPicker) o).SelectedColor.Value;
                        bed.Color = new Color(selectedColor.R, selectedColor.G, selectedColor.B);
                    });
                    break;
            }
        }
    }
}
