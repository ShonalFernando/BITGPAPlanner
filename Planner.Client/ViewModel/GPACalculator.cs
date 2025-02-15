using Planner.Client.Command;
using Planner.Client.Definitions;
using Planner.Client.Helper;
using Planner.Client.ObservableModel;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Converters;
using UnitTester.Session;
using static System.Formats.Asn1.AsnWriter;

namespace Planner.Client.ViewModel
{
    /// <summary>
    /// GPACalculator class responsible for managing GPA calculations, subject selection, filtering,
    /// and maintaining a list of scores with relevant properties and commands.
    /// </summary>
    internal class GPACalculator : ViewModelBase
    {
        // Private Fields
        private ObservableCollection<ObservableScore> _displayedScores = new();
        private ObservableCollection<Subject> _subjects;

        private Subject? _selectedSubject;
        private Grade _selectedSubjectGrade;
        private decimal _totalGPA;
        private int _index;
        private int _levelFilter;
        private bool _isAllLevels;
        private bool _isRepeat;
        private bool _isEnhancement;
        private bool _isNeglect;
        private int _filterYear;
        private bool _isAllYears;
        private ObservableScore _selectedDisplayedSubject;

        // Commands
        public ICommand AddCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand ResetFiltersCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand ClearCommand { get; }

        /// <summary>
        /// Constructor initializes commands and subjects list.
        /// </summary>
        public GPACalculator()
        {
            AddCommand = new RelayCommand(AddScore);
            CalculateCommand = new RelayCommand(CalculateGPA, CanCalculateGPA);
            ResetFiltersCommand = new RelayCommand(ResetFilters);
            SaveCommand = new RelayCommand(SaveScores, CanSaveScores);
            RemoveCommand = new RelayCommand(RemoveSelectedScore, CanRemoveScore);
            ResetCommand = new RelayCommand(ResetDisplayedScores);

            _index = 0;
            _subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString));
        }

        // Properties
        public ObservableCollection<ObservableScore> DisplayedScores
        {
            get => _displayedScores;
            set { _displayedScores = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Grade> Grades { get; set; } = new ObservableCollection<Grade>(Enum.GetValues(typeof(Grade)).Cast<Grade>());

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set { _subjects = value; OnPropertyChanged(); }
        }

        public Subject? SelectedSubject
        {
            get => _selectedSubject;
            set { _selectedSubject = value; OnPropertyChanged(); }
        }

        public ObservableScore SelectedDisplayedSubject
        {
            get => _selectedDisplayedSubject;
            set
            {
                _selectedDisplayedSubject = value; OnPropertyChanged();
            }
        }


        public Grade SelectedSubjectGrade
        {
            get => _selectedSubjectGrade;
            set { _selectedSubjectGrade = value; OnPropertyChanged(); }
        }

        public int LevelFilter
        {
            get => _levelFilter;
            set { _levelFilter = value; OnPropertyChanged(); }
        }

        public bool IsAllLevels
        {
            get => _isAllLevels;
            set { _isAllLevels = value; OnPropertyChanged(); }
        }

        public decimal TotalGPA
        {
            get => _totalGPA;
            private set { _totalGPA = value; OnPropertyChanged(); }
        }

        public bool IsRepeat
        {
            get => _isRepeat;
            set { _isRepeat = value; OnPropertyChanged(); }
        }

        public bool IsEnhancement
        {
            get => _isEnhancement;
            set { _isEnhancement = value; OnPropertyChanged(); }
        }

        public int FilterYear
        {
            get => _filterYear;
            set { _filterYear = value; OnPropertyChanged(); }
        }

        public bool IsAllYears
        {
            get => _isAllYears;
            set { _isAllYears = value; OnPropertyChanged(); }
        }

        public bool IsNeglect
        {
            get => _isNeglect;
            set { _isNeglect = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Adds a new score to the displayed scores list with appropriate logic for repeat subjects.
        /// </summary>
        private void AddScore(object? parameter)
        {
            _index++;

            if (SelectedSubject != null)
            {
                decimal weight = ScoreDefinitions.GetGPV(SelectedSubjectGrade) * SelectedSubject.Credits;
                if (IsRepeat && weight > 2.00m * SelectedSubject.Credits)
                    weight = 2.00m * SelectedSubject.Credits;

                DisplayedScores.Add(new ObservableScore
                {
                    Code = SelectedSubject.SubjectCode,
                    Subject = SelectedSubject.SubjectName,
                    GradeObtained = SelectedSubjectGrade,
                    GradeDisplayed = ScoreDefinitions.GetGPVName(SelectedSubjectGrade),
                    Repeat = IsRepeat,
                    Neglect = IsNeglect,
                    Enhancement = IsEnhancement,
                    Credits = SelectedSubject.Credits,
                    Weight = weight,
                    Index = _index
                });
            }
            else
            {
                MessageBox.Show("Select a Subject First", "BIT GPA Planner", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        /// <summary>
        /// Calculates GPA based on displayed scores.
        /// </summary>
        private void CalculateGPA(object? parameter)
        {
            int applicableSubjects = 0;
            TotalGPA = 0;

            foreach (var score in DisplayedScores)
            {
                if (!score.Enhancement && !score.Neglect)
                    TotalGPA += score.Weight;
                    applicableSubjects++;
            }

            if (applicableSubjects > 0)
                TotalGPA /= applicableSubjects;
            else
                MessageBox.Show("Non-Applicable Subject Count is 0", "BIT GPA Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool CanCalculateGPA(object? parameter) => DisplayedScores.Count > 0;

        /// <summary>
        /// Removes the selected score from the displayed list.
        /// </summary>
        private void RemoveSelectedScore(object? parameter)
        {
            DisplayedScores.Remove(SelectedDisplayedSubject);
        }

        private bool CanRemoveScore(object? parameter)
        {
            if (DisplayedScores.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Saves scores to a database or file.
        /// </summary>
        private void SaveScores(object? parameter)
        {
            // Placeholder: Save operation (e.g., to database or file)
            // ScoreRepository.SaveScores(DisplayedScores);
        }

        private bool CanSaveScores(object? parameter) => DisplayedScores.Count > 0;

        /// <summary>
        /// Resets the subject filters and updates the subjects list accordingly.
        /// </summary>
        private void ResetFilters(object? parameter)
        {
            Subjects = IsAllYears ?
                new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString)) :
                new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString)
                    .FindAll(sub => sub.Level.Equals(FilterYear)));

            if (Subjects.Count == 0)
            {
                MessageBox.Show("No Subjects found for the selected year", "GPA Calculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                Subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString));
                IsAllYears = true;
                FilterYear = 1;
            }
        }

        /// <summary>
        /// Clears the displayed scores and resets the GPA.
        /// </summary>
        private void ResetDisplayedScores(object? parameter)
        {
            DisplayedScores.Clear();
            TotalGPA = 0;
        }

        /// <summary>
        /// Triggers a check for the Enhancement Subjects
        /// </summary>
        public void SubjectCheckTrigger()
        {
            if(SelectedSubject != null)
                IsEnhancement = EnInIntel.DetectEnhancement(SelectedSubject.SubjectCode);
        }
    }
}
