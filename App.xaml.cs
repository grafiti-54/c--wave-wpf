using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WaveWpf
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateDatabase();
        }
        private void CreateDatabase()
        {
            string path = "wave.db";
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE " +
                        "Users(id_user INTEGER PRIMARY KEY AUTOINCREMENT," +
                            "email VARCHAR(250),password VARCHAR(30),role BOOLEAN);" +
                        "\r\nCREATE TABLE Groupes(id_groupe INTEGER PRIMARY KEY AUTOINCREMENT,name VARCHAR(150),address VARCHAR(150),phone VARCHAR(15),id_user INTEGER NOT NULL,FOREIGN KEY(id_user) REFERENCES Users(id_user));" +
                        "\r\nCREATE TABLE Concerts(id_concert INTEGER PRIMARY KEY AUTOINCREMENT,jour DATETIME,address VARCHAR(150),id_user INTEGER NOT NULL,FOREIGN KEY(id_user) REFERENCES Users(id_user));" +
                        "\r\nCREATE TABLE Oeuvres(id_oeuvre INTEGER PRIMARY KEY AUTOINCREMENT,title VARCHAR(50),duration VARCHAR(50),id_user INTEGER NOT NULL,id_groupe INTEGER NOT NULL,FOREIGN KEY(id_user) REFERENCES Users(id_user),FOREIGN KEY(id_groupe) REFERENCES Groupes(id_groupe));" +
                        "\r\nCREATE TABLE Participe(id_groupe INTEGER,id_concert INTEGER,PRIMARY KEY(id_groupe, id_concert),FOREIGN KEY(id_groupe) REFERENCES Groupes(id_groupe),FOREIGN KEY(id_concert) REFERENCES Concerts(id_concert));\r\nCREATE TABLE Reserve(id_user INTEGER,id_concert INTEGER,name VARCHAR(150),firstname VARCHAR(150),phone VARCHAR(50),PRIMARY KEY(id_user, id_concert),FOREIGN KEY(id_user) REFERENCES Users(id_user),FOREIGN KEY(id_concert) REFERENCES Concerts(id_concert));";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    // Création de l'utilisateur
                    string email = "admin@admin.fr";
                    string password = BCrypt.Net.BCrypt.HashPassword("1234");
                    bool role = true;
                    sql = $"INSERT INTO Users(email, password, role) VALUES ('{email}', '{password}', '{role}')";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("La base de données existe déjà");
            }
        }
    }
}
