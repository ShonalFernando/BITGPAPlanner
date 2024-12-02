using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace Planner.Client.View.Dialogs
{
    /// <summary>
    /// Interaction logic for GridSelector.xaml
    /// </summary>
    public partial class GridSelector : Window
    {
        public GridSelector(List<object> objectCollection, string prompt, string caption, string current)
        {
            InitializeComponent();

            DataContext = this;
            Title = caption;
            CaptionTextbox.Text = prompt;

            MainGrid.ItemsSource = objectCollection;
        }

        // Property to hold the user input
        public object? SelectedObject { get; private set; }

        private void OkayReturn(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedItem != null)
            {
                DialogResult = true;
                SelectedObject = MainGrid.SelectedItem; 
            }
        }

        private void CancelReturn(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
