using GPAPlanner.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Services.DataStreams
{
    public class GradesDataStream
    {
        private readonly string _connectionString;

        public GradesDataStream(string databasePath)
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
                CREATE TABLE IF NOT EXISTS Grades (
                    GradeID INTEGER PRIMARY KEY,
                    Year INTEGER NOT NULL,
                    Semester INTEGER NOT NULL,
                    Attempt INTEGER NOT NULL,
                    IsRepeat INTEGER NOT NULL,
                    SubjectID INTEGER NOT NULL,
                    Grade INTEGER NOT NULL
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
                WHERE type='table' AND name='Grades'";
                return tableExistsCmd.ExecuteScalar() != null;
            }
        }

        public bool DataExists()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var dataExistsCmd = connection.CreateCommand();
                dataExistsCmd.CommandText = "SELECT COUNT(1) FROM Grades";
                return Convert.ToInt32(dataExistsCmd.ExecuteScalar()) > 0;
            }
        }

        public void InsertGrade(Grades grade)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = @"
                INSERT INTO Grades (Year, Semester, Attempt, IsRepeat, SubjectID, Grade)
                VALUES ($year, $semester, $attempt, $isRepeat, $subjectID, $grade)";
                insertCmd.Parameters.AddWithValue("$year", grade.Year);
                insertCmd.Parameters.AddWithValue("$semester", grade.Semester);
                insertCmd.Parameters.AddWithValue("$attempt", grade.Attempt);
                insertCmd.Parameters.AddWithValue("$isRepeat", grade.IsRepeat ? 1 : 0);
                insertCmd.Parameters.AddWithValue("$subjectID", grade.SubjectID);
                insertCmd.Parameters.AddWithValue("$grade", grade.Grade);

                insertCmd.ExecuteNonQuery();
            }
        }

        public List<Grades> GetGrades()
        {
            var grades = new List<Grades>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Grades";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var grade = new Grades
                        {
                            GradeID = reader.GetInt32(0),
                            Year = reader.GetInt32(1),
                            Semester = reader.GetInt32(2),
                            Attempt = reader.GetInt32(3),
                            IsRepeat = reader.GetInt32(4) == 1,
                            SubjectID = reader.GetInt32(5),
                            Grade = reader.GetInt32(6)
                        };
                        grades.Add(grade);
                    }
                }
            }

            return grades;
        }

        public void UpdateGrade(Grades grade)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = @"
                UPDATE Grades
                SET Year = $year,
                    Semester = $semester,
                    Attempt = $attempt,
                    IsRepeat = $isRepeat,
                    SubjectID = $subjectID,
                    Grade = $grade
                WHERE GradeID = $gradeID";
                updateCmd.Parameters.AddWithValue("$year", grade.Year);
                updateCmd.Parameters.AddWithValue("$semester", grade.Semester);
                updateCmd.Parameters.AddWithValue("$attempt", grade.Attempt);
                updateCmd.Parameters.AddWithValue("$isRepeat", grade.IsRepeat ? 1 : 0);
                updateCmd.Parameters.AddWithValue("$subjectID", grade.SubjectID);
                updateCmd.Parameters.AddWithValue("$grade", grade.Grade);
                updateCmd.Parameters.AddWithValue("$gradeID", grade.GradeID);

                updateCmd.ExecuteNonQuery();
            }
        }

        public void DeleteGrade(int gradeID)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Grades WHERE GradeID = $gradeID";
                deleteCmd.Parameters.AddWithValue("$gradeID", gradeID);

                deleteCmd.ExecuteNonQuery();
            }
        }
    }
}
