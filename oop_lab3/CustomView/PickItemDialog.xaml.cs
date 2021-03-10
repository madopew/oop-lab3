using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using oop_lab3.Classes.ItemClasses;

namespace oop_lab3
{
    /// <summary>
    /// Interaction logic for PickItemDialog.xaml
    /// </summary>
    public partial class PickItemDialog : Window
    {
        public ObservableCollection<ComboBoxItem> CbItems { get; set; }
        public ItemType SelectedItem { get; private set; }
        public PickItemDialog()
        {
            InitializeComponent();
            DialogStackPanel.DataContext = this;

            CbItems = new ObservableCollection<ComboBoxItem>();
            foreach (var type in Enum.GetValues(typeof(ItemType)))
            {
                CbItems.Add(new ComboBoxItem
                {
                    Name = type.ToString(),
                    Content = type.ToString(), 
                });
            }

            CbItems[0].IsSelected = true;
            ItemComboBox.SelectedIndex = 0;
            SelectedItem = (ItemType) Enum.GetValues(typeof(ItemType)).GetValue(0);
        }

        private void ItemComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItem = (ItemType) Enum.GetValues(typeof(ItemType)).GetValue(ItemComboBox.SelectedIndex);
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
