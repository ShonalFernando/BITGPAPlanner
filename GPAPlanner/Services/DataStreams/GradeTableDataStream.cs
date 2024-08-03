using GPAPlanner.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAPlanner.Services.DataStreams
{
    public class GradeTableDataStream
    {
        private readonly string _connectionString;

        public GradeTableDataStream(string databasePath)
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
                CREATE TABLE IF NOT EXISTS GradeTable (
                    GradeID INTEGER PRIMARY KEY,
                    GradeIndicator TEXT NOT NULL,
                    Low_Mark INTEGER NOT NULL,
                    High_Mark INTEGER NOT NULL,
                    GPV REAL NOT NULL
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
                WHERE type='table' AND name='GradeTable'";
                return tableExistsCmd.ExecuteScalar() != null;
            }
        }

        public bool DataExists()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var dataExistsCmd = connection.CreateCommand();
                dataExistsCmd.CommandText = "SELECT COUNT(1) FROM GradeTable";
                return Convert.ToInt32(dataExistsCmd.ExecuteScalar()) > 0;
            }
        }

        public void InsertGrade(GradeTable grade)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = @"
                INSERT INTO GradeTable (GradeIndicator, Low_Mark, High_Mark, GPV)
                VALUES ($gradeIndicator, $lowMark, $highMark, $gpv)";
                insertCmd.Parameters.AddWithValue("$gradeIndicator", grade.GradeIndicator);
                insertCmd.Parameters.AddWithValue("$lowMark", grade.Low_Mark);
                insertCmd.Parameters.AddWithValue("$highMark", grade.High_Mark);
                insertCmd.Parameters.AddWithValue("$gpv", grade.GPV);

                insertCmd.ExecuteNonQuery();
            }
        }

        public List<GradeTable> GetGrades()
        {
            var grades = new List<GradeTable>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM GradeTable";

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var grade = new GradeTable
                        {
                            GradeID = reader.GetInt32(0),
                            GradeIndicator = reader.GetString(1),
                            Low_Mark = reader.GetInt32(2),
                            High_Mark = reader.GetInt32(3),
                            GPV = reader.GetDouble(4)
                        };
                        grades.Add(grade);
                    }
                }
            }

            return grades;
        }

        public void UpdateGrade(GradeTable grade)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = @"
                UPDATE GradeTable
                SET GradeIndicator = $gradeIndicator,
                    Low_Mark = $lowMark,
                    High_Mark = $highMark,
                    GPV = $gpv
                WHERE GradeID = $gradeID";
                updateCmd.Parameters.AddWithValue("$gradeIndicator", grade.GradeIndicator);
                updateCmd.Parameters.AddWithValue("$lowMark", grade.Low_Mark);
                updateCmd.Parameters.AddWithValue("$highMark", grade.High_Mark);
                updateCmd.Parameters.AddWithValue("$gpv", grade.GPV);
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
                deleteCmd.CommandText = "DELETE FROM GradeTable WHERE GradeID = $gradeID";
                deleteCmd.Parameters.AddWithValue("$gradeID", gradeID);

                deleteCmd.ExecuteNonQuery();
            }
        }
    }
}
