using Planner.Client.Command;
using Planner.Client.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Planner.Client.ViewModel
{
    class ShellController : ViewModelBase
    {
        // Private fields
        private bool isMenuOpen;
        private string currentPageTitle = "";
        private string appTitle = "GPA Planner | V 1.0";

        // Properties
        public bool IsMenuOpen
        {
            get => isMenuOpen;
            set
            {
                isMenuOpen = value;
                OnPropertyChanged();
            }
        }

        public string CurrentPageTitle
        {
            get => currentPageTitle;
            set
            {
                currentPageTitle = value;
                OnPropertyChanged();
            }
        }

        public string AppTitle
        {
            get => appTitle;
        }


        // Commands
        public ICommand OpenMenuCommand { get; }


        public ICommand Goto_SubjectsCommand { get; }
        public ICommand Goto_CalculatorCommand { get; }
        public ICommand Goto_PlannerCommand { get; }
        public ICommand Goto_TeachingCommand { get; }


        // Constructor
        public ShellController()
        {
            // UI Menu Operations
            OpenMenuCommand = new RelayCommand(OpenMenu);

            // UI GoTo Commands
            Goto_SubjectsCommand = new RelayCommand(GotoSubjects);
            Goto_CalculatorCommand = new RelayCommand(GotoCalculator);
            Goto_PlannerCommand = new RelayCommand(GotoPlanner);
            Goto_TeachingCommand = new RelayCommand(GotoTeaching);


            // UI StartUp Operations
            CurrentPageTitle = "» Subjects";
        }

        private void GotoSubjects(object? parameter)
        {


            // UI Alter Operations
            CurrentPageTitle = "» Subjects";
            OpenMenu(new object());
        }

        private void GotoPlanner(object? parameter)
        {


            // UI Alter Operations
            CurrentPageTitle = "» Planner";
            OpenMenu(new object());
        }

        private void GotoCalculator(object? parameter)
        {


            // UI Alter Operations
            CurrentPageTitle = "» Calculator";
            OpenMenu(new object());
        }

        private void GotoTeaching(object? parameter)
        {


            // UI Alter Operations
            CurrentPageTitle = "» STXT";
            OpenMenu(new object());
        }


        // Methords
        private void OpenMenu(object? parameter)
        {
            IsMenuOpen = BooleanUtilities.Toggle(IsMenuOpen);
        }
    }
}
