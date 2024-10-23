using Planner.Client.Command;
using Planner.Client.View.Dialogs;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UnitTester.Session;

namespace Planner.Client.ViewModel
{
    class SubjectsManager : ViewModelBase
    {
        // Private fields
        private ObservableCollection<Subject> _subjects;
        private Subject? _selectedSubject;

        // Properties
        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }

        public Subject? SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand OpenDialogCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand LoadCommand { get; }

        // Constructor
        public SubjectsManager()
        {
            _subjects           = new ObservableCollection<Subject>();

            OpenDialogCommand   = new RelayCommand(OpenDialog);
            CreateCommand       = new RelayCommand(CreateDialog);           
            DeleteCommand       = new RelayCommand(DeleteSelectedSubject, CanDelete);
            EditCommand         = new RelayCommand(EditSelectedSubject, CanEdit);
            LoadCommand         = new RelayCommand(OpenLoadDialog);

            // Mock data load on initialization
            LoadSubjectsFromDatabase();
        }

        // Load subjects from database (mock implementation)
        private void LoadSubjectsFromDatabase()
        {
            var subjectsList = Subject.GetAllSubjects(AppSession.ConnectionString);

            // Convert List to ObservableCollection
            Subjects = new ObservableCollection<Subject>(subjectsList);
        }

        // Command methods
        private void OpenDialog(object? parameter)
        {
            // Logic to open a dialog box (e.g., Add new subject)
            SubjectsLoader _subjectLoader = new();
            _subjectLoader.ShowDialog();
        }

        private void CreateDialog(object? parameter)
        {
            // Logic to open a dialog box (e.g., Add new subject)
            SubjectAdder _subjectsAdder = new();
            _subjectsAdder.ShowDialog();
        }

        private void DeleteSelectedSubject(object? parameter)
        {
            if (SelectedSubject != null)
            {
                Subjects.Remove(SelectedSubject);
            }
        }

        private bool CanDelete(object? parameter) => SelectedSubject != null;

        private void EditSelectedSubject(object? parameter)
        {
            // Logic to open an edit dialog box with the selected subject's details
        }

        private bool CanEdit(object? parameter) => SelectedSubject != null;

        private void OpenLoadDialog(object? parameter)
        {
            // Logic to open a dialog for loading subjects
        }
    }
}
