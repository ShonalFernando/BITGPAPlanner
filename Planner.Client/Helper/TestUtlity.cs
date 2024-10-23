using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnitTester.Session;

namespace Planner.Client.Helper
{
    public class TestUtlity
    {
        public static void ExecuteTestCode(Action testCode)
        {
            if (AppSession.IsTest)
            {
                testCode.Invoke();
            }
        }

        public static void ExecuteProductionCode(Action testCode)
        {
            if (!AppSession.IsTest)
            {
                testCode.Invoke();
            }
        }
    }
}