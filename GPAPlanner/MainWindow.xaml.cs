using GPAPlanner.Model;
using GPAPlanner.Model.NonRelational;
using GPAPlanner.Services.Initializors;
using GPAPlanner.Session;
using GPAPlanner.View;
using GPAPlanner.ViewModel;
using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPAPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AppSession appSession = new();
            appSession.InitializeSession();

            DataInitializer dataInitializer = new(appSession);
            dataInitializer.LoadSubjects();
            dataInitializer.LoadGradesTable();
            DataInitializer.CreateSemesters();


            GPAProcessor gpapro = new();

            CalculationPortal sem = new();
            sem.DataContext = gpapro;
            NavFrame.Content = sem;
        }
    }
}
