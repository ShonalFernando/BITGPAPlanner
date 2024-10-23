﻿using Planner.Client.Command;
using Planner.Client.Helper;
using Planner.Client.ObservableModel;
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
    class GPACalculator :ViewModelBase
    {
        // Private Fields
        private ObservableCollection<ObservableScore> displayedScores = new();
        private ObservableCollection<Subject> _subjects;

        private Subject? selectedSubject;
        private Grade selectedSubjectGrade;

        private int levelFilter;
        private bool isAllLevels;


        private decimal totalGPA;

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

            // Mock data load on initialization
            LoadSubjectsFromDatabase();
        }

        // Load subjects from database (mock implementation)
        private void LoadSubjectsFromDatabase()
        {
            _subjects = new ObservableCollection<Subject>(Subject.GetAllSubjects(AppSession.ConnectionString));
            // Convert List to ObservableCollection
        }

        // Properties
        public ObservableCollection<ObservableScore> DisplayedScores => displayedScores;
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

        // Methods

        // Add a new score
        private void AddScore(object? parameter)
        {
            if (SelectedSubject != null)
            {
                DisplayedScores.Add(new ObservableScore
                {
                    Code = SelectedSubject.SubjectCode,
                    Subject = SelectedSubject.SubjectName,
                    GradeObtained = SelectedSubjectGrade
                });
            }
        }

        // Calculate GPA
        private void CalculateGPA(object? parameter)
        {
            //var totalCredits = DisplayedScores.Sum(s => s.GradeObtained.GetCredits());
            //var totalWeightedGrade = DisplayedScores.Sum(s => s.GradeObtained.GetCredits() * s.GradeObtained.GetGradePoint());

            //TotalGPA = totalCredits == 0 ? 0 : totalWeightedGrade / totalCredits;
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
            // TEST 0002
            TestUtlity.ExecuteTestCode(() => MessageBox.Show(SelectedSubject.SubjectName));
            LevelFilter = 0;
            IsAllLevels = true;
        }

        // Reset the list of displayed scores
        private void ResetDisplayedScores(object? parameter)
        {
            DisplayedScores.Clear();
            TotalGPA = 0;
        }
    }
}
