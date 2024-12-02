using Planner.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

using UnitTester.Session;

namespace Planner.Client.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddResourceDialog.xaml
    /// </summary>
    public partial class AddResourceDialog : Window
    {
        private List<Subject> ShortlistedSubjects { get; set;}
        private string[] subfolders = { "Past Papers", "Notes", "Videos", "Reference Books", "Receipts", "Random" };


        public AddResourceDialog(string prompt, string caption)
        {
            InitializeComponent();

            DataContext = this;
            Title = caption;
            CaptionTextbox.Text = prompt;
            LevelSelector.Text = "1";

            ShortlistedSubjects =  Subject.GetAllSubjects(AppSession.ConnectionString).FindAll(Subject => Subject.Level.Equals(int.Parse(LevelSelector.Text)));
            CategorySelector.ItemsSource = subfolders;
        }



        // Property to hold the user input
        public string? PathString { get; private set; } = string.Empty;
        public string? Category { get; private set; } = string.Empty;

        private void OkayReturn(object sender, RoutedEventArgs e)
        {
            if (SubSelector.SelectedItem != null && CategorySelector.SelectedItem as string != null)
            {
                DialogResult = true;
                PathString = Path.Combine((SubSelector.SelectedItem as Subject).SubjectName, (CategorySelector.SelectedItem as string));
                Category = CategorySelector.SelectedItem as string;
            }
        }

        private void CancelReturn(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void LevelSelector_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ShortlistedSubjects = Subject.GetAllSubjects(AppSession.ConnectionString).FindAll(Subject => Subject.Level.Equals(int.Parse(LevelSelector.Text)));

            }
            catch
            {
                ShortlistedSubjects = Subject.GetAllSubjects(AppSession.ConnectionString);
            }
            
            SubSelector.ItemsSource = ShortlistedSubjects;
        }
    }
}
