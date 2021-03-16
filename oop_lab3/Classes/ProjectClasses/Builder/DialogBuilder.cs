using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using oop_lab3.Classes.GameClasses.ItemClasses;
using Xceed.Wpf.Toolkit;
using Color = oop_lab3.Classes.GameClasses.Other.Color;

namespace oop_lab3.Classes.ProjectClasses.Builder
{
    public abstract class DialogBuilder : IDialogBuilder
    {
        private Window parent;
        private StackPanel panel;
        private Item item;

        public Window ParentWindow
        {
            get => parent;
            set => parent = value ?? throw new ArgumentNullException(nameof(value));
            
        }
        public StackPanel Panel
        {
            get => panel;
            set => panel = value ?? throw new ArgumentNullException(nameof(value));
            
        }
        public Item Item
        {
            get => item;
            set => item = value ?? throw new ArgumentNullException(nameof(value));
            
        }

        public abstract void Build();

        protected void AddTextBlock(string text, string name)
        {
            this.panel.Children.Add(new TextBlock
            {
                Text = text,
                Name = name,
                Margin = new Thickness(0, 0, 0, 10),
            });
        }

        protected void AddCloseButton(string text, string name)
        {
            Button b = new Button
            {
                Content = text,
                Name = name,
            };

            b.Click += (o, e) =>
            {
                this.parent.DialogResult = true;
                this.parent.Close();
            };

            this.panel.Children.Add(b);
        }

        protected void AddComboBoxWithLabel(string label, string name, IEnumerable collection, 
            int selectedIndex, Action<object, SelectionChangedEventArgs> onItemChange)
        {
            StackPanel horizontalPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10),
            };

            horizontalPanel.Children.Add(new TextBlock
            {
                Text = $"{label}:",
                Margin = new Thickness(0, 0, 5, 0),
            });

            ComboBox cb = new ComboBox
            {
                Name = name,
                ItemsSource = collection,
                SelectedIndex = selectedIndex,
            };
            cb.SelectionChanged += (o, e) => onItemChange(o, e);

            horizontalPanel.Children.Add(cb);

            this.panel.Children.Add(horizontalPanel);
        }

        protected void AddCheckBoxWithLabel(string label, string name, bool value, Action<object, RoutedEventArgs> onChecked)
        {
            StackPanel horizontalPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 0, 0, 10),
            };

            horizontalPanel.Children.Add(new TextBlock
            {
                Text = $"{label}:",
                Margin = new Thickness(0, 0, 5, 0),
            });

            CheckBox cb = new CheckBox
            {
                Name = name,
                IsChecked = value,
            };
            cb.Checked += (o, e) => onChecked(o, e);

            horizontalPanel.Children.Add(cb);

            this.panel.Children.Add(horizontalPanel);
        }

        protected void AddColorPicker(string name, Color selectedColor, Action<object, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?>> onColorChange)
        {
            var color = new System.Windows.Media.Color();
            color.R = selectedColor.R;
            color.G = selectedColor.G;
            color.B = selectedColor.B;
            color.A = byte.MaxValue;

            ColorPicker cp = new ColorPicker
            {
                DisplayColorAndName = true,
                Name = name,
                SelectedColor = color,
                UsingAlphaChannel = false,
                ShowStandardColors = false,
                Margin = new Thickness(0, 0, 0, 10),
            };
            cp.SelectedColorChanged += (o, e) => onColorChange(o, e);

            this.Panel.Children.Add(cp);
        }
    }
}