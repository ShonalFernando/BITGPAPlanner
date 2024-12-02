using Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.Session;

namespace Planner.Client.Helper
{
    internal static class VisualizeHelper
    {

        internal static List<string> GetCombinedSubjectAndCode()
        {
            List<Subject> AllSubjects = Subject.GetAllSubjects(AppSession.ConnectionString);
            List<string> VisualizeSubjects = new List<string>();

            foreach (var subject in AllSubjects)
            {
                VisualizeSubjects.Add(subject.SubjectCode + " :: " + subject.SubjectName);
            }

            return VisualizeSubjects;
        }

        internal static List<string> GetSubjectCodes()
        {
            List<Subject> allSubjects = Subject.GetAllSubjects(AppSession.ConnectionString);
            List<string> subjectCodes = new List<string>();

            foreach (var subject in allSubjects)
            {
                subjectCodes.Add(subject.SubjectCode);
            }

            return subjectCodes;
        }
    }
}
