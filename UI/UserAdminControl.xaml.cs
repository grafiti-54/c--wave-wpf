using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour UserAdminControl.xaml
    /// </summary>
    public partial class UserAdminControl : UserControl
    {
        public UserAdminControl()
        {
            InitializeComponent();
            users = new ObservableCollection<UserModel>();
            fetch_data();
        }

        /// <summary>
        /// ObservableCollection : collection spéciale en WPF qui notifie automatiquement la vue lorsque son contenu est modifié, permettant ainsi à la vue de se mettre à jour.
        /// </summary>
        private ObservableCollection<UserModel> users; // représente la liste des users à afficher dans la vue

        /// <summary>
        /// Lorsque la valeur de cette propriété est définie, le code met à jour la variable privée "users" avec la nouvelle valeur et déclenche l'événement "OnPropertyChanged". Cet événement est utilisé pour notifier à la vue que la collection de concerts a été mise à jour, afin qu'elle puisse afficher les changements appropriés.
        ///L'utilisation d'une ObservableCollection et de la notification de changement permet de mettre à jour la vue de manière réactive, en temps réel, chaque fois que la collection de groupes est modifiée.
        /// </summary>
        public ObservableCollection<UserModel> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }


        /// <summary>
        /// événement qui se déclenche lorsqu'une propriété est modifiée. Dans ce cas, il est utilisé pour signaler à la vue que la propriété Groupes a été mise à jour et qu'elle doit être rafraîchie.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode qui déclenche l'événement PropertyChanged chaque fois que la valeur de la propriété change. Cet événement est utilisé par la vue pour détecter les changements dans les propriétés du modèle de vue, afin de mettre à jour l'affichage.
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setTextBoxValues(string id, string email, bool role)
        {
            txt_id_user_admin.Text = id;
            txt_email_user_admin.Text = email;
            checkbox_is_admin.IsChecked = role;

        }

        /// <summary>
        /// Récupération des données des groupes pour afficher a l'administration.
        /// </summary>
        public void fetch_data()
        {

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //alias utilisé pour renomer les header de la datagrid
            //les alias doivent correspondre avec les binding dans le fichier xaml
            cmd.CommandText = "SELECT id_user as id, email as Email, role as Role FROM Users ORDER BY id_user desc";
            cmd.CommandType = CommandType.Text;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridUsersList.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Récupération des donnés pour la datagrid et pré rempli les champs du formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getDataFromRowDataGrid(object sender, SelectionChangedEventArgs e)
        {
            // Récupérer l'élément sélectionné dans la DataGrid
            DataRowView selectedRow = (DataRowView)datagridUsersList.SelectedItem;

            // Vérifier si une ligne a été sélectionnée            
            if (selectedRow != null)
            {
                int id = Convert.ToInt32(selectedRow["id"]);

                // Récupérer le rôle de l'utilisateur
                bool role = false;
                bool.TryParse(selectedRow["Role"].ToString(), out role);

                // Remplir les champs de texte avec les valeurs sélectionnées
                setTextBoxValues(id.ToString(), selectedRow["Email"].ToString(), role);

                // Ajouter l'utilisateur sélectionné à la liste existante
                UserModel selectedUser = new UserModel(selectedRow["Email"].ToString(), role);
                Users.Add(selectedUser);
            }
        }

        /// <summary>
        /// Vérification pour la supprésion d'un utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_user_btn_Click(object sender, RoutedEventArgs e)
        {
            bool? isAdmin = checkbox_is_admin.IsChecked;
            bool role = isAdmin.HasValue ? isAdmin.Value : false;
            UserModel user = new UserModel(txt_email_user_admin.Text.Trim(), role);

            if (Session.Role)
            {
                // Demande de confirmation de la modification
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'utilisateur ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.DeleteUser(user);
                        datagridUsersList.ItemsSource = null;
                        checkbox_is_admin.IsChecked = false;
                        txt_email_user_admin.Text = "";

                        fetch_data();
                        MessageBox.Show("L'utilisateur est supprimé. \n", "Information");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la suppression. \n" + ex.Message, "Erreur");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas les droits pour effectuer cette action.", "Erreur");
                }
            }

        }
        /// <summary>
        /// Vérification pour la modification du role d'un utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_role_user_btn_Click(object sender, RoutedEventArgs e)
        {
            bool? isAdmin = checkbox_is_admin.IsChecked;
            bool role = isAdmin.HasValue ? isAdmin.Value : false;
            UserModel user = new UserModel(txt_email_user_admin.Text.Trim(), role);

            if (Session.Role)
            {
                // Demande de confirmation de la modification
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le role de l'utilisateur ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.UpdateUser(user);
                        datagridUsersList.ItemsSource = null;
                        checkbox_is_admin.IsChecked = false;
                        txt_email_user_admin.Text = "";

                        fetch_data();
                        MessageBox.Show("Le role de l'utilisateur est modifié. \n", "Information");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la modification. \n" + ex.Message, "Erreur");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vous n'avez pas les droits pour effectuer cette action.", "Erreur");
                }
            }
        }

        /// <summary>
        /// Recherche dans la liste des utilisateurs pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchUserAdmin(object sender, TextChangedEventArgs e)
        {
            string searchTerm = (sender as TextBox).Text.Trim();

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //remettre les memes alias que pour fetch data sinon beug au moment de la recherche
            cmd.CommandText = "SELECT id_user as id, email as Email, role as Role FROM Users WHERE email LIKE @searchTerm ORDER BY id_user desc";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridUsersList.ItemsSource = dt.DefaultView;
        }

    }
}
