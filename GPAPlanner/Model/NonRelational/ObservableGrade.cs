using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Model.NonRelational
{
    public class ObservableGrade
    {
        public string SubjectName { get; set; } = null!;
        public double GPACredit { get; set; }

        public string GPVGrade { get; set; } = null!;
        public double GPV { get;set; }
    }
}
