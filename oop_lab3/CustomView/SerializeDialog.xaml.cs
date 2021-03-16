using System.Windows;
using Microsoft.Win32;

namespace oop_lab3.CustomView
{
    /// <summary>
    /// Interaction logic for SerializeDialog.xaml
    /// </summary>
    public partial class SerializeDialog
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
