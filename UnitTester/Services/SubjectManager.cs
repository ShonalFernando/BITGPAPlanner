using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Model;

namespace UnitTester.Services
{
    public class SubjectManager
    {
        private List<Subject> subjects = new List<Subject>();

        // Method to Add a Subject
        public void AddSubject()
        {
            Console.WriteLine("Add New Subject");

            var newSubject = new Subject();

            Console.Write("Enter Subject ID: ");
            newSubject.SubjectId = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Name: ");
            newSubject.SubjectName = Console.ReadLine();

            Console.Write("Enter Subject Code: ");
            newSubject.SubjectCode = Console.ReadLine();

            Console.Write("Enter Level: ");
            newSubject.Level = int.Parse(Console.ReadLine());

            Console.Write("Enter Credits: ");
            newSubject.Credits = int.Parse(Console.ReadLine());

            Console.Write("Enter GPA Credits: ");
            newSubject.GPACredits = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Type (0 for Core, 1 for Optional): ");
            newSubject.SubjectType = (SubjectType)int.Parse(Console.ReadLine());

            Console.Write("Enter Description (optional): ");
            newSubject.Description = Console.ReadLine();

            subjects.Add(newSubject);
            Console.WriteLine("Subject added successfully!");
        }

        // Method to Display Subjects in a Table
        public void ReadSubjects()
        {
            if (subjects.Count == 0)
            {
                Console.WriteLine("No subjects available.");
                return;
            }

            Console.WriteLine("List of Subjects:");
            Console.WriteLine("ID\tName\t\tCode\t\tLevel\tCredits\tGPA Credits\tType\t\tDescription");
            Console.WriteLine("------------------------------------------------------------------------------");

            foreach (var subject in subjects)
            {
                Console.WriteLine($"{subject.SubjectId}\t{subject.SubjectName}\t\t{subject.SubjectCode}\t\t{subject.Level}\t{subject.Credits}\t{subject.GPACredits}\t\t{subject.SubjectType}\t\t{subject.Description}");
            }
        }

        // Method to Delete a Subject by ID
        public void DeleteSubject()
        {
            Console.Write("Enter Subject ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var subject = subjects.Find(s => s.SubjectId == id);

            if (subject != null)
            {
                subjects.Remove(subject);
                Console.WriteLine("Subject deleted successfully!");
            }
            else
            {
                Console.WriteLine("Subject not found.");
            }
        }

        // Method to Edit a Subject by ID
        public void EditSubject()
        {
            Console.Write("Enter Subject ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            var subject = subjects.Find(s => s.SubjectId == id);

            if (subject != null)
            {
                Console.Write("Enter new Subject Name (leave blank to keep unchanged): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    subject.SubjectName = newName;
                }

                Console.Write("Enter new Subject Code (leave blank to keep unchanged): ");
                string newCode = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCode))
                {
                    subject.SubjectCode = newCode;
                }

                Console.Write("Enter new Level (leave blank to keep unchanged): ");
                string newLevel = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLevel))
                {
                    subject.Level = int.Parse(newLevel);
                }

                Console.Write("Enter new Credits (leave blank to keep unchanged): ");
                string newCredits = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCredits))
                {
                    subject.Credits = int.Parse(newCredits);
                }

                Console.Write("Enter new GPA Credits (leave blank to keep unchanged): ");
                string newGPACredits = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGPACredits))
                {
                    subject.GPACredits = int.Parse(newGPACredits);
                }

                Console.Write("Enter new Subject Type (0 for Core, 1 for Optional, leave blank to keep unchanged): ");
                string newType = Console.ReadLine();
                if (!string.IsNullOrEmpty(newType))
                {
                    subject.SubjectType = (SubjectType)int.Parse(newType);
                }

                Console.Write("Enter new Description (leave blank to keep unchanged): ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription))
                {
                    subject.Description = newDescription;
                }

                Console.WriteLine("Subject updated successfully!");
            }
            else
            {
                Console.WriteLine("Subject not found.");
            }
        }
    }
}
