using GPAPlanner.Commands;
using GPAPlanner.Model;
using GPAPlanner.Model.DAO;
using GPAPlanner.Model.NonRelational;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GPAPlanner.ViewModel
{
    public class GPAProcessor : VMBase
    {
        private int _semester;
        private bool _isOldSyllabus;
        private ObservableCollection<ObservableGrade> _grades;
        private ObservableCollection<GradeTable> _gradeDef;

        private ObservableCollection<string> _gradeList;

        public ObservableCollection<string> GradeList
        {
            get => _gradeList;
            set
            {
                _gradeList = value;
                OnPropertyChanged(nameof(GradeList));
            }
        }

        public int Semester
        {
            get => _semester;
            set => SetProperty(ref _semester, value);
        }

        public bool IsOldSyllabus
        {
            get => _isOldSyllabus;
            set => SetProperty(ref _isOldSyllabus, value);
        }

        public ObservableCollection<ObservableGrade> Grades
        {
            get => _grades;
            set => SetProperty(ref _grades, value);
        }

        public ObservableCollection<GradeTable> GradeDefinition
        {
            get => _gradeDef;
            set => SetProperty(ref _gradeDef, value);
        }

        public ICommand AddGradeCommand { get; }
        public ICommand RemoveGradeCommand { get; }
        public ICommand ChangeSemesterCommand { get; }
        public ICommand CalculateCommand { get; }

        public GPAProcessor()
        {
            Grades = new ObservableCollection<ObservableGrade>();
            GradeDefinition = new ObservableCollection<GradeTable>(AppStaticData.GradeDefinitions);

            GradeList = new ObservableCollection<string>();
            foreach (var gradeDef in AppStaticData.GradeDefinitions)
            {
                GradeList.Add(gradeDef.GradeIndicator);
            }

            AddGradeCommand = new RelayCommand(param => AddGrade((ObservableGrade)param!));
            RemoveGradeCommand = new RelayCommand(param => RemoveGrade((ObservableGrade)param!));
            ChangeSemesterCommand = new RelayCommand(param => ChangeSemester());
            CalculateCommand = new RelayCommand(param => CalculateGPA());
        }

        private void CalculateGPA()
        {
            string maps = "";

            foreach (var grade in Grades)
            {
                foreach (var gdef in AppStaticData.GradeDefinitions)
                {
                    maps += gdef.GradeIndicator + " : " + grade.GPVGrade;

                    if (gdef.GradeIndicator == grade.GPVGrade)
                    {
                        grade.GPV = gdef.GPV;
                    }
                }
            }

            MessageBox.Show(maps);
            double TotalGPACredits = 0;
            double TotalCredits = 0;

            foreach (var grade in Grades)
            {

               TotalGPACredits += grade.GPACredit * grade.GPV;
            }

            MessageBox.Show((TotalGPACredits / 30).ToString());

        }

        private void ChangeSemester()
        {
            Grades.Clear();

            if (_isOldSyllabus)
            {
                foreach (var sub in AppStaticData.SubjectDefinitions)
                {
                    if (sub.Semester == _semester)
                    {
                        if (sub.Syllabus == Syllabus.Old || sub.Syllabus == Syllabus.Mapping_For_New)
                        {
                            ObservableGrade grade = new() { SubjectName = sub.Name, GPACredit = sub.GPACredit};
                            Grades.Add(grade);
                        }
                    }
                }
            }
            else
            {
                foreach (var sub in AppStaticData.SubjectDefinitions)
                {
                    if (sub.Semester == _semester)
                    {
                        if (sub.Syllabus == Syllabus.New)
                        {
                            ObservableGrade grade = new() { SubjectName = sub.Name, GPACredit = sub.GPACredit };
                            Grades.Add(grade);
                        }
                    }
                }
            }
        }

        private void AddGrade(ObservableGrade grade)
        {
            Grades.Add(grade);
        }

        private void RemoveGrade(ObservableGrade grade)
        {
            Grades.Remove(grade);
        }
    }
}
