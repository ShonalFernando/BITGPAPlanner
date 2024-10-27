using Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.Definitions
{
    public static class ScoreDefinitions
    {
        // Get GPV for the given grade
        public static decimal GetGPV (Grade grade) => grade switch
        {
            Grade.APlus => 4.00m,
            Grade.A => 4.00m,
            Grade.AMinus => 3.70m,
            Grade.BPlus => 3.30m,
            Grade.B => 3.00m,
            Grade.BMinus => 2.70m,
            Grade.CPlus => 2.30m,
            Grade.C => 2.00m,
            Grade.CMinus => 1.70m,
            Grade.DPlus => 1.30m,
            Grade.D => 1.00m,
            Grade.E => 0.00m,
            _ => throw new ArgumentOutOfRangeException(nameof(grade), grade, "Invalid grade value")
        };

        // Get GPV Name for the given grade
        public static string GetGPVName(Grade grade) => grade switch
        {
            Grade.APlus => "A+",
            Grade.A => "A",
            Grade.AMinus => "A-",
            Grade.BPlus => "B+",
            Grade.B => "B",
            Grade.BMinus => "B-",
            Grade.CPlus => "C+",
            Grade.C => "C",
            Grade.CMinus => "C-",
            Grade.DPlus => "D+",
            Grade.D => "D",
            Grade.E => "E",
            _ => throw new ArgumentOutOfRangeException(nameof(grade), grade, "Invalid grade value")
        };
    }
}
