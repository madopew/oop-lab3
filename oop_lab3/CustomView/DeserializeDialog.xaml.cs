using System.Windows;
using Microsoft.Win32;

namespace oop_lab3.CustomView
{
    /// <summary>
    /// Interaction logic for DeserializeDialog.xaml
    /// </summary>
    public partial class DeserializeDialog
    {
        public bool IsXml { get; private set; }
        public string FileName { get; private set; }
        public DeserializeDialog()
        {
            InitializeComponent();
        }

        private void ChooseFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog
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

        private void DeserializeButton_OnClick(object sender, RoutedEventArgs e)
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
