using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;
using oop_lab3.Classes.Builder;
using oop_lab3.Classes.Factory;
using oop_lab3.Classes.InventoryClasses;
using oop_lab3.Classes.ItemClasses;
using oop_lab3.Classes.SerializerAdapter;

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

        private void ClearMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            inv.Clear();
            RaisePropertyChanged(null);
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

            IDialogBuilder builder = new ViewDialogBuilder();
            builder.Item = item;
            new ViewDialog(builder).ShowDialog();
        }

        private void ChangeMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            int slotIndex = FindClickedItem(sender);
            if (slotIndex == -1)
            {
                return;
            }

            Item item = inv[slotIndex];

            IDialogBuilder builder = new ChangeDialogBuilder();
            builder.Item = item;
            ViewDialog dialog = new ViewDialog(builder);

            if (dialog.ShowDialog() == true)
            {
                RaisePropertyChanged(null);
            }
        }

        private void SerializeMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            SerializeDialog dialog = new SerializeDialog();
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            bool isXml = dialog.IsXml;
            string fileName = dialog.FileName;

            var items = new Item[(int) inv.Type];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = inv[i];
            }

            ISerializer serializer;
            if (isXml)
            {
                serializer = new XmlSerializerAdapter(items.GetType());
            }
            else
            {
                serializer = new BinaryFormatterAdapter();
            }

            using (FileStream f = new FileStream(fileName, FileMode.Create))
            {
                try
                {
                    serializer.Serialize(f, items);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    MessageBox.Show("Inventory cannot be serialized!", "Error!", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }

        private void DeserializeMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            DeserializeDialog dialog = new DeserializeDialog();
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            bool isXml = dialog.IsXml;
            string fileName = dialog.FileName;

            ISerializer serializer;
            if (isXml)
            {
                serializer = new XmlSerializerAdapter(typeof(Item[]));
            }
            else
            {
                serializer = new BinaryFormatterAdapter();
            }

            using (FileStream f = new FileStream(fileName, FileMode.Open))
            {
                Item[] items;
                try
                {
                    items = (Item[]) serializer.Deserialize(f);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    MessageBox.Show("Cannot get object data!", "Error!", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                for (int i = 0; i < items.Length; i++)
                {
                    inv[i] = items[i];
                }

                RaisePropertyChanged(null);
            }
        }
    }
}
