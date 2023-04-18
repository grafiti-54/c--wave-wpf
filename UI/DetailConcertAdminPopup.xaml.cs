using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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
    /// Logique d'interaction pour DetailConcertAdminPopup.xaml
    /// </summary>
    public partial class DetailConcertAdminPopup : Window
    {
        public int IdConcert { get; set; }
        public DetailConcertAdminPopup(int id_concert)
        {
            InitializeComponent();
            IdConcert = id_concert;
            LoadGroupConcert();
            GetConcertInfo();
        }

        private void GetConcertInfo()
        {
            ConcertModel concert = new ConcertModel { Id = IdConcert };
            DbApp.GetConcertById(concert);
            labelDay.Content = concert.Day;
            labelAddress.Content = concert.Address;
        }

        /// <summary>
        /// Récupération de la liste des participants au concert.
        /// </summary>
        private void LoadGroupConcert()
        {
            // Récupérer les données de la base de données
            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT Groupes.name, Groupes.id_groupe FROM Groupes JOIN Participe ON Groupes.id_groupe = Participe.id_groupe WHERE Participe.id_concert = @idConcert";
            cmd.Parameters.AddWithValue("@idConcert", IdConcert);

            // Exécuter la requête et récupérer les résultats
            SQLiteDataReader reader = cmd.ExecuteReader();

            // Créer une liste de GroupeConcert pour stocker les données de chaque groupe
            List<GroupeModel> groupes = new List<GroupeModel>();

            // Parcourir les résultats et ajouter chaque nom de groupe à la liste
            while (reader.Read())
            {
                int idGroupe = reader.GetInt32(1);
                string nomGroupe = reader.GetString(0);
                groupes.Add(new GroupeModel { Id = idGroupe, Name = nomGroupe });
            }

            // Assigner la liste de groupes comme ItemsSource du DataGrid
            datagridGroupes.ItemsSource = groupes;
        }
        /// <summary>
        /// Validation pour la suppression d'un groupe au concert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Retirer_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer l'ID du groupe à retirer à partir du parametre passé dans le bouton dans le fichier xaml
            Button button = (Button)sender;
            int idGroupe = (int)button.CommandParameter;

            // Retirer le groupe de la base de données et mettre à jour le DataGrid
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir retirer le groupe de ce concert ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (Session.Role)
            {
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        SQLiteConnection con = DbApp.GetConnection();
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        // Suppression de la participation du groupe au concert dans la table Participe
                        cmd.CommandText = "DELETE FROM Participe WHERE id_groupe = @idGroupe AND id_concert = @idConcert";
                        cmd.Parameters.AddWithValue("@idGroupe", idGroupe);
                        cmd.Parameters.AddWithValue("@idConcert", IdConcert);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur est survenue lors de la suppression du groupe : " + ex.Message, "Erreur");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas les droits pour effectuer cette action.", "Erreur");
                }
            }
        }
    }
}
