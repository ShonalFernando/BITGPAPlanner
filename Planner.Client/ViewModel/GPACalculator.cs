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
using UnitTester.Session;
using static System.Formats.Asn1.AsnWriter;

namespace Planner.Client.ViewModel
{
    class GPACalculator :ViewModelBase
    {
        // Private Fields
        private ObservableCollection<ObservableScore> displayedScores = new();
        private ObservableCollection<Subject> _subjects;

        private Subject? selectedSubject;
        private Grade selectedSubjectGrade;

        private int levelFilter;
        private bool isAllLevels;

        private bool isRepeat;
        private bool isEnhancement;

        private decimal totalGPA;

        private int index;

        // Filters
        private int filterYear;
        private bool isAllYears;

        // Commands
        public ICommand AddCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand ResetFiltersCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand ResetCommand { get; }


        // Constructor
        public GPACalculator()
        {
            AddCommand = new RelayCommand(AddScore);
            CalculateCommand = new RelayCommand(CalculateGPA, CanCalculateGPA);
            ResetFiltersCommand = new RelayCommand(ResetFilters);
            SaveCommand = new RelayCommand(SaveScores, CanSaveScores);
            RemoveCommand = new RelayCommand(RemoveSelectedScore, CanRemoveScore);
            ResetCommand = new RelayCommand(ResetDisplayedScores);

            index = 0;

            _subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString));
        }


        // Properties
        public ObservableCollection<ObservableScore> DisplayedScores
        {
            get => displayedScores;
            set
            {
                displayedScores = value;
                OnPropertyChanged();
            }
        }

        public Array Grades => Enum.GetValues(typeof(Grade));

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
            get => selectedSubject;
            set
            {
                selectedSubject = value;
                OnPropertyChanged();
            }
        }

        public Grade SelectedSubjectGrade
        {
            get => selectedSubjectGrade;
            set
            {
                selectedSubjectGrade = value;
                OnPropertyChanged();
            }
        }

        public int LevelFilter
        {
            get => levelFilter;
            set
            {
                levelFilter = value;
                OnPropertyChanged();
            }
        }

        public bool IsAllLevels
        {
            get => isAllLevels;
            set
            {
                isAllLevels = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalGPA
        {
            get => totalGPA;
            private set
            {
                totalGPA = value;
                OnPropertyChanged();
            }
        }

        public bool IsRepeat
        {
            get => isRepeat;
            set
            {
                isRepeat = value;
                OnPropertyChanged();
            }
        }        
        
        public bool IsEnhancement
        {
            get => isEnhancement;
            set
            {
                isEnhancement = value;
                OnPropertyChanged();
            }
        }        
        
        public int FilterYear
        {
            get => filterYear;
            set
            {
                filterYear = value;
                OnPropertyChanged();
            }
        }        
        
        public bool IsAllYears
        {
            get => isAllYears;
            set
            {
                isAllYears = value;
                OnPropertyChanged();
            }
        }
        // Methods

        // Add a new score
        private void AddScore(object? parameter)
        {
            index++;

            if (SelectedSubject != null)
            {
                if(isRepeat)
                {
                    if (ScoreDefinitions.GetGPV(SelectedSubjectGrade) > 2.00m)
                    {
                        DisplayedScores.Add(new ObservableScore
                        {
                            Code = SelectedSubject.SubjectCode,
                            Subject = SelectedSubject.SubjectName,
                            GradeObtained = SelectedSubjectGrade,
                            GradeDisplayed = ScoreDefinitions.GetGPVName(SelectedSubjectGrade),
                            Repeat = IsRepeat,
                            Enhancement = IsEnhancement,
                            Credits = SelectedSubject.Credits,
                            Weight = 2 * SelectedSubject.Credits,
                            Index = index
                        });
                    }
                    else
                    {
                        DisplayedScores.Add(new ObservableScore
                        {
                            Code = SelectedSubject.SubjectCode,
                            Subject = SelectedSubject.SubjectName,
                            GradeObtained = SelectedSubjectGrade,
                            GradeDisplayed = ScoreDefinitions.GetGPVName(SelectedSubjectGrade),
                            Repeat = IsRepeat,
                            Enhancement = IsEnhancement,
                            Credits = SelectedSubject.Credits,
                            Weight = ScoreDefinitions.GetGPV(SelectedSubjectGrade) * SelectedSubject.Credits,
                            Index = index
                        });
                    }
                }
                else
                {
                    DisplayedScores.Add(new ObservableScore
                    {
                        Code = SelectedSubject.SubjectCode,
                        Subject = SelectedSubject.SubjectName,
                        GradeObtained = SelectedSubjectGrade,
                        GradeDisplayed = ScoreDefinitions.GetGPVName(SelectedSubjectGrade),
                        Repeat = IsRepeat,
                        Enhancement = IsEnhancement,
                        Credits = SelectedSubject.Credits,
                        Weight = ScoreDefinitions.GetGPV(SelectedSubjectGrade) * SelectedSubject.Credits,
                        Index = index
                    });
                }

            }
        }

        // Calculate GPA
        private void CalculateGPA(object? parameter)
        {
            int NonenhancementCount = 0;
            TotalGPA = 0;

            foreach (var score in DisplayedScores)
            {
                if(!score.Enhancement)
                {
                    TotalGPA += score.Weight;
                    NonenhancementCount++;
                }
                
            }

            TotalGPA = TotalGPA / NonenhancementCount;
        }

        // Validator for Calculate
        private bool CanCalculateGPA(object? parameter) => DisplayedScores.Count > 0;

        // Remove selected score
        private void RemoveSelectedScore(object? parameter)
        {
            if (parameter is ObservableScore score && DisplayedScores.Contains(score))
            {
                DisplayedScores.Remove(score);
            }
        }

        private bool CanRemoveScore(object? parameter) => parameter is ObservableScore score && DisplayedScores.Contains(score);

        // Save scores to database or file (example implementation)
        private void SaveScores(object? parameter)
        {
            // Perform save operation (e.g., to database or file)
            // Placeholder: Assume a service call to save data.
            //ScoreRepository.SaveScores(DisplayedScores);
        }

        private bool CanSaveScores(object? parameter) => DisplayedScores.Count > 0;

        // Reset filters
        private void ResetFilters(object? parameter)
        { 
            if(IsAllYears)
            {
                Subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString));
            }
            else
            {
                Subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString).FindAll(sub => sub.Level.Equals(FilterYear)));
                
                if(Subjects == null || Subjects.Count == 0)
                {
                    MessageBox.Show("No Subjects found for the selected year", "GPA Calculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString));
                    IsAllYears = true;
                    FilterYear = 1;
                }
            }
            
        }

        // Reset the list of displayed scores
        private void ResetDisplayedScores(object? parameter)
        {
            DisplayedScores.Clear();
            TotalGPA = 0;
        }
    }
}
