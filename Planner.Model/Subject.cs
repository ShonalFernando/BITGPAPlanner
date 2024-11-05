using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Planner.Model
{
    public class Subject
    {
        // =========================================================== Properties and Fields

        public int          SubjectId   { get; set; }               // Primary Key

        public int          Level       { get; set; }               // The level the Subject Belongs to

        public string       SubjectName { get; set; } = null!;      // Subject Name
        public string       SubjectCode { get; set; } = null!;      // Code of the Subject

        public int          Credits     { get; set; }               // Credits of The Subject
        public int          GPACredits  { get; set; }               // Credits of The Subject
        public SubjectType  SubjectType { get; set; }               // Type of the Subject C, O

        public string?      Description { get; set; }               // A Short Description on the Subject

        // =========================================================== Business Logic

        // Method to create the Subject table
        public static void CreateTable(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                CREATE TABLE IF NOT EXISTS Subjects (
                    SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Level INTEGER NOT NULL,
                    SubjectName TEXT NOT NULL,
                    SubjectCode TEXT NOT NULL,
                    Credits INTEGER NOT NULL,
                    GPACredits INTEGER NOT NULL,
                    SubjectType INTEGER NOT NULL, -- Compulsory = 0, Optional = 1
                    Description TEXT
                );";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to add a single subject
        public static void AddSubject(string connectionString, Subject subject)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                INSERT INTO Subjects (Level, SubjectName, SubjectCode, Credits, GPACredits, SubjectType, Description)
                VALUES (@Level, @SubjectName, @SubjectCode, @Credits, @GPACredits, @SubjectType, @Description);";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Level", subject.Level);
                    command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                    command.Parameters.AddWithValue("@SubjectCode", subject.SubjectCode);
                    command.Parameters.AddWithValue("@Credits", subject.Credits);
                    command.Parameters.AddWithValue("@GPACredits", subject.GPACredits);
                    command.Parameters.AddWithValue("@SubjectType", subject.SubjectType);
                    command.Parameters.AddWithValue("@Description", subject.Description ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to add subjects in bulk
        public static void AddSubjectsBulk(string connectionString, List<Subject> subjects)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string query = @"
                    INSERT INTO Subjects (Level, SubjectName, SubjectCode, Credits, GPACredits, SubjectType, Description)
                    VALUES (@Level, @SubjectName, @SubjectCode, @Credits, @GPACredits, @SubjectType, @Description);";

                    foreach (var subject in subjects)
                    {
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Level", subject.Level);
                            command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                            command.Parameters.AddWithValue("@SubjectCode", subject.SubjectCode);
                            command.Parameters.AddWithValue("@Credits", subject.Credits);
                            command.Parameters.AddWithValue("@GPACredits", subject.GPACredits);
                            command.Parameters.AddWithValue("@SubjectType", subject.SubjectType);
                            command.Parameters.AddWithValue("@Description", subject.Description ?? (object)DBNull.Value);

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        // Method to update a subject by ID
        public static void UpdateSubjectById(string connectionString, Subject subject)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string query = @"
                    UPDATE Subjects
                    SET 
                        Level = @Level, 
                        SubjectName = @SubjectName, 
                        SubjectCode = @SubjectCode, 
                        Credits = @Credits, 
                        GPACredits = @GPACredits, 
                        SubjectType = @SubjectType, 
                        Description = @Description
                    WHERE 
                        SubjectId = @SubjectId;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Level", subject.Level);
                        command.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
                        command.Parameters.AddWithValue("@SubjectCode", subject.SubjectCode);
                        command.Parameters.AddWithValue("@Credits", subject.Credits);
                        command.Parameters.AddWithValue("@GPACredits", subject.GPACredits);
                        command.Parameters.AddWithValue("@SubjectType", subject.SubjectType);
                        command.Parameters.AddWithValue("@Description", subject.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@SubjectId", subject.SubjectId); // Ensure SubjectId is set

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        // Method to delete a subject by ID
        public static void DeleteSubjectById(string connectionString, Subject subject)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    string query = @"
            DELETE FROM Subjects
            WHERE SubjectId = @SubjectId;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubjectId", subject.SubjectId);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        // Reset Sequence
        public static void ResetSubjectIdSequence(string connectionString)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("DELETE FROM sqlite_sequence WHERE name = 'Subjects';", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to read all subjects
        public static List<Subject> GetAllSubjects(string connectionString)
        {
            List<Subject> subjects = new List<Subject>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Subjects;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                Level = Convert.ToInt32(reader["Level"]),
                                SubjectName = reader["SubjectName"].ToString()!,
                                SubjectCode = reader["SubjectCode"].ToString()!,
                                Credits = Convert.ToInt32(reader["Credits"]),
                                GPACredits = Convert.ToInt32(reader["GPACredits"]),
                                SubjectType = (SubjectType)Convert.ToInt32(reader["SubjectType"]),
                                Description = reader["Description"]?.ToString()
                            });
                        }
                    }
                }
            }

            return subjects;
        }

        // Method to read all subjects from a given level
        public static List<Subject> GetSubjectsByLevel(string connectionString, int level)
        {
            List<Subject> subjects = new List<Subject>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Subjects WHERE Level = @Level;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Level", level);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                Level = Convert.ToInt32(reader["Level"]),
                                SubjectName = reader["SubjectName"].ToString()!,
                                SubjectCode = reader["SubjectCode"].ToString()!,
                                Credits = Convert.ToInt32(reader["Credits"]),
                                GPACredits = Convert.ToInt32(reader["GPACredits"]),
                                SubjectType = (SubjectType)Convert.ToInt32(reader["SubjectType"]),
                                Description = reader["Description"]?.ToString()
                            });
                        }
                    }
                }
            }

            return subjects;
        }

        // Method to read a subject by SubjectId (PK)
        public static Subject? GetSubjectById(string connectionString, int subjectId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Subjects WHERE SubjectId = @SubjectId;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectId", subjectId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subject
                            {
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                Level = Convert.ToInt32(reader["Level"]),
                                SubjectName = reader["SubjectName"].ToString()!,
                                SubjectCode = reader["SubjectCode"].ToString()!,
                                Credits = Convert.ToInt32(reader["Credits"]),
                                GPACredits = Convert.ToInt32(reader["GPACredits"]),
                                SubjectType = (SubjectType)Convert.ToInt32(reader["SubjectType"]),
                                Description = reader["Description"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Method to read a subject by subject code
        public static Subject? GetSubjectByCode(string connectionString, string subjectCode)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Subjects WHERE SubjectCode = @SubjectCode;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectCode", subjectCode);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Subject
                            {
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                Level = Convert.ToInt32(reader["Level"]),
                                SubjectName = reader["SubjectName"].ToString()!,
                                SubjectCode = reader["SubjectCode"].ToString()!,
                                Credits = Convert.ToInt32(reader["Credits"]),
                                GPACredits = Convert.ToInt32(reader["GPACredits"]),
                                SubjectType = (SubjectType)Convert.ToInt32(reader["SubjectType"]),
                                Description = reader["Description"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        // Method to get GPA credits by subject code
        public static int GetGPACreditsByCode(string connectionString, string subjectCode)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT GPACredits FROM Subjects WHERE SubjectCode = @SubjectCode;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubjectCode", subjectCode);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

    }

    public enum SubjectType
    {
        Compulsory,
        Optional
    }
}
