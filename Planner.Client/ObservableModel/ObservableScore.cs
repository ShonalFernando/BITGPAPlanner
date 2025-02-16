using Planner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public bool     Neglect     { get; set; }

        public Grade    GradeObtained   { get; set; }
        public string   GradeDisplayed  { get; set; } = null!;
        public int      Credits         { get; set; }

        public decimal  Weight          { get; set; }
    }

    [Serializable]
    public class ScoresFile
    {
        public DateTime DateSaved { get; set; }
        public DateTime DateModified { get; set; }
        public ObservableCollection<ObservableScore> Scores { get; set; } = new ObservableCollection<ObservableScore>();
    }
}
