using Planner.Client.Command;
using Planner.Client.Helper;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UnitTester.Session;

namespace Planner.Client.ViewModel
{
    class SubjectCreator : ViewModelBase, IDataErrorInfo
    {
        // =========================================================== Properties

        private string _subjectName = string.Empty;
        private string _subjectCode = string.Empty;
        private int _level;
        private int _credits;
        private int _gpaCredits;
        private SubjectType _subjectType;
        private string? _description;

        public ObservableCollection<Subject> Subjects { get; } = new();

        // Observable Collection to hold Enum values for ComboBox binding
        public ObservableCollection<SubjectType> SubjectTypes { get; set; }

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

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
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

        // =========================================================== Commands

        public ICommand CreateSubjectCommand { get; }

        // =========================================================== Constructor

        public SubjectCreator()
        {
            // Initialize Commands
            CreateSubjectCommand = new RelayCommand(CreateSubject, CanCreateSubject);

            // Populate the ObservableCollection with all enum values
            SubjectTypes = new ObservableCollection<SubjectType>(
                Enum.GetValues(typeof(SubjectType)).Cast<SubjectType>());


        }

        // =========================================================== Methods

        private void CreateSubject(object? parameter)
        {
            MessageBox.Show("Test");
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

            // TESING 0001
            TestUtlity.ExecuteTestCode(() => {MessageBox.Show(ObjectUtlility.PrintProperties(newSubject));});

            // PRODUCTION
            TestUtlity.ExecuteProductionCode(() => {Subject.AddSubject(AppSession.ConnectionString , newSubject); });

            ClearForm();
        }

        private bool CanCreateSubject(object? parameter) =>
            !string.IsNullOrWhiteSpace(SubjectName) &&
            !string.IsNullOrWhiteSpace(SubjectCode) &&
            Credits > 0 &&
            GPACredits > 0;

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

        // =========================================================== Validation Logic

        public string? this[string columnName]
        {
            get
            {
                string? error = null;
                switch (columnName)
                {
                    case nameof(SubjectName):
                        if (string.IsNullOrWhiteSpace(SubjectName))
                            error = "Subject Name cannot be empty.";
                        break;
                    case nameof(SubjectCode):
                        if (string.IsNullOrWhiteSpace(SubjectCode))
                            error = "Subject Code cannot be empty.";
                        break;
                    case nameof(Credits):
                        if (Credits <= 0)
                            error = "Credits must be greater than zero.";
                        break;
                    case nameof(GPACredits):
                        if (GPACredits <= 0)
                            error = "GPA Credits must be greater than zero.";
                        break;
                }
                return error;
            }
        }

        public string? Error => null;
    }
}