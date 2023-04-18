using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
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
using WaveWpf.UI;

namespace WaveWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            //DbApp.Create_db();
            CheckLogin();
            CheckAdmin();

        }

        /*
        private void loadHomePage(object sender, RoutedEventArgs e)
        {
            DbApp.Create_db();
            
        }
        */

        /// <summary>
        /// Chargement par defaut au chargement de l'app de ConnexionControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new AccueilControl(); // Afficher AccueilControl par défaut
        }

        /// <summary>
        /// Vérification si l'user est connecté.
        /// </summary>
        public void CheckLogin()
        {
            if (Session.Email == null)
            {
                Reservation_btn.Visibility = Visibility.Collapsed;
                Connexion_btn.Visibility = Visibility.Visible;
                Inscription_btn.Visibility = Visibility.Visible;
            }
            else
            {
                Reservation_btn.Visibility = Visibility.Visible;
                Connexion_btn.Visibility = Visibility.Collapsed;
                Inscription_btn.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Vérification si l'user connecté est un admin.
        /// </summary>
        public void CheckAdmin()
        {
            if (!Session.Role) // Vérifie si l'utilisateur n'est pas un administrateur
            {
                Admin_btn.Visibility = Visibility.Collapsed; // Cacher le bouton "Admin"
                Submenu_admin_btn.Visibility = Visibility.Collapsed; // Cacher le panel contenant les boutons "Users", "Groupes", "Oeuvres" et "Concerts"
            }
        }

        /*
        /// <summary>
        /// Récupération des données des groupes pour remplir le datagrid.
        /// </summary>
        public void fetch_data()
        {
            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT * FROM Groupes ORDER BY id_groupe desc";
            cmd.CommandType = CommandType.Text;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridtest.ItemsSource = dt.DefaultView;
        }
        */


        /// <summary>
        /// Redirection vers la page de connexion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Connexion_Click(object sender, RoutedEventArgs e)
        {
            ConnexionControl connexionControl = new ConnexionControl();
            ContentControl.Content = connexionControl;
        }

        /// <summary>
        /// Redirection vers la page d'accueil de l'app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Accueil_Click(object sender, RoutedEventArgs e)
        {
            AccueilControl accueilControl = new AccueilControl();
            ContentControl.Content = accueilControl;
        }

        /// <summary>
        /// Redirection vers la page d'inscription de l'app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Inscription_Click(object sender, RoutedEventArgs e)
        {
            InscriptionControl inscriptionControl = new InscriptionControl();
            ContentControl.Content = inscriptionControl;
        }

        /// <summary>
        ///  Redirection vers la page qui résumé les réservation d'un utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Reservation_Click(object sender, RoutedEventArgs e)
        {
            MesReservationControl mesReservationControl = new MesReservationControl();
            ContentControl.Content = mesReservationControl;
        }

        /// <summary>
        /// Redirection vers la page de gestion des concerts pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ConcertsAdmin_Click(object sender, RoutedEventArgs e)
        {
            ConcertAdminDashboardControl concertAdminDashboardControl = new ConcertAdminDashboardControl();
            ContentControl.Content = concertAdminDashboardControl;
        }

        /// <summary>
        /// Redirection vers la page de gestion des groupes pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_GroupeAdmin_Click(object sender, RoutedEventArgs e)
        {
            GroupeAdminDashboard groupeAdminDashboardControl = new GroupeAdminDashboard();
            ContentControl.Content = groupeAdminDashboardControl;
        }
        
        /// <summary>
        /// Redirection vers la page de gestion des utilisateurs pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_User_List_Click(object sender, RoutedEventArgs e)
        {
            UserAdminControl userAdminControl = new UserAdminControl();
            ContentControl.Content = userAdminControl;
        }

        /// <summary>
        /// Affichage du bouton admin uniquement si le role de l'user connecté le permet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Admin_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Session.Role) // Vérifie si l'utilisateur est un administrateur
            {
                if (Submenu_admin_btn.Visibility == Visibility.Visible) // Vérifie si le menu est déjà visible
                {
                    Submenu_admin_btn.Visibility = Visibility.Hidden; // Cacher le menu
                }
                else
                {
                    Submenu_admin_btn.Visibility = Visibility.Visible; // Afficher le menu
                }
            }
        }

        
        /// <summary>
        /// Redirection vers la page de gestion des oeuvres pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OeuvreAdmin_Click(object sender, RoutedEventArgs e)
        {
            OeuvreAdminDashboardControl oeuvreAdminControl = new OeuvreAdminDashboardControl();
            ContentControl.Content = oeuvreAdminControl;
        }
    }
}
