using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using oop_lab3.Classes.Factory;
using oop_lab3.Classes.InventoryClasses;
using oop_lab3.Classes.ItemClasses;

namespace oop_lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly Inventory inv;

        public string[] InventoryNames { get; }
        public string[] InventoryAmounts { get; }

        public MainWindow()
        {
            inv = Inventory.GetInstance(InventoryType.Small);
            InventoryNames = Enumerable.Repeat(string.Empty, (int) inv.Type).ToArray();
            InventoryAmounts = Enumerable.Repeat(string.Empty, (int) inv.Type).ToArray();

            InitializeComponent();
            InventoryStackPanel.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            UpdateInventoryStrings();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateInventoryStrings()
        {
            for (int i = 0; i < (int)inv.Type; i++)
            {
                if (inv[i] is null)
                {
                    InventoryNames[i] = string.Empty;
                    InventoryAmounts[i] = string.Empty;
                }
                else
                {
                    InventoryNames[i] = inv[i].Type.ToString();

                    IStackable stackableItem = inv[i] as IStackable;
                    if (stackableItem is null)
                    {
                        InventoryAmounts[i] = string.Empty;
                    }
                    else
                    {
                        InventoryAmounts[i] = stackableItem.Amount.ToString();
                    }
                }
            }
        }

        private void PickMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new PickItemDialog();
            if (dialog.ShowDialog() == true)
            {
                var selected = dialog.SelectedItem;
                if (!inv.PickUp(ItemFactory.CreateItem(selected)))
                {
                    MessageBox.Show("Inventory is full!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    RaisePropertyChanged(null);
                }
            }
        }

        private int FindClickedItem(object sender)
        {
            var menuItem = sender as MenuItem;
            if (menuItem is null)
            {
                return -1;
            }

            var contextMenu = menuItem.CommandParameter as ContextMenu;
            if (contextMenu is null)
            {
                return -1;
            }

            var b = (Border) contextMenu.PlacementTarget;
            return b.Name[b.Name.Length - 1] - '0';
        }

        private void DropOneMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            int slotIndex = FindClickedItem(sender);
            if (slotIndex == -1)
            {
                return;
            }

            if (!(inv[slotIndex] is null))
            {
                inv.Drop(slotIndex);
                RaisePropertyChanged(null);
            }
        }

        private void DropAllMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            int slotIndex = FindClickedItem(sender);
            if (slotIndex == -1)
            {
                return;
            }

            if (!(inv[slotIndex] is null))
            {
                inv.DropAll(slotIndex);
                RaisePropertyChanged(null);
            }
        }

        private void ViewMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            int slotIndex = FindClickedItem(sender);
            if (slotIndex == -1)
            {
                return;
            }

            Item item = inv[slotIndex];
            Debug.WriteLine(item.GetType());
        }
    }
}
