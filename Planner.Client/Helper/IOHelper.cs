using Microsoft.Win32;
using Planner.Client.Settings;
using Planner.Client.View.Dialogs;
using Planner.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UnitTester.Session;

namespace Planner.Client.Helper
{
    public static class IOHelper
    {
        // Base directory from user settings or default location
        internal static readonly string BasePath = Properties.Default.BaseDataFolderPath ?? @"D:\MyBGVAdocs";

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

        internal static void LoadFiles()
        {
                var dialogResult = BitvaDialogs.ShowResourceAdder("Please Select the Subject", "Resource Manager");
                
                if(!string.IsNullOrEmpty(dialogResult.Item1) && !string.IsNullOrEmpty(dialogResult.Item2))
                {
                    try
                    {
                    // Open File Dialog
                    var openFileDialog = new OpenFileDialog
                    {
                        Multiselect = true,
                        Filter = GenerateFilter(GetFileTypesBySubFolder(dialogResult.Item2))
                    };

                        if (openFileDialog.ShowDialog() == true)
                        {
                            string targetPath = Path.Combine(BasePath, "BITVA Docs", dialogResult.Item1);

                            // Ensure the directory exists
                            Directory.CreateDirectory(targetPath);

                            // Copy selected files
                            foreach (var file in openFileDialog.FileNames)
                            {
                                string fileName = Path.GetFileName(file);
                                string destPath = Path.Combine(targetPath, fileName);
                                File.Copy(file, destPath, true); // Overwrite if exists
                            }

                            // Optionally notify the user
                            Console.WriteLine($"Files copied successfully to {targetPath}");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine($"Error loading files: {ex.Message}");
                    } 
            }
        }

        private static string GenerateFilter(string fileTypes)
        {
            // Build OpenFileDialog filter string based on allowed file extensions
            var extensions = fileTypes.Split(',');
            var filters = new List<string>();

            foreach (var ext in extensions)
            {
                string description = ext.TrimStart('.').ToUpperInvariant();
                filters.Add($"{description} Files (*{ext})|*{ext}");
            }

            filters.Add("All Files (*.*)|*.*"); // Add fallback for all files

            return string.Join("|", filters);
        }

        public static string GetFileTypesBySubFolder(string subFolder)
        {
            return subFolder switch
            {
                "Past Papers" => "PDF,Epub,.doc,.docx",
                "Notes" => "PDF,.one,.txt,.docx,.doc",
                "Random" => "PDF,.png,.jpg",
                "Reciepts" => "PDF,.png,.jpg",
                "Reference Books" => "PDF,Epub,.doc,.docx",
                "Videos" => ".mp4",
                _ => "All Files (*.*)|*.*" // Default to all files if no match
            };
        }
    }
}
