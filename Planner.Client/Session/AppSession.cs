using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.Session
{
    public static class AppSession
    {
        public static readonly string ConnectionString = "Data Source=subjects.db;Version=3;";
        public static readonly bool IsTest = true;
        public static readonly bool IsAppFirstRun = false;
    }
}
