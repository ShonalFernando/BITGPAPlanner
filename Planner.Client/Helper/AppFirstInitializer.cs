using Planner.Client.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Planner.Client.Helper
{
    internal static class AppFirstInitializer
    {
        // Base directory from user settings or default location
        private static readonly string BasePath = Properties.Default.BaseDataFolderPath ?? @"D:\MyBGVAdocs";

        // Method to initialize the folder structure
        public static void InitializeFolders()
        {
            try
            {
                // Root folder
                string rootFolder = Path.Combine(BasePath, "BITVA Docs");

                // Subfolders per semester and their subcategories
                string[] subfolders = { "Past Papers", "Notes", "Videos", "Reference Books", "Receipts", "Random" };

                for (int semester = 1; semester <= 6; semester++)
                {
                    string semesterFolder = Path.Combine(rootFolder, $"Semester {semester}");

                    foreach (var subfolder in subfolders)
                    {
                        string subfolderPath = Path.Combine(semesterFolder, subfolder);
                        Directory.CreateDirectory(subfolderPath);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as insufficient permissions
                MessageBox.Show($"Error creating folder structure: {ex.Message}");
            }
        }
    }
}
