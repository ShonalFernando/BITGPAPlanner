using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.Session;

namespace Planner.Model
{
    public class Score
    {
        public int  Id              { get; set; }

        public int  SubjectId       { get; set; }

        public bool IsRepeat        { get; set; }
        public bool IsEnhancement   { get; set; }

        public Grade GradeObtained  { get; set; }

        // Apparent GPV, based on the grade obtained
        public decimal ApparentGPV
        {
            get
            {
                return (int)GradeObtained/10;
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
                    return Math.Min(ApparentGPV, (int)Grade.C)/10;
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

                // Get the Subject Data
                Subject? _subject =  Subject.GetSubjectById(AppSession.ConnectionString, SubjectId);

                // Check Subject is Available
                if(_subject != null)
                {
                    return AbsoluteGPV * _subject.Credits;
                }

                // If Not Return 0

                return 0;
            }
        }
    }

    public enum Grade
    {
        [Description("A+ (4.00)")] APlus,
        [Description("A (4.00)")] A,
        [Description("A- (3.70)")] AMinus,

        [Description("B+ (3.30)")] BPlus,
        [Description("B (3.00)")] B,
        [Description("B- (2.70)")] BMinus,

        [Description("C+ (2.30)")] CPlus,
        [Description("C (2.00)")] C,
        [Description("C- (1.70)")] CMinus,

        [Description("D+ (1.30)")] DPlus,
        [Description("D (1.00)")] D,

        [Description("E (0.00)")] E,

        // This point Onwards Logic Will Identify and Override Default Mapping Logic

        [Description("Absent (0.00)")] AB,

        [Description("Pass")] P,
        [Description("Fail")] F
    }
}
