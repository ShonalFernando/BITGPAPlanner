using GPAPlanner.Services.DataStreams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Session
{
    public class AppSession
    {
        private static string DatabaseString = "GPAPlannerData.db";

        public GradesDataStream? _gradesDataStream { get; set; }
        public GradeTableDataStream? _gradeTableDataStream { get; set; }
        public SubjectDataStream? _subjectDataStream { get; set; }

        public void InitializeSession()
        {
            _gradesDataStream = new GradesDataStream(DatabaseString);
            _gradeTableDataStream = new GradeTableDataStream(DatabaseString);
            _subjectDataStream = new SubjectDataStream(DatabaseString);

        }
    }
}
