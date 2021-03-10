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
using Microsoft.Win32;

namespace oop_lab3
{
    /// <summary>
    /// Interaction logic for SerializeDialog.xaml
    /// </summary>
    public partial class SerializeDialog : Window
    {
        public bool IsXml { get; private set; }
        public string FileName { get; private set; }
        public SerializeDialog()
        {
            InitializeComponent();
            IsXml = true;
            FileName = string.Empty;
        }

        private void ChooseFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog opd = new SaveFileDialog
            {
                Filter = IsXml ? "XML *.xml | *.xml" : "Binary *.dat | *.dat",
                Title = "Serialize file",
            };

            if (opd.ShowDialog() == true)
            {
                FileName = opd.FileName;
                FileNameTextBlock.Text = FileName;
            }
        }

        private void SerializeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                DialogResult = true;
                this.Close();
            }
        }

        private void XmlCheckButton_OnChecked(object sender, RoutedEventArgs e)
        {
            IsXml = true;
        }

        private void BinaryCheckButton_OnChecked(object sender, RoutedEventArgs e)
        {
            IsXml = false;
        }
    }
}
