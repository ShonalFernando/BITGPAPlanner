using Microsoft.Toolkit.Uwp.Notifications;
using Planner.Client.Command;
using Planner.Client.Helper;
using Planner.Client.View.Pages;
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
        private string appTitle = "BIT Virtual Assistant | V 1.0";

        private Dictionary<string, object> PageDefintions;
        private object currentPage;

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

        public object CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand OpenMenuCommand { get; }


        public ICommand Goto_SubjectsCommand { get; }
        public ICommand Goto_CalculatorCommand { get; }
        public ICommand Goto_PlannerCommand { get; }
        public ICommand Goto_TeachingCommand { get; }
        public ICommand Goto_VLECommand { get; }
        public ICommand Goto_DrawerCommand { get; }


        // Constructor
        public ShellController()
        {
            // UI Menu Operations
            OpenMenuCommand = new RelayCommand(OpenMenu);

            // UI GoTo Commands
            Goto_SubjectsCommand = new RelayCommand(_ => Goto("Subjects"));
            Goto_CalculatorCommand = new RelayCommand(_ => Goto("Calculator"));
            Goto_PlannerCommand = new RelayCommand(_ => Goto("Planner"));
            Goto_TeachingCommand = new RelayCommand(_ => Goto("STXT"));
            Goto_VLECommand = new RelayCommand(_ => Goto("VLE"));
            Goto_DrawerCommand = new RelayCommand(_ => Goto("Drawer"));

            // Load Pages
            PageDefintions = new Dictionary<string, object>();
            PageDefintions.Add("Calculator", new CalculatorPage());
            PageDefintions.Add("Subjects", new SubjectsViewer());
            PageDefintions.Add("Planner", new SubjectsViewer());
            PageDefintions.Add("STXT", new SubjectsViewer());
            PageDefintions.Add("VLE", new VLEViewer());
            PageDefintions.Add("Drawer", new Drawer());

            // Load Current Page
            currentPage = CurrentPage = PageDefintions["Calculator"];

            // UI StartUp Operations
            CurrentPageTitle = "» Subjects";
        }

        private void Goto (string pageName)
        {
            // Check if user navigates to the same page
            if (CurrentPage != PageDefintions[pageName])
            {
                // Get the Page from the Page dictionary
                CurrentPageTitle = $"» {pageName}";
                CurrentPage = PageDefintions[pageName];
                
                // Reload Transition
                var contentPresenter = Application.Current.MainWindow.FindName("PageFrameHolder") as MahApps.Metro.Controls.TransitioningContentControl;
                contentPresenter?.ReloadTransition(); 
            }
            
            // Close the menu if opened
            CloseMenu();
        }

        // Methords
        private void OpenMenu(object? parameter)
        {
            IsMenuOpen = true;
        }

        private void CloseMenu()
        {
            if(IsMenuOpen)
            {
                IsMenuOpen = false;
            }
        }

    }
}
