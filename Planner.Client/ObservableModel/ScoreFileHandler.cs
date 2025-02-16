using MessagePack;
using Microsoft.Win32;
using Planner.Client.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Planner.Client.ObservableModel
{
    internal class ScoreFileHandler
    {
        private const string FileExtension = ".scoredata"; // Custom file extension
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("3T1L7qj4M5frX8+7bVrqFlpP91vgqNYX6j5bqK+lXP8="); // 32 bytes (256-bit key)
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("FjO4TyWr6kjbDqRmQh6RYw=="); // 16 bytes (128-bit IV)

        public static void SaveScoresFile(ScoresFile scoresFile)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Scores Data (*.scoredata)|*.scoredata",
                DefaultExt = "scoredata",
                Title = "Save Scores File"
            };

            if (saveDialog.ShowDialog() == true)
            {
                try
                {
                    string json = JsonSerializer.Serialize(scoresFile, new JsonSerializerOptions { WriteIndented = true });
                    //byte[] encryptedData = AESHelper.Encrypt(json, Key, IV);
                    File.WriteAllText(saveDialog.FileName, json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}");
                }
            }
        }

        public static ScoresFile LoadScoresFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Scores Data (*.scoredata)|*.scoredata",
                Title = "Open Scores File"
            };

            if (openDialog.ShowDialog() == true)
            {
                try
                {
                    string json = File.ReadAllText(openDialog.FileName);
                    return JsonSerializer.Deserialize<ScoresFile>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading file: {ex.Message}");
                }
            }

#pragma warning disable
            return null;
#pragma warning enable
        }
    }
}
