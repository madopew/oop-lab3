using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.Items.Placeables;
using oop_lab3.Classes.Items.Usables;
using oop_lab3.Classes.Items.Weapons;
using oop_lab3.Classes.Other;
using Xceed.Wpf.Toolkit;

namespace oop_lab3.Classes.Builder
{
    public class ChangeDialogBuilder : DialogBuilder
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

            base.AddCloseButton("Save", "SaveButton");
        }

        private void AddStackable()
        {
            IStackable stackItem = this.Item as IStackable;
            if (stackItem != null)
            {
                base.AddComboBoxWithLabel("Amount", "ItemAmount", Enumerable.Range(1, stackItem.StackMax),
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
                    int amount = Enum.GetValues(typeof(Enchantments)).Cast<int>().Sum() + 1;
                    base.AddComboBoxWithLabel("Enchantment", "ItemEnchantment", Enumerable.Range(0, amount).Cast<Enchantments>(),
                        (int)sword.Enchantments,
                        (o, e) =>
                        {
                            sword.Enchantments = (Enchantments)((ComboBox)o).SelectedIndex;
                        });
                    break;
                case FlintAndSteelItem flint:
                    base.AddCheckBoxWithLabel("Is lit", "ItemLit", flint.Lit,
                        (o, e) =>
                        {
                            flint.Lit = ((CheckBox) o).IsChecked ?? false;
                        });
                    break;
                case BedBlockItem bed:
                    base.AddColorPicker("ItemColor", bed.Color, (o, e) =>
                    {
                        var selectedColor = ((ColorPicker) o).SelectedColor.Value;
                        bed.Color = new Color(selectedColor.R, selectedColor.G, selectedColor.B);
                    });
                    break;
            }
        }
    }
}
