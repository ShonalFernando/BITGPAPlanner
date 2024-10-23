using Planner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.Session;

namespace Planner.Client.Services
{
    public class DataInitializors
    {
        public static void InitializeDatabase()
        {
            Subject.CreateTable(AppSession.ConnectionString);
        }
    }
}
