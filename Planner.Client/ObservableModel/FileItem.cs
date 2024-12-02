using Planner.Client.Command;
using Planner.Client.View.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Planner.Client.ObservableModel
{
    internal class FileItem
    {
        public string Name { get; set; }
        public BitmapImage Icon { get; set; }
        public string FilePath { get; set; } // Store file path

        // Command to open the file and other commands
        public ICommand OpenFileCommand { get; }
        public ICommand RenameFileCommand { get; } // New rename command
        public ICommand CopyFileCommand { get; }

        public FileItem(string filePath)
        {
            FilePath = filePath;
            Name = Path.GetFileName(filePath);
            Icon = GetIconForFile(filePath);
            OpenFileCommand = new RelayCommand(_ => OpenFile());
            CopyFileCommand = new RelayCommand(_ => CopyFile());
            RenameFileCommand = new RelayCommand(_ => RenameFile()); // Initialize rename command

        }

        private BitmapImage GetIconForFile(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath).ToLower();
            string iconPath;

            // Choose the icon based on file extension
            switch (fileExtension)
            {
                case ".pdf":
                    iconPath = "Assets/FileIcons/icons8-pdf-48.png";
                    break;
                case ".docx":
                    iconPath = "Assets/FileIcons/icons8-document-48.png";
                    break;
                default:
                    iconPath = "Assets/FileIcons/icons8-pdf-48.png"; // Default icon
                    break;
            }

            return new BitmapImage(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath), UriKind.Absolute));
        }

        // Method to open the file with the default associated application
        private void OpenFile()
        {
            if (File.Exists(FilePath))
            {
                Process.Start(new ProcessStartInfo(FilePath) { UseShellExecute = true });
            }
        }

        private void CopyFile()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    Clipboard.SetFileDropList(new System.Collections.Specialized.StringCollection { FilePath });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to copy file: {ex.Message}");
                }
            }
        }

        private void RenameFile()
        {
            if (!File.Exists(FilePath))
                return;

            // Prompt user for a new name
            string newName = PromptForNewFileName(Name);

            if (string.IsNullOrWhiteSpace(newName) || newName == Name)
                return;

            // Build new file path
            string newFilePath = Path.Combine(Path.GetDirectoryName(FilePath)!, newName);

            try
            {
                File.Move(FilePath, newFilePath);
                FilePath = newFilePath;
                Name = newName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to rename file: {ex.Message}");
            }
        }

        // Helper method to prompt for a new file name
        private string PromptForNewFileName(string currentName)
        {
            return BitvaDialogs.ShowInputDialog("Enter the new file name", "Rename File", currentName);
            
        }
    }
}
