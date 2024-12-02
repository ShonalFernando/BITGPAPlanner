using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.ObservableModel
{
    internal class FileStorage
    {
        public int FileID { get; set; }

        public int FileName { get; set; }

        public Category Category { get; set; }
        public int SubjectID { get; set; }

        public string Description { get; set; } = string.Empty;

        // Create Table
        public static void CreateFileStorageTable(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    CREATE TABLE IF NOT EXISTS FileStorage (
                        FileID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FileName INTEGER NOT NULL UNIQUE,
                        Category INTEGER NOT NULL, -- Maps to the Category enum
                        SubjectID INTEGER NOT NULL,
                        Description TEXT
                    );";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Add A File Record
        public static void AddFileStorage(string connectionString, FileStorage fileStorage)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
        INSERT INTO FileStorage (FileName, Category, SubjectID, Description)
        VALUES (@FileName, @Category, @SubjectID, @Description);";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileName", fileStorage.FileName);
                    command.Parameters.AddWithValue("@Category", (int)fileStorage.Category);
                    command.Parameters.AddWithValue("@SubjectID", fileStorage.SubjectID);
                    command.Parameters.AddWithValue("@Description", fileStorage.Description ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Get all File Records
        public static List<FileStorage> GetAllFileStorage(string connectionString)
        {
            var fileStorages = new List<FileStorage>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FileStorage;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileStorages.Add(new FileStorage
                            {
                                FileID = Convert.ToInt32(reader["FileID"]),
                                FileName = Convert.ToInt32(reader["FileName"]),
                                Category = (Category)Convert.ToInt32(reader["Category"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                Description = reader["Description"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return fileStorages;
        }

        // Update File Record
        public static void UpdateFileStorage(string connectionString, FileStorage fileStorage)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
        UPDATE FileStorage
        SET FileName = @FileName, 
            Category = @Category, 
            SubjectID = @SubjectID, 
            Description = @Description
        WHERE FileID = @FileID;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileID", fileStorage.FileID);
                    command.Parameters.AddWithValue("@FileName", fileStorage.FileName);
                    command.Parameters.AddWithValue("@Category", (int)fileStorage.Category);
                    command.Parameters.AddWithValue("@SubjectID", fileStorage.SubjectID);
                    command.Parameters.AddWithValue("@Description", fileStorage.Description ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete a File Record
        public static void DeleteFileStorage(string connectionString, int fileID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM FileStorage WHERE FileID = @FileID;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileID", fileID);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Get File Storage by Subject
        public static List<FileStorage> GetFileStorageBySubject(string connectionString, int subjectID)
        {
            var fileStorages = new List<FileStorage>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FileStorage WHERE SubjectID = @SubjectID;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileStorages.Add(new FileStorage
                            {
                                FileID = Convert.ToInt32(reader["FileID"]),
                                FileName = Convert.ToInt32(reader["FileName"]),
                                Category = (Category)Convert.ToInt32(reader["Category"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                Description = reader["Description"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return fileStorages;
        }

        // Get File Storage by Category
        public static List<FileStorage> GetFileStorageByCategory(string connectionString, Category category)
        {
            var fileStorages = new List<FileStorage>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FileStorage WHERE Category = @Category;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Category", (int)category);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileStorages.Add(new FileStorage
                            {
                                FileID = Convert.ToInt32(reader["FileID"]),
                                FileName = Convert.ToInt32(reader["FileName"]),
                                Category = (Category)Convert.ToInt32(reader["Category"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                Description = reader["Description"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return fileStorages;
        }


        // Get File Storage by Subject and Category
        public static List<FileStorage> GetFileStorageBySubjectAndCategory(string connectionString, int subjectID, Category category)
        {
            var fileStorages = new List<FileStorage>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FileStorage WHERE SubjectID = @SubjectID AND Category = @Category;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectID", subjectID);
                    command.Parameters.AddWithValue("@Category", (int)category);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileStorages.Add(new FileStorage
                            {
                                FileID = Convert.ToInt32(reader["FileID"]),
                                FileName = Convert.ToInt32(reader["FileName"]),
                                Category = (Category)Convert.ToInt32(reader["Category"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                Description = reader["Description"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            return fileStorages;
        }



    }

    public enum Category
    {
        Any,
        PastPapers,
        Notes,
        Random,
        Receipts,
        ReferenceBooks,
        Videos
    }
}
