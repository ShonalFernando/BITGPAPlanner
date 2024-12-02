using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        // Property to hold the user input
        public string InputText { get; private set; } = string.Empty;


        public InputDialog(string prompt, string caption, string current)
        {
            InitializeComponent();
            DataContext = this;
            Title = caption;
            CaptionTextbox.Text = prompt;
            InputTextbox.Text = current;
        }

        private void OkayReturn(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            InputText = InputTextbox.Text;
        }

        private void CancelReturn(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
