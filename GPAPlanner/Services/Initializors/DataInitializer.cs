using GPAPlanner.Model;
using GPAPlanner.Model.DAO;
using GPAPlanner.Model.NonRelational;
using GPAPlanner.Services.DataStreams;
using GPAPlanner.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GPAPlanner.Services.Initializors
{
    public class DataInitializer
    {
        public AppSession? _appSession;

        public DataInitializer(AppSession appSession)
        {
            _appSession = appSession;
        }


        public static void CreateSemesters()
        {
            foreach (var sem in AppStaticData.Semesters)
            {
                Semester.InitializeSortSubjectsToSemersters(sem);
            }
        }

        public void LoadSubjects()
        {
            if (_appSession != null)
            {
                if (_appSession._subjectDataStream != null)
                {
                    AppStaticData.SubjectDefinitions = _appSession._subjectDataStream.GetSubjects();
                }
            }
        }

        public void LoadGradesTable()
        {
            if (_appSession != null)
            {
                if (_appSession._gradeTableDataStream != null)
                {
                    AppStaticData.GradeDefinitions = _appSession._gradeTableDataStream.GetGrades();
                    MessageBox.Show("OK" + AppStaticData.GradeDefinitions[0].GradeIndicator);
                }
            }
        }

        public void CreateGrades()
        {
            if (_appSession != null)
            {
                if (_appSession._gradeTableDataStream != null)
                {
                    _appSession._gradeTableDataStream.CreateTable();

                    List<GradeTable> grades = new List<GradeTable>
                    {
                        new GradeTable { GradeIndicator = "A+", Low_Mark = 85, High_Mark = 100, GPV = 4.00 },
                        new GradeTable { GradeIndicator = "A", Low_Mark = 70, High_Mark = 84, GPV = 4.00 },
                        new GradeTable { GradeIndicator = "A-", Low_Mark = 65, High_Mark = 69, GPV = 3.70 },
                        new GradeTable { GradeIndicator = "B+", Low_Mark = 60, High_Mark = 64, GPV = 3.30 },
                        new GradeTable { GradeIndicator = "B", Low_Mark = 55, High_Mark = 59, GPV = 3.00 },
                        new GradeTable { GradeIndicator = "B-", Low_Mark = 50, High_Mark = 54, GPV = 2.70 },
                        new GradeTable { GradeIndicator = "C+", Low_Mark = 45, High_Mark = 49, GPV = 2.30 },
                        new GradeTable { GradeIndicator = "C", Low_Mark = 40, High_Mark = 44, GPV = 2.00 },
                        new GradeTable { GradeIndicator = "C-", Low_Mark = 35, High_Mark = 39, GPV = 1.70 },
                        new GradeTable { GradeIndicator = "D+", Low_Mark = 30, High_Mark = 34, GPV = 1.30 },
                        new GradeTable { GradeIndicator = "D", Low_Mark = 25, High_Mark = 29, GPV = 1.00 },
                        new GradeTable { GradeIndicator = "E", Low_Mark = 0, High_Mark = 24, GPV = 0.00 }
                    };

                    foreach (var grade in grades)
                    {
                        _appSession._gradeTableDataStream.InsertGrade(grade);
                    }
                }
            }
        }
        public void CreateSubjects()
        {
            var subjects = new List<Subject> { };

            if (_appSession != null)
            {
                if (_appSession._subjectDataStream != null)
                {
                    _appSession._subjectDataStream.CreateTable();

                    foreach (var subject in subjects)
                    {
                        _appSession._subjectDataStream.InsertSubject(subject);
                    }
                }
            }
        }
    }
}
