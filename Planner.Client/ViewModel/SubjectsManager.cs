using Planner.Client.Command;
using Planner.Client.Helper;
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

        // per Subject
        private int _subjectId;
        private int _level;
        private string _subjectName = null!;
        private string _subjectCode = null!;
        private int _credits;
        private int _gpaCredits;
        private SubjectType _subjectType;
        private string? _description;

        // For UI
        private Visibility _creatorVisibility;
        private Visibility _editorVisibility;

        // UI Properties
        public Visibility CreatorVisibility
        {
            get => _creatorVisibility;
            set
            {
                _creatorVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility EditorVisibility
        {
            get => _editorVisibility;
            set
            {
                _editorVisibility = value;
                OnPropertyChanged();
            }
        }

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

        // =========================================================== Public Properties

        public int SubjectId
        {
            get => _subjectId;
            set
            {
                _subjectId = value;
                OnPropertyChanged();
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }

        public string SubjectName
        {
            get => _subjectName;
            set
            {
                _subjectName = value;
                OnPropertyChanged();
            }
        }

        public string SubjectCode
        {
            get => _subjectCode;
            set
            {
                _subjectCode = value;
                OnPropertyChanged();
            }
        }

        public int Credits
        {
            get => _credits;
            set
            {
                _credits = value;
                OnPropertyChanged();
            }
        }

        public int GPACredits
        {
            get => _gpaCredits;
            set
            {
                _gpaCredits = value;
                OnPropertyChanged();
            }
        }

        public SubjectType SubjectType
        {
            get => _subjectType;
            set
            {
                _subjectType = value;
                OnPropertyChanged();
            }
        }

        public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        // Special for the Enum of Subject Type
        public Array SubjectTypes => Enum.GetValues(typeof(SubjectType));

        // Commands
        public ICommand OpenDialogCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CreateCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand LoadCommand { get; }

        // Buttons Commands
        public ICommand OpenCreateCommand { get; }
        public ICommand OpenEditCommand { get; }


        // Constructor
        public SubjectsManager()
        {
            _subjects           = new ObservableCollection<Subject>();

            OpenDialogCommand   = new RelayCommand(OpenDialog);
            CreateCommand       = new RelayCommand(CreateSubject, CanCreateSubject);           
            DeleteCommand       = new RelayCommand(DeleteSelectedSubject, CanDelete);
            EditCommand         = new RelayCommand(EditSelectedSubject, CanEdit);
            LoadCommand         = new RelayCommand(OpenLoadDialog);

            OpenCreateCommand = new RelayCommand(_ => ToggleCreatePanel(true));
            OpenEditCommand = new RelayCommand(_ => ToggleCreatePanel(false),CanOpenEditor);

            // Mock data load on initialization
            LoadSubjectsFromDatabase();

            // Keep Editor Closed at Start
            EditorVisibility = Visibility.Collapsed;
        }

        // UI Validator
        private bool CanOpenEditor(object? parameter)
        {
            if (SelectedSubject == null)
            {
                return false;
            }

            return true;
        }

        // UI Operations
        private void ToggleCreatePanel(bool isCreate)
        {
            if(isCreate)
            {
                ClearForm();

                // TESING 0007
                //TestUtlity.ExecuteTestCode(() => { MessageBox.Show("Create"); });

                CreatorVisibility = Visibility.Visible;
                EditorVisibility = Visibility.Collapsed;
            }
            else
            {
                AssignEditor();

                //TestUtlity.ExecuteTestCode(() => { MessageBox.Show("Edit"); });
                CreatorVisibility = Visibility.Collapsed;
                EditorVisibility = Visibility.Visible;
            }

        }

        #region UI Interactions

        #endregion

        // Load subjects from database (mock implementation)
        private void LoadSubjectsFromDatabase()
        {
            if(Subjects.Count > 0)
            {
                Subjects.Clear();
            }

            var subjectsList = Subject.GetAllSubjects(AppSession.ConnectionString);

            // Convert List to ObservableCollection
            Subjects = new ObservableCollection<Subject>(subjectsList);
        }

        // Command methods
        private void OpenDialog(object? parameter)
        {
            // Configure open file dialog box
            IOHelper.ImportSubjectsFromCSV(AppSession.ConnectionString);
            LoadSubjectsFromDatabase();
        }

        // Create New Subject
        private void CreateSubject(object? paramter)
        {
            var newSubject = new Subject
            {
                SubjectName = SubjectName,
                SubjectCode = SubjectCode,
                Level = Level,
                Credits = Credits,
                GPACredits = GPACredits,
                SubjectType = SubjectType,
                Description = Description
            };

            // TESING 0007
            TestUtlity.ExecuteTestCode(() => { MessageBox.Show(ObjectUtlility.PrintProperties(newSubject)); });

            // PRODUCTION
            TestUtlity.ExecuteProductionCode(() => { Subject.AddSubject(AppSession.ConnectionString, newSubject); });

            LoadSubjectsFromDatabase();
            ClearForm();
        }

        private void AssignEditor()
        {
            if (SelectedSubject != null)
            {
                SubjectName = SelectedSubject.SubjectName;
                SubjectCode = SelectedSubject.SubjectCode;
                Level = SelectedSubject.Level;
                Credits = SelectedSubject.Credits;
                GPACredits = SelectedSubject.GPACredits;
                SubjectType = SelectedSubject.SubjectType;
                Description = SelectedSubject.Description; 
            }
        }

        private void ClearForm()
        {
            SubjectName = string.Empty;
            SubjectCode = string.Empty;
            Level = 0;
            Credits = 0;
            GPACredits = 0;
            SubjectType = SubjectType.Compulsory;  // Assuming 'Core' is a default value.
            Description = string.Empty;
        }

        private void CreateDialog(object? parameter)
        {
            // Logic to open a dialog box (e.g.; Add new subject)
            SubjectAdder _subjectsAdder = new();
            _subjectsAdder.ShowDialog();
        }

        private void DeleteSelectedSubject(object? parameter)
        {
            var mbResult = MessageBox.Show("Are You Sure u want to delete?", "Test", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            
            if (SelectedSubject != null && mbResult == MessageBoxResult.OK)
            {
                TestUtlity.ExecuteProductionCode(() => { Subject.DeleteSubjectById(AppSession.ConnectionString, SelectedSubject); });
                TestUtlity.ExecuteProductionCode(() => { Subject.ResetSubjectIdSequence(AppSession.ConnectionString); });
            }
            LoadSubjectsFromDatabase();

        }


        private void EditSelectedSubject(object? parameter)
        {
            if (SelectedSubject != null)
            {
                var editSubject = new Subject
                {
                    SubjectId = SelectedSubject.SubjectId,
                    SubjectName = SubjectName,
                    SubjectCode = SubjectCode,
                    Level = Level,
                    Credits = Credits,
                    GPACredits = GPACredits,
                    SubjectType = SubjectType,
                    Description = Description
                };


                // TESING 0007
                TestUtlity.ExecuteTestCode(() => { MessageBox.Show(ObjectUtlility.PrintProperties(editSubject)); });

                // PRODUCTION
                TestUtlity.ExecuteProductionCode(() => { Subject.UpdateSubjectById(AppSession.ConnectionString, editSubject); });

                LoadSubjectsFromDatabase();
                ClearForm();
                // Logic to open an edit dialog box with the selected subject's details 
            }
        }

        

        private void OpenLoadDialog(object? parameter)
        {
            // Logic to open a dialog for loading subjects
        }


        #region Validations
        private bool CanEdit(object? parameter) => SelectedSubject != null;
        private bool CanDelete(object? parameter) => SelectedSubject != null;
        private bool CanCreateSubject(object? parameter) =>
            !string.IsNullOrWhiteSpace(SubjectName) &&
            !string.IsNullOrWhiteSpace(SubjectCode) &&
            Credits > 0 &&
            GPACredits > -1; 
        #endregion
    }
}
