using System.Windows;
using System.Windows.Controls;
using oop_lab3.Classes.GameClasses.ItemClasses;

namespace oop_lab3.Classes.ProjectClasses.Builder
{
    public interface IDialogBuilder
    {
        Window ParentWindow { get; set; }
        StackPanel Panel { get; set; }
        Item Item { get; set; }
        void Build();
    }
}