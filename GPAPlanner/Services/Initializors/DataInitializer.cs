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
            foreach(var sem in AppStaticData.Semesters)
            {
                Semester.InitializeSortSubjectsToSemersters(sem);
            }
        }

        public static void TestData()
        {
            if (AppStaticData.Semesters[3].Subjects != null)
            {
                MessageBox.Show(AppStaticData.Semesters[3].Subjects.Count.ToString()); 
            }
            else
            {
                MessageBox.Show("NULL");
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

        public void InitializeSubject()
        {
            var subjects = new List<Subject>{
        };
            if(_appSession != null)
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
