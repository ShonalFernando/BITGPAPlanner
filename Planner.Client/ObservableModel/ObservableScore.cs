using Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.ObservableModel
{
    public class ObservableScore
    {
        public int      Index           { get; set; }

        public string   Code            { get; set; } = null!;
        public string   Subject         { get; set; } = null!;

        public bool     Repeat          { get; set; }
        public bool     Enhancement     { get; set; }

        public Grade    GradeObtained   { get; set; }
    }
}
