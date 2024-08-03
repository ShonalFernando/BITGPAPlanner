using GPAPlanner.Model.NonRelational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Model.DAO
{
    public static class AppStaticData
    {
        public static List<GradeTable> GradeDefinitions = new List<GradeTable>();
        public static List<Subject> SubjectDefinitions = new List<Subject>();

        public static Semester semester_1_Old = new Semester() { SemesterID = 1, isOldSyllabus = true };
        public static Semester semester_1_New = new Semester() { SemesterID = 1, isOldSyllabus = false };
        public static Semester semester_2_Old = new Semester() { SemesterID = 2, isOldSyllabus = true };
        public static Semester semester_2_New = new Semester() { SemesterID = 2, isOldSyllabus = false };
        public static Semester semester_3_Old = new Semester() { SemesterID = 3, isOldSyllabus = true };
        public static Semester semester_3_New = new Semester() { SemesterID = 3, isOldSyllabus = false };
        public static Semester semester_4_Old = new Semester() { SemesterID = 4, isOldSyllabus = true };
        public static Semester semester_4_New = new Semester() { SemesterID = 4, isOldSyllabus = false };
        public static Semester semester_5_Old = new Semester() { SemesterID = 5, isOldSyllabus = true };
        public static Semester semester_5_New = new Semester() { SemesterID = 5, isOldSyllabus = false };
        public static Semester semester_6_Old = new Semester() { SemesterID = 6, isOldSyllabus = true };
        public static Semester semester_6_New = new Semester() { SemesterID = 6, isOldSyllabus = false };

        public static List<Semester> Semesters = new List<Semester>
        {
            semester_1_Old,
            semester_1_New,
            semester_2_Old,
            semester_2_New,
            semester_3_Old,
            semester_3_New,
            semester_4_Old,
            semester_4_New,
            semester_5_Old,
            semester_5_New,
            semester_6_Old,
            semester_6_New
        };
    }
}
