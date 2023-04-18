using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WaveWpf.Models;

namespace WaveWpf.UI
{
    /// <summary>
    /// Logique d'interaction pour ListeOeuvreGroupePopup.xaml
    /// </summary>
    public partial class ListeOeuvreGroupePopup : Window
    {
        public int IdGroupe { get; set; }
        public ListeOeuvreGroupePopup(int id_groupe, string nom_groupe)
        {
            InitializeComponent();
            IdGroupe = id_groupe;
            GetOeuvreGroupe();
            labelNameGroupe.Content = nom_groupe;
        }

        /// <summary>
        /// Récupération de la liste des oeuvres d'un groupe.
        /// </summary>
        private void GetOeuvreGroupe()
        {

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT id_oeuvre, title, duration FROM Oeuvres WHERE id_groupe = @idGroupe";
            cmd.Parameters.AddWithValue("@idGroupe", IdGroupe);

            // Exécuter la requête et récupérer les résultats
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Créer une liste des oeuvres pour stocker les données de chaque groupe.
            List<OeuvreModel> oeuvres = new List<OeuvreModel>();

            // Parcourir les résultats et ajouter chaque titre et durée à la liste
            while (reader.Read())
            {
                int idOeuvre = reader.GetInt32(0);
                string title = reader.GetString(1);
                string duration = reader.GetString(2);
                oeuvres.Add(new OeuvreModel{ Id = idOeuvre, Title = title, Duration = duration });                
            }
            // Assigner la liste des oeuvrs comme ItemsSource du DataGrid
            datagridOeuvreGroupes.ItemsSource = oeuvres;
        }
    }
}
