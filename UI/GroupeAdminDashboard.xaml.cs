using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WaveWpf.Models;

namespace WaveWpf.UI
{
    /// <summary>
    /// Logique d'interaction pour GroupeAdminDashboard.xaml
    /// </summary>
    public partial class GroupeAdminDashboard : UserControl
    {
        public GroupeAdminDashboard()
        {
            InitializeComponent();
            fetch_data();
            groupes = new ObservableCollection<GroupeModel>(); // { new GroupeModel() }; // ou ()
        }

        /// <summary>
        /// ObservableCollection : collection spéciale en WPF qui notifie automatiquement la vue lorsque son contenu est modifié, permettant ainsi à la vue de se mettre à jour.
        /// </summary>
        private ObservableCollection<GroupeModel> groupes; // représente la liste des groupes à afficher dans la vue

        /// <summary>
        /// Lorsque la valeur de cette propriété est définie, le code met à jour la variable privée "groupes" avec la nouvelle valeur et déclenche l'événement "OnPropertyChanged". Cet événement est utilisé pour notifier à la vue que la collection de concerts a été mise à jour, afin qu'elle puisse afficher les changements appropriés.
        ///L'utilisation d'une ObservableCollection et de la notification de changement permet de mettre à jour la vue de manière réactive, en temps réel, chaque fois que la collection de groupes est modifiée.
        /// </summary>
        public ObservableCollection<GroupeModel> Groupes
        {
            get { return groupes; }
            set
            {
                groupes = value;
                OnPropertyChanged("Groupes");
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


        /// <summary>
        /// Récupération des données des groupes pour afficher a l'administration.
        /// </summary>
        public void fetch_data()
        {

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //alias utilisé pour renomer les header de la datagrid
            //les alias doivent correspondre avec les binding dans le fichier xaml
            cmd.CommandText = "SELECT id_groupe as id, name as Nom, address as Adresse, phone as Telephone FROM Groupes ORDER BY id_groupe desc";
            cmd.CommandType = CommandType.Text;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridGroupeAdmin.ItemsSource = dt.DefaultView;
        }


        /// <summary>
        /// Fonction de remise à 0 des champs du formulaire utilisé lors des différentes fonctions.
        /// </summary>
        private void reset_input()
        {
            txt_address_groupe.Text = string.Empty;
            txt_name_groupe.Text = string.Empty;
            txt_phone_groupe.Text = string.Empty;
        }

        /// <summary>
        /// Pré rempli les champs du formulaire lors du clic sur la row de la datagrid.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="address"></param>
        private void setTextBoxValues(string id, string name, string address, string phone)
        {
            txt_id_groupe.Text = id;
            txt_name_groupe.Text = name;
            txt_address_groupe.Text = address;
            txt_phone_groupe.Text = phone;
        }


        /// <summary>
        /// Recherche dans la liste des groupes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchGroupeAdmin(object sender, TextChangedEventArgs e)
        {
            string searchTerm = (sender as TextBox).Text.Trim();

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //remettre les memes que pour fetch data alias sinon beug
            cmd.CommandText = "SELECT id_groupe as id, name as Nom, address as Adresse, phone as Telephone FROM Groupes WHERE name LIKE @searchTerm OR address LIKE @searchTerm ORDER BY id_groupe desc";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridGroupeAdmin.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Récupération des donnés pour la datagrid et pré rempli les champs du formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getDataFromRowDataGrid(object sender, SelectionChangedEventArgs e)
        {
            // Récupérer l'élément sélectionné dans la DataGrid
            DataRowView selectedRow = (DataRowView)datagridGroupeAdmin.SelectedItem;
            // Vérifier si une ligne a été sélectionnée            
            if (selectedRow != null)
            {

                int id = Convert.ToInt32(selectedRow["id"]);
                // Créer un nouvel objet GroupeModel avec les données de la ligne sélectionnée
                GroupeModel selectedGroupe = new GroupeModel(
                    id,
                    selectedRow["Nom"].ToString(),
                    selectedRow["Adresse"].ToString(),
                    selectedRow["Telephone"].ToString()
                    );

                // Ajouter l'objet GroupeModel à la liste Groupes
                Groupes = new ObservableCollection<GroupeModel> { selectedGroupe };
                
                // Remplir les champs de texte avec les valeurs sélectionnées
                setTextBoxValues(id.ToString(), selectedRow["Nom"].ToString(), selectedRow["Adresse"].ToString(), selectedRow["Telephone"].ToString());
            }
        }

        /// <summary>
        /// Vérification pour l'ajout d'un groupe pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_groupe_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            GroupeModel groupe = new GroupeModel
                (
                txt_name_groupe.Text.Trim(),
                txt_address_groupe.Text.Trim(),
                txt_phone_groupe.Text.Trim(),
                Session.Id
                );

            //Vérification si l'user connecté est un admin.
            if (Session.Role)
            {
                try
                {
                    DbApp.AddGroupe(groupe);
                    datagridGroupeAdmin.ItemsSource = null;
                    reset_input();
                    fetch_data();
                    MessageBox.Show("Le groupe est ajouté. \n", "Information");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout du groupe. \n" + ex.Message, "Erreur");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas les droits pour effectuer cette action.");
            }
        }

        /// <summary>
        /// Vérification pour la modification d'un groupe pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_groupe_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            int id_groupe = int.Parse(txt_id_groupe.Text.Trim());
            GroupeModel groupe = new GroupeModel
                (
                id_groupe,
                txt_name_groupe.Text.Trim(),
                txt_address_groupe.Text.Trim(),
                txt_phone_groupe.Text.Trim(),
                Session.Id
                );
            //Vérification si l'user connecté est un admin.
            if (Session.Role)
            {
                // Demande de confirmation de la suppression
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le groupe ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.UpdateGroupe(groupe);
                        datagridGroupeAdmin.ItemsSource = null;
                        reset_input();
                        fetch_data();
                        MessageBox.Show("Le groupe est modifié. \n", "Information");
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
        /// Vérification pour la suppression d'un groupe pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_groupe_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            GroupeModel groupe = new GroupeModel(txt_name_groupe.Text.Trim());
            if (Session.Role)
            {
                // Demande de confirmation de la suppression
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le groupe ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.DeleteGroupe(groupe);
                        datagridGroupeAdmin.ItemsSource = null;
                        reset_input();
                        fetch_data();
                        MessageBox.Show("Le groupe est supprimé. \n", "Information");
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
        /// Affiche la liste des oeuvres du groupe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Detail_Groupe_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer l'élément sélectionné dans la DataGrid
            DataRowView selectedRow = (DataRowView)datagridGroupeAdmin.SelectedItem;

            // Vérifier si une ligne a été sélectionnée
            if (selectedRow != null)
            {
                // Récupérer l'ID du groupe sélectionné
                int id_groupe;
                if (!int.TryParse(selectedRow["id"].ToString(), out id_groupe))
                {
                    MessageBox.Show("Erreur lors de la récupération de l'ID du groupe.", "Erreur");
                    return;
                }
                string nom_groupe = selectedRow["Nom"].ToString();

                // Ouvrir la fenêtre de détails du groupe et transmettre l'ID en paramètre
                ListeOeuvreGroupePopup listeOeuvreGroupePopup = new ListeOeuvreGroupePopup(id_groupe, nom_groupe);
                listeOeuvreGroupePopup.ShowDialog();
            }

        }
    }
}
