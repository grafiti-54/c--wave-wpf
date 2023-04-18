using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WaveWpf.Models;

namespace WaveWpf.UI
{
    /// <summary>
    /// Logique d'interaction pour AccueilControl.xaml, page d'ccueil lors de l'ouverture de l'app.
    /// </summary>
    public partial class AccueilControl : UserControl
    {

        private List<ConcertModel> concerts;
        public AccueilControl()
        {
            InitializeComponent();
            //DbApp.Create_db();
            LoadConcerts();          
        }

        /// <summary>
        /// Récupération de la liste des concerts à afficher sur la page d'accueil du site.
        /// </summary>
        private void LoadConcerts()
        {
            // Récupérer les données de la base de données
            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT c.jour, c.address, g.name, c.id_concert\r\nFROM Concerts c\r\nINNER JOIN Participe p ON p.id_concert = c.id_concert\r\nINNER JOIN Groupes g ON g.id_groupe = p.id_groupe\r\nORDER BY c.jour DESC";

            concerts = new List<ConcertModel>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(3); // Récupérer l'id du concert sans l'afficher pour la transmettre pour la reservation =>  ReserveButton_Click()
                    string jour = reader.GetString(0);
                    string address = reader.GetString(1);
                    string name = reader.GetString(2);

                    concerts.Add(new ConcertModel { Id = id, Name = name, Address = address, Day = jour });
                }
                // Lier les données a chaque card
                cardConcert.ItemsSource = concerts;
            }
        }

        /// <summary>
        /// Champ de recherche pour l'utilisateur afin de rechercher un concert sur la page d'accueil du site.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_recherche_accueil_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchString = txt_recherche_accueil.Text.ToLower();
            List<ConcertModel> filteredConcerts = concerts.Where(c => c.Name.ToLower().Contains(searchString)).ToList();
            cardConcert.ItemsSource = filteredConcerts;
        }

        /// <summary>
        /// Redirection vers le formulaire de réservation du concert choisi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            ContentControl contentControl = (ContentControl)Application.Current.MainWindow.FindName("ContentControl");

            if (!string.IsNullOrEmpty(Session.Email))
            {

                // Récupérer le concert sélectionné
                var concert = ((Button)sender).DataContext as ConcertModel;
                //ReservationPopup reservationPopup = new ReservationPopup();

                ReservationPopup reservationPopup = new ReservationPopup(concert.Name, concert.Id);
                reservationPopup.ShowDialog();

            }
            else
            {
                // Utilisateur non connecté, rediriger vers la page de connexion
                ConnexionControl connexionControl = new ConnexionControl();
                contentControl.Content = connexionControl;
            }
        }
    }
}
