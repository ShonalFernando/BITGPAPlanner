using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Model;
using UnitTester.Services;
using UnitTester.Session;

namespace UnitTester.View.ViewPainter
{
    public class SubjectsViewer
    {
        public SubjectsViewer()
        {
            Subject.CreateTable(AppSession.ConnectionString);
        }

        public void ViewSubjectsMenu()
        {
            SubjectManager manager = new SubjectManager();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("==== Subject Management System ====");
                Console.WriteLine("1. Add Subject");
                Console.WriteLine("2. View All Subjects");
                Console.WriteLine("3. Edit Subject");
                Console.WriteLine("4. Delete Subject");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        manager.AddSubject();
                        break;
                    case "2":
                        manager.ReadSubjects();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        manager.EditSubject();
                        break;
                    case "4":
                        manager.DeleteSubject();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
