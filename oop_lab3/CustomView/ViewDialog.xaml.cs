using oop_lab3.Classes.ProjectClasses.Builder;

namespace oop_lab3.CustomView
{
    /// <summary>
    /// Interaction logic for ViewDialog.xaml
    /// </summary>
    public partial class ViewDialog
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
