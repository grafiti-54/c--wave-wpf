using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WaveWpf.Models;

namespace WaveWpf.UI
{
    /// <summary>
    /// Logique d'interaction pour MesReservationControl.xaml
    /// 
    /// 
    /// </summary>
    public partial class MesReservationControl : UserControl
    {
        public MesReservationControl()
        {
            InitializeComponent();
            fetch_data();
            label_user_email.Content = Session.Email;
            Reservations = new ObservableCollection<MesReservationModel>();
        }


        /// <summary>
        /// ObservableCollection : collection spéciale en WPF qui notifie automatiquement la vue lorsque son contenu est modifié, permettant ainsi à la vue de se mettre à jour.
        /// </summary>
        private ObservableCollection<MesReservationModel> reservations;

        /// <summary>
        /// Lorsque la valeur de cette propriété est définie, le code met à jour la variable privée "reservations" avec la nouvelle valeur et déclenche l'événement "OnPropertyChanged". Cet événement est utilisé pour notifier à la vue que la collection de concerts a été mise à jour, afin qu'elle puisse afficher les changements appropriés.
        ///L'utilisation d'une ObservableCollection et de la notification de changement permet de mettre à jour la vue de manière réactive, en temps réel, chaque fois que la collection de reservation est modifiée.
        /// </summary>
        public ObservableCollection<MesReservationModel> Reservations
        {
            get { return reservations; }
            set
            {
                reservations = value;
                OnPropertyChanged("Reservations");
            }
        }

        /// <summary>
        /// événement qui se déclenche lorsqu'une propriété est modifiée. Dans ce cas, il est utilisé pour signaler à la vue que la propriété Reservations a été mise à jour et qu'elle doit être rafraîchie.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui déclenche l'événement PropertyChanged chaque fois que la valeur de la propriété change. Cet événement est utilisé par la vue pour détecter les changements dans les propriétés du modèle de vue, afin de mettre à jour l'affichage.
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Récupération des données de réservation d'un utilisateur pour l'affichage dans la datagrid.
        /// </summary>
        public void fetch_data()
        {
            using (SQLiteConnection con = DbApp.GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(con))
                {
                    //alias utilisé pour les binding
                    //ne pas oublier AutoGenerateColumns="False" dans le fichier xaml
                    cmd.CommandText = "SELECT Groupes.name AS NomGroupe, Concerts.jour AS Jour, Concerts.address AS Adresse, Concerts.id_concert As Id " +
                              "FROM Reserve " +
                              "INNER JOIN Concerts ON Reserve.id_concert = Concerts.id_concert " +
                              "INNER JOIN Groupes ON Groupes.id_groupe = Concerts.id_user " +
                              "WHERE Reserve.id_user = @IdUser";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@IdUser", DbType.Int64).Value = Session.Id;
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count == 0) // si le DataTable est vide, afficher un message personnalisé
                        {
                            datagridMesReservation.Visibility = Visibility.Collapsed;
                            label_user_message.Visibility = Visibility.Visible;
                        }
                        else // sinon, afficher les données dans le DataGrid
                        {
                            datagridMesReservation.ItemsSource = dt.DefaultView;
                        }
                    }
                }
                CloseConnection(con);
            }
        }

        public void CloseConnection(SQLiteConnection con)
        {
            if (con != null && con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }

        /// <summary>
        /// Annulation d'une réservation à un concert pour un utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Annuler_Reservation_Click(object sender, RoutedEventArgs e)
        {
            //Récupération de l'id du concert passé en paramètre dans le bouton
            Button button = sender as Button;
            int reservationId = (int)(long)button.CommandParameter;

            // Retirer le groupe de la base de données et mettre à jour le DataGrid
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir annuler votre réservation ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (Session.Role)
            {
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        SQLiteConnection con = DbApp.GetConnection();
                        SQLiteCommand cmd = new SQLiteCommand(con);
                        cmd.CommandText = "DELETE FROM Reserve WHERE id_user = @IdUser AND id_concert = @ReservationId";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IdUser", DbType.Int64).Value = Session.Id;
                        cmd.Parameters.Add("@ReservationId", DbType.Int64).Value = reservationId;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        
                        if (result > 0)
                        {
                            MessageBox.Show($"Réservation annulée avec succès !");
                            fetch_data();

                        }
                        else
                        {
                            MessageBox.Show($"Impossible d'annuler la réservation !");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur s'est produite lors de l'annulation de la réservation : {ex.Message}");
                    }
                }
            }
        }
    }
}


