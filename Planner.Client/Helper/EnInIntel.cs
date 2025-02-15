using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planner.Client.Helper
{
    internal class EnInIntel
    {
        public static bool DetectEnhancement(string subjectName)
        {
            if ($"{subjectName[0]}{subjectName[1]}" == "EN")
                return true;
            return false;
        }
    }
}
