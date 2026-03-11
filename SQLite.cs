using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;

namespace SQLite
{
    internal class SQLiteDB
    {
        private readonly string _databasePath; // Chemin de la base de données SQLite

        /// <summary>
        /// Constructeur de la classe SQLiteDB.
        /// Initialise la base de données et, si demandé, recrée la base existante.
        /// </summary>
        /// <param name="databasePath">Chemin du fichier de base de données SQLite.</param>
        /// <param name="recreate">Indique si la base de données doit être recréée si elle existe déjà.</param>
        public SQLiteDB(string databasePath, bool recreate = false)
        {
            _databasePath = databasePath;

            // Vérifie si le fichier doit être recréé
            if (recreate)
            {
                try
                {
                    // Supprime le fichier s'il existe
                    if (File.Exists(_databasePath))
                    {
                        File.Delete(_databasePath); // Supprime le fichier existant
                    }
                }
                catch (Exception ex)
                {
                    throw new IOException($"Erreur lors de la suppression de la base de données : {ex.Message}");
                }
            }

            // Initialise la base de données en créant les tables nécessaires
            InitializeDatabase();
        }

        /// <summary>
        /// Initialise la base de données SQLite en créant les tables nécessaires.
        /// Insère également des données initiales dans la base.
        /// </summary>
        public void InitializeDatabase()
        {
            // Crée une connexion à la base de données SQLite
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();

                // Requête SQL pour créer les tables si elles n'existent pas déjà
                string createTablesQuery = @"
                CREATE TABLE Eleves 
                    (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nom TEXT NOT NULL,
                        prenom TEXT NOT NULL,
                        description TEXT
                    );
                ";

                // Exécute la requête pour créer les tables
                ExecuteNonQuery(createTablesQuery);

                // Requête SQL pour insérer des données initiales dans les tables
                string insertDataQuery = @"";


                // Exécute la requête pour insérer les données initiales
                ExecuteNonQuery(insertDataQuery);
            }
        }

        /// <summary>
        /// Exécute une requête SQL SELECT et retourne les résultats sous forme de DataTable.
        /// </summary>
        /// <param name="query">La requête SQL SELECT à exécuter.</param>
        /// <returns>Un objet DataTable contenant les résultats de la requête.</returns>
        public DataTable ExecuteQuery(string query)
        {
            // Crée une connexion à la base de données SQLite
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();

                // Crée et exécute la commande SQL
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Charge les résultats dans un DataTable
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }

        /// <summary>
        /// Exécute une commande SQL non requise pour retourner des résultats (INSERT, UPDATE, DELETE, etc.).
        /// </summary>
        /// <param name="query">La commande SQL à exécuter.</param>
        public void ExecuteNonQuery(string query)
        {
            // Crée une connexion à la base de données SQLite
            using (SqliteConnection connection = new SqliteConnection($"Data Source={_databasePath}"))
            {
                connection.Open();

                // Crée et exécute la commande SQL
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Check for possibles SQLinjection attempt
        /// </summary>
        /// <param name="query">String to check</param>
        /// <returns>a bool comfirming if there is an injection or no</returns>
        public bool SqlInsejectionCheck(string query)
        {
            int commentaryCheck = 0; 
            foreach (char c in query)
            { 
                if (c == '-')
                {
                    commentaryCheck++;
                }
                else
                {
                    commentaryCheck = 0;
                }

                if (commentaryCheck == 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
