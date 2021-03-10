using System;
using System.Collections.Generic;
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
using oop_lab3.Classes.Builder;
using oop_lab3.Classes.ItemClasses;

namespace oop_lab3
{
    /// <summary>
    /// Interaction logic for ViewDialog.xaml
    /// </summary>
    public partial class ViewDialog : Window
    {
        public ViewDialog(IDialogBuilder builder)
        {
            InitializeComponent();

            builder.ParentWindow = this;
            builder.Panel = ViewStackPanel;
            builder.Build();
        }

        private ViewDialog()
        {
            InitializeComponent();
        }
    }
}
