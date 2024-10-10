using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.Model
{
    public class Score
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public bool IsRepeat { get; set; }
        public bool IsEnhancement { get; set; }

        public Grade GradeObtained { get; set; }

        // Apparent GPV, based on the grade obtained
        public decimal ApparentGPV
        {
            get
            {
                return (int)GradeObtained;
            }
        }

        // Absolute GPV: If repeat, it is capped at C; otherwise, it's the full GPV.
        public decimal AbsoluteGPV
        {
            get
            {
                // If repeat, cap the GPV at C (40 marks); otherwise, use full GPV
                if (IsRepeat)
                {
                    return Math.Min(ApparentGPV, (int)Grade.C);
                }
                return ApparentGPV;
            }
        }

        // Subject Score Point based on the grade and flags for repeat/enhancement
        public decimal SubjectScorePoint
        {
            get
            {
                // If it is an enhancement subject, set the SubjectScorePoint to 0
                if (IsEnhancement)
                {
                    return 0;
                }
                // Otherwise, calculate the score point using the formula
                return AbsoluteGPV * ((int)GradeObtained / 10m);
            }
        }
    }

    public enum Grade
    {
        APlus = 85,
        A = 70,
        AMinus = 65,

        BPlus = 60,
        B = 55,
        BMinus = 50,

        CPlus = 45,
        C = 40,
        CMinus = 35,

        DPlus = 30,
        D = 25,

        E = 0,

        // This point Onwards Logic Will Identify and Override Default Mapping Logic

        AB = -1,

        P = 1,
        F = -2
    }
}
