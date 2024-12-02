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

namespace Planner.Client.View.Dialogs
{
    /// <summary>
    /// Interaction logic for DropSelectorDialog.xaml
    /// </summary>
    public partial class DropSelectorDialog : Window
    {
        public DropSelectorDialog(List<string> stringCollection, string prompt, string caption, string current)
        {
            InitializeComponent();

            DataContext = this;
            Title = caption;
            CaptionTextbox.Text = prompt;

            CompSelector.ItemsSource = stringCollection;
        }

        // Property to hold the user input
        public string? SelectedString { get; private set; } = string.Empty;

        private void OkayReturn(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            SelectedString = CompSelector.SelectedItem as string;
        }

        private void CancelReturn(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
