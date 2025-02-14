using Planner.Model;
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

        public string FileName { get; set; } = null!;

        public Category Category { get; set; }
        public Subject Subject { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        // Insert Record
        public static void Insert(string connectionString, FileStorage fileStorage)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = @"
            INSERT INTO FileStorage (FileName, Category, SubjectID, Description) 
            VALUES (@FileName, @Category, @SubjectID, @Description);";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FileName", fileStorage.FileName);
                    command.Parameters.AddWithValue("@Category", fileStorage.Category.ToString());
                    command.Parameters.AddWithValue("@SubjectID", fileStorage.Subject.SubjectId);
                    command.Parameters.AddWithValue("@Description", fileStorage.Description);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Create Table
        public static void CreateTable(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS FileStorage (
                    FileID INTEGER PRIMARY KEY AUTOINCREMENT,
                    FileName TEXT NOT NULL,
                    Category TEXT NOT NULL,
                    SubjectID INTEGER NOT NULL,
                    Description TEXT,
                    FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectId)
                );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Get All Records
        public static List<FileStorage> GetAll(string connectionString)
        {
            var fileStorages = new List<FileStorage>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FileStorage";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fileStorages.Add(new FileStorage
                        {
                            FileID = Convert.ToInt32(reader["FileID"]),
                            FileName = reader["FileName"].ToString() ?? string.Empty,
                            Category = Enum.Parse<Category>(reader["Category"].ToString()!),
                            Subject = Subject.GetSubjectById(connectionString,Convert.ToInt32(reader["SubjectID"])) ?? new Subject(),
                            Description = reader["Description"].ToString()!
                        });
                    }
                }
            }

            return fileStorages;
        }

        // Get Records by SubjectID
        public static List<FileStorage> GetBySubject(string connectionString, int subjectId)
        {
            var fileStorages = new List<FileStorage>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM FileStorage WHERE SubjectID = @SubjectID";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectID", subjectId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fileStorages.Add(new FileStorage
                            {
                                FileID = Convert.ToInt32(reader["FileID"]),
                                FileName = reader["FileName"].ToString() ?? string.Empty,
                                Category = Enum.Parse<Category>(reader["Category"].ToString()!),
                                Subject = Subject.GetSubjectById(connectionString, Convert.ToInt32(reader["SubjectID"])) ?? new Subject(),
                                Description = reader["Description"].ToString()!
                            });
                        }
                    }
                }
            }

            return fileStorages;
        }

        // Update Record
        public static void Update(string connectionString, FileStorage fileStorage)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
                UPDATE FileStorage 
                SET FileName = @FileName, 
                    Category = @Category, 
                    SubjectID = @SubjectID, 
                    Description = @Description 
                WHERE FileID = @FileID";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@FileID", fileStorage.FileID);
                    command.Parameters.AddWithValue("@FileName", fileStorage.FileName);
                    command.Parameters.AddWithValue("@Category", fileStorage.Category.ToString());
                    command.Parameters.AddWithValue("@SubjectID", fileStorage.Subject.SubjectId);
                    command.Parameters.AddWithValue("@Description", fileStorage.Description);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete Record
        public static void Delete(string connectionString, int fileID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM FileStorage WHERE FileID = @FileID";

                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@FileID", fileID);
                    command.ExecuteNonQuery();
                }
            }
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
