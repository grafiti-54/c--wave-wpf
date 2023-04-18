using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour ReservationPopup.xaml
    /// </summary>
    public partial class ReservationPopup : Window
    {
        public ReservationPopup(string concertName, int concertId)
        {
            InitializeComponent();
            // affecter les valeurs aux labels correspondants
            ConcertNameLabel.Content = concertName;
            ConcertIdLabel.Content = concertId;
        }

        private void reset_input()
        {
            txt_nom.Text = "";
            txt_prenom.Text = "";
            txt_phone.Text = "";
        }

        /// <summary>
        /// Validation pour la réservation d'un concert de l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reservation_Click(object sender, RoutedEventArgs e)
        {
            int concertId = Convert.ToInt32(ConcertIdLabel.Content);
            ReservationModel reservation = new ReservationModel
                (
                Session.Id,
                concertId,
                txt_nom.Text.Trim(),
                txt_prenom.Text.Trim(),
                txt_phone.Text.Trim()
                );
            if (Session.Id != 0)
            {
                try
                {
                    DbApp.AddReservation(reservation);
                    this.Close();
                    reset_input();
                    MessageBox.Show("Votre réservation est enregistré. \n", "Information");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de votre réservation. \n" + ex.Message, "Erreur");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas les droits pour effectuer cette action.");
            }
        }
    }
}
