using GPAPlanner.Model.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Model.NonRelational
{
    public class Semester
    {
        //SemesterID and isOldSyllabus both needed to uniquely identify
        public int SemesterID { get; set; }
        public bool isOldSyllabus { get; set; } //Before 2019? Then OldSyllabus

        public List<Subject>? Subjects { get; set; }

        public static void InitializeSortSubjectsToSemersters(Semester semester)
        {
            if (semester.Subjects == null)
            {
                semester.Subjects = new();
            }

            foreach (var subject in AppStaticData.SubjectDefinitions)
            {
                if (semester.SemesterID == subject.Semester)
                {

                    if (subject.Syllabus == Syllabus.Old || subject.Syllabus == Syllabus.Mapping_For_New)
                    {
                        if (semester.isOldSyllabus)
                        {
                            semester.Subjects.Add(subject);
                        }
                    }
                    else
                    {
                        if (!semester.isOldSyllabus)
                        {
                            semester.Subjects.Add(subject);
                        }
                    }
                }
            }

        }
    }
}
