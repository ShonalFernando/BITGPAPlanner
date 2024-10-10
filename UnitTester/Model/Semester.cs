using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.Model
{
    public class Semester
    {
        // =========================================================== Properties and Fields

        public int SemesterID { get; set; }               // Primary Key for Indexing, This does not Reflect Semester Number

        public int Level { get; set; }                    // The level the Semester Belongs to
        public int SemesterCode { get; set; }                    // The Real Semester Number
        
        
        public string? SemesterDescription { get; set; }
        public int CalenderYear { get; set; }   // The calender year the semester was faced, 0000 to default

        public Dictionary<int, Grade> SubjectScores { get; set; } = new Dictionary<int, Grade>(); // Subject ID and GPV Obtained
    }
}
