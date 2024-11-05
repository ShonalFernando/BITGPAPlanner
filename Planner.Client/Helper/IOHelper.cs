using Microsoft.Win32;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planner.Client.Helper
{
    public static class IOHelper
    {
        // Method to open a CSV file, parse it, and add subjects to the database.
        public static void ImportSubjectsFromCSV(string connectionString)
        {
            // Open File Dialog to select CSV file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                Title = "Select a CSV File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Read and parse the CSV file
                    List<Subject> subjects = ParseCSV(filePath);

                    // Call the existing bulk adder method
                    Subject.AddSubjectsBulk(connectionString, subjects);

                    MessageBox.Show("Subjects imported successfully!");
                }
                catch (Exception ex)
                {
                   MessageBox.Show($"Error occurred: {ex.Message}");
                }
            }
        }

        // Method to parse the CSV and map data to a list of Subject objects
        private static List<Subject> ParseCSV(string filePath)
        {
            var subjects = new List<Subject>();

            using (var reader = new StreamReader(filePath))
            {
                // Skip the header line
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');

                        // Map CSV data to Subject object
                        var subject = new Subject
                        {
                            SubjectCode = values[0].Trim(),
                            SubjectName = values[1].Trim(),
                            Level = int.Parse(values[2].Trim()),
                            Credits = int.Parse(values[3].Trim()),
                            GPACredits = int.Parse(values[4].Trim()),
                            Description = values[5].Trim()
                        };

                        subjects.Add(subject);
                    }
                }
            }

            return subjects;
        }
    }
}
