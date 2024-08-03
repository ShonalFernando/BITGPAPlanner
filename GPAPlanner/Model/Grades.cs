using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GPAPlanner.Model
{
    public class Grades
    {
        public int GradeID { get; set; }

        public int Year { get; set; }
        public int Semester { get; set; }

        public int Attempt { get; set; }
        public bool IsRepeat { get; set; }

        public int SubjectID { get; set; }
        public int Grade { get; set; }
    }
}
