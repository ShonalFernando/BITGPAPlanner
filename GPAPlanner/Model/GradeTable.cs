using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Model
{
    public class GradeTable
    {
        public int GradeID { get; set; }

        public string GradeIndicator { get; set; } = null!; //Eg: A+, A-, etc

        public int Low_Mark { get; set; }
        public int High_Mark { get; set; }
        public double GPV { get; set; }
    }
}
