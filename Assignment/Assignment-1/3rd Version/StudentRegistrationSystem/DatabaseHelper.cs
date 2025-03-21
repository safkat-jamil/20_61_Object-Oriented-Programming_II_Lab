using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace StudentRegistrationSystem
{
    public static class DatabaseHelper
    {
        private static string dbFilePath = Path.Combine(Application.StartupPath, "studentdb.sqlite");
        private static string connectionString = $"Data Source={dbFilePath};Version=3;";

        public static void InitializeDatabase()
        {
            try
            {
                // If file doesn't exist, create it
                if (!File.Exists(dbFilePath))
                {
                    SQLiteConnection.CreateFile(dbFilePath);
                }

                // Test if it's a valid SQLite database
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    // Do a quick query to validate
                    using (var command = new SQLiteCommand("SELECT 1;", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Create table if it doesn't exist
                CreateTableIfNotExists();
            }
            catch (Exception ex)
            {
                // If it's corrupted or invalid, delete and recreate
                if (File.Exists(dbFilePath))
                {
                    File.Delete(dbFilePath);
                }
                SQLiteConnection.CreateFile(dbFilePath);

                // Now create the table
                CreateTableIfNotExists();

                // Optionally show a message
                MessageBox.Show($"Database file was invalid. A new one was created.\n\nError was:\n{ex.Message}",
                                "Database Recreated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void CreateTableIfNotExists()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Roll TEXT NOT NULL,
                        Semester TEXT NOT NULL,
                        RegID TEXT NOT NULL UNIQUE,
                        BloodGroup TEXT NOT NULL,
                        Gender TEXT NOT NULL,
                        Photo BLOB
                    );
                ";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InsertStudent(string name, string roll, string semester,
                                         string regId, string bloodGroup,
                                         string gender, byte[] photoBytes)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO Students (Name, Roll, Semester, RegID, BloodGroup, Gender, Photo)
                    VALUES (@name, @roll, @semester, @regId, @bloodGroup, @gender, @photo);
                ";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@roll", roll);
                    command.Parameters.AddWithValue("@semester", semester);
                    command.Parameters.AddWithValue("@regId", regId);
                    command.Parameters.AddWithValue("@bloodGroup", bloodGroup);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@photo", (object)photoBytes ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetStudents()
        {
            DataTable dt = new DataTable();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Students;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}