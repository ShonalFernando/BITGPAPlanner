using GPAPlanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace GPAPlanner.Services.DataStreams
{
    public class SubjectDataStream
    {
        private readonly string _connectionString;

        public SubjectDataStream(string databasePath)
        {
            _connectionString = $"Data Source={databasePath}";
        }

        public void CreateTable()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Subject (
                    SubjectID INTEGER PRIMARY KEY,
                    Semester INTEGER NOT NULL,
                    Name TEXT NOT NULL,
                    Syllabus INTEGER NOT NULL,
                    SubjectModifier INTEGER NOT NULL,
                    Code INTEGER NOT NULL,
                    Credit INTEGER NOT NULL,
                    GPACredit INTEGER NOT NULL
                )";
                createTableCmd.ExecuteNonQuery();
            }
        }

        public bool TableExists()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var tableExistsCmd = connection.CreateCommand();
                tableExistsCmd.CommandText = @"
                SELECT name 
                FROM sqlite_master 
                WHERE type='table' AND name='Subject'";
                return tableExistsCmd.ExecuteScalar() != null;
            }
        }

        public bool DataExists()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var dataExistsCmd = connection.CreateCommand();
                dataExistsCmd.CommandText = "SELECT COUNT(1) FROM Subject";
                return Convert.ToInt32(dataExistsCmd.ExecuteScalar()) > 0;
            }
        }

        public void InsertSubject(Subject subject)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = @"
                INSERT INTO Subject (Semester, Name, Syllabus, SubjectModifier, Code, Credit, GPACredit)
                VALUES ($semester, $name, $syllabus, $subjectModifier, $code, $credit, $gpaCredit)";
                insertCmd.Parameters.AddWithValue("$semester", subject.Semester);
                insertCmd.Parameters.AddWithValue("$name", subject.Name);
                insertCmd.Parameters.AddWithValue("$syllabus", (int)subject.Syllabus);
                insertCmd.Parameters.AddWithValue("$subjectModifier", (int)subject.SubjectModifier);
                insertCmd.Parameters.AddWithValue("$code", subject.Code);
                insertCmd.Parameters.AddWithValue("$credit", subject.Credit);
                insertCmd.Parameters.AddWithValue("$gpaCredit", subject.GPACredit);

                insertCmd.ExecuteNonQuery();
            }
        }

        public List<Subject> GetSubjects()
        {
            var subjects = new List<Subject>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Subject";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subject = new Subject
                        {
                            SubjectID = reader.GetInt32(0),
                            Semester = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Syllabus = (Syllabus)reader.GetInt32(3),
                            SubjectModifier = (SubjectModifier)reader.GetInt32(4),
                            Code = reader.GetInt32(5),
                            Credit = reader.GetInt32(6),
                            GPACredit = reader.GetInt32(7)
                        };
                        subjects.Add(subject);
                    }
                }
            }

            return subjects;
        }

        public void UpdateSubject(Subject subject)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = @"
                UPDATE Subject
                SET Semester = $semester,
                    Name = $name,
                    Syllabus = $syllabus,
                    SubjectModifier = $subjectModifier,
                    Code = $code,
                    Credit = $credit,
                    GPACredit = $gpaCredit
                WHERE SubjectID = $subjectID";
                updateCmd.Parameters.AddWithValue("$semester", subject.Semester);
                updateCmd.Parameters.AddWithValue("$name", subject.Name);
                updateCmd.Parameters.AddWithValue("$syllabus", (int)subject.Syllabus);
                updateCmd.Parameters.AddWithValue("$subjectModifier", (int)subject.SubjectModifier);
                updateCmd.Parameters.AddWithValue("$code", subject.Code);
                updateCmd.Parameters.AddWithValue("$credit", subject.Credit);
                updateCmd.Parameters.AddWithValue("$gpaCredit", subject.GPACredit);
                updateCmd.Parameters.AddWithValue("$subjectID", subject.SubjectID);

                updateCmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(int subjectID)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Subject WHERE SubjectID = $subjectID";
                deleteCmd.Parameters.AddWithValue("$subjectID", subjectID);

                deleteCmd.ExecuteNonQuery();
            }
        }
    }
}
