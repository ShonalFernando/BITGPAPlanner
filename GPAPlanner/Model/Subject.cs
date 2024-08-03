using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Model
{
    public class Subject
    { 
        public int SubjectID { get; set; } //PK
        public int Semester { get; set; }

        public string Name { get; set; } = null!;
        public Syllabus Syllabus { get; set; }

        public SubjectModifier SubjectModifier { get; set; }
        public int Code { get; set; }

        public int Credit { get; set; }
        public int GPACredit { get; set; } //0 For Non GPA Subjects
    }

    public enum Syllabus
    {
        Old,
        New,
        Mapping_For_New
    }

    public enum SubjectModifier
    {
        IT,
        EN
    }
}
