using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Data;
using System.IO;

namespace SQLite
{
    public class SQLiteDB
    {
        private readonly string _databasePath;

        public SQLiteDB(string databasePath, bool recreate = false)
        {
            _databasePath = databasePath;

            if (recreate && File.Exists(_databasePath))
            {
                File.Delete(_databasePath);
            }

            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            string createTablesQuery = @"
            CREATE TABLE IF NOT EXISTS Eleves 
            (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                nom TEXT NOT NULL,
                prenom TEXT NOT NULL,
                description TEXT
            );";

            ExecuteNonQuery(createTablesQuery);
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Ajoute un eleve dans la bd
        /// </summary>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prenom</param>
        /// <param name="description">description</param>
        public void AjouterEleve(string nom, string prenom, string description)
        {
            string query = @"INSERT INTO Eleves(nom, prenom, description) VALUES (@nom, @prenom, @description);";
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@prenom", prenom);
                    command.Parameters.AddWithValue("@description", description);

                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable getEleve()
        {
            string query = @"SELECT * FROM Eleves;";
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }
        public DataTable getEleve(int id)
        {
            string query = @"SELECT * FROM Eleves WHERE id = @id;";
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        return table;
                    }
                }
            }
        }
    }
}