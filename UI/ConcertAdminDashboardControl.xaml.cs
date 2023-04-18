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
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Contexts;
using System.ComponentModel;
using WaveWpf.Models;
using System.Text.RegularExpressions;

namespace WaveWpf.UI
{
    /// <summary>
    /// Logique d'interaction pour ConcertAdminDashboardControl.xaml. Page du crud pour les concerts réservé à l'administration.
    /// </summary>
    public partial class ConcertAdminDashboardControl : UserControl
    {
        public ConcertAdminDashboardControl()
        {
            InitializeComponent();
            LoadDataIntoCombobox();
            Concerts = new ObservableCollection<ConcertModel>();
            fetch_data();
        }

        /// <summary>
        /// ObservableCollection : collection spéciale en WPF qui notifie automatiquement la vue lorsque son contenu est modifié, permettant ainsi à la vue de se mettre à jour.
        /// </summary>
        private ObservableCollection<ConcertModel> concerts; // représente la liste des concerts à afficher dans la vue
        
        /// <summary>
        /// Lorsque la valeur de cette propriété est définie, le code met à jour la variable privée "concerts" avec la nouvelle valeur et déclenche l'événement "OnPropertyChanged". Cet événement est utilisé pour notifier à la vue que la collection de concerts a été mise à jour, afin qu'elle puisse afficher les changements appropriés.
        ///L'utilisation d'une ObservableCollection et de la notification de changement permet de mettre à jour la vue de manière réactive, en temps réel, chaque fois que la collection de concerts est modifiée.
        /// </summary>
        public ObservableCollection<ConcertModel> Concerts
        {
            get { return concerts; }
            set
            {
                concerts = value;
                OnPropertyChanged("Concerts");
            }
        }

        /// <summary>
        /// événement qui se déclenche lorsqu'une propriété est modifiée. Dans ce cas, il est utilisé pour signaler à la vue que la propriété Concerts a été mise à jour et qu'elle doit être rafraîchie.
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
        /// Récupération des données des concerts pour afficher a ladministration.
        /// </summary>
        public void fetch_data()
        {

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //alias utilisé pour renomer les header de la datagrid
            cmd.CommandText = "SELECT id_concert as id, jour as Date, address as Lieu FROM Concerts ORDER BY id_concert desc";
            cmd.CommandType = CommandType.Text;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridConcertAdmin.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Fonction de remise à 0 des champs du formulaire utilisé lors des différentes fonctions.
        /// </summary>
        private void reset_input()
        {
            txt_address_concert.Text = "";
            txt_date_concert.Text = "";
        }

        /// <summary>
        /// Pré rempli les champs du formulaire lors du clic sur la row de la datagrid.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="address"></param>
        private void setTextBoxValues(string id ,string date, string address)
        {
            txt_id_concert.Text = id;
            txt_date_concert.Text = date;
            txt_address_concert.Text = address;
        }

        /// <summary>
        /// Recherche dans la liste des concerts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchConcertAdmin(object sender, TextChangedEventArgs e)
        {
            string searchTerm = (sender as TextBox).Text.Trim();

            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //utilisé les memes alias utilisé dans le fetch pour eviter les erreurs
            cmd.CommandText = "SELECT id_concert as id, jour as Date, address as Lieu FROM Concerts WHERE jour LIKE @searchTerm OR address LIKE @searchTerm ORDER BY id_concert desc";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridConcertAdmin.ItemsSource = dt.DefaultView;           
        }

        /// <summary>
        /// Récupération des donnés pour la datagrid et pré rempli les champs du formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getDataFromRowDataGrid(object sender, SelectionChangedEventArgs e)
        {
            // Récupérer l'élément sélectionné dans la DataGrid
            DataRowView selectedRow = (DataRowView)datagridConcertAdmin.SelectedItem;
            /*
            if (selectedRow != null)
            {
                string id = selectedRow["id"].ToString();
                string jour = selectedRow["Date"].ToString();
                string address = selectedRow["Lieu"].ToString();

                string message = $"ID: {id}\nJour: {jour}\nAddress: {address}";
                MessageBox.Show(message, "Détail du concert sélectionné");
            }
            else
            {
                MessageBox.Show("Aucun concert sélectionné", "Erreur");
            }
            */

            // Vérifier si une ligne a été sélectionnée            
            if (selectedRow != null)
            {

                int id = Convert.ToInt32(selectedRow["id"]);
                // Créer un nouvel objet ConcertModel avec les données de la ligne sélectionnée
                ConcertModel selectedConcert = new ConcertModel(
                    id,
                    selectedRow["Date"].ToString(),
                    selectedRow["Lieu"].ToString()
                    );

                // Ajouter l'objet ConcertModel à la liste Concerts
                Concerts = new ObservableCollection<ConcertModel> { selectedConcert };
                //MessageBox.Show($"ID: {selectedConcert.Id}\nDate: {selectedConcert.Day}\nLieu: {selectedConcert.Address}", "Informations sélectionnées");
                // Remplir les champs de texte avec les valeurs sélectionnées
                setTextBoxValues(id.ToString(), selectedRow["Date"].ToString(), selectedRow["Lieu"].ToString());
            }
        }
        
        /// <summary>
        /// Récupération de la liste des groupes pour l'affichage dans la combobox.
        /// </summary>
        private void LoadDataIntoCombobox()
        {
            // Récupérer la liste des groupes depuis la base de données
            List<GroupeModel> groupes = new List<GroupeModel>();
            foreach (var groupe in DbApp.GetAllGroupe())
            {
                GroupeModel model = new GroupeModel(groupe.Id, groupe.Name);
                groupes.Add(model);
            }

            // Assigner la liste de groupes à la propriété ItemsSource de la combobox
            comboboxAddGroupe.ItemsSource = groupes;
            // Définir le membre à afficher comme le nom des groupes
            comboboxAddGroupe.DisplayMemberPath = "Name";
            // Définir le membre à utiliser comme valeur sélectionnée comme l'ID des groupes
            comboboxAddGroupe.SelectedValuePath = "Id";
        }

        /// <summary>
        /// Vérification pour l'ajout d'un concert pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_concert_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            //txt_address_concert
            //txt_date_concert
            ConcertModel concert = new ConcertModel
                (
                txt_date_concert.Text.Trim(),
                txt_address_concert.Text.Trim(),
                Session.Id
                );

            if (Session.Role)
            {
                try
                {
                    DbApp.AddConcert(concert);
                    datagridConcertAdmin.ItemsSource = null;
                    reset_input();
                    fetch_data();
                    MessageBox.Show("Le concert est ajouté. \n", "Information");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout du concert. \n" + ex.Message, "Erreur");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas les droits pour effectuer cette action.");
            }
        }

        /// <summary>
        /// Vérification pour la modification d'un concert pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_concert_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            int id_concert = int.Parse(txt_id_concert.Text.Trim());
            int user_id = Session.Id;
            ConcertModel concert = new ConcertModel
                (
                id_concert,
                txt_date_concert.Text.Trim(),
                txt_address_concert.Text.Trim(),
                user_id
                );
            //Vérification si l'user connecté est un admin.
            if (Session.Role)
            {
                // Demande de confirmation de la suppression
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le concert ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.UpdateConcertById(concert);
                        datagridConcertAdmin.ItemsSource = null;
                        reset_input();
                        fetch_data();
                        MessageBox.Show("Le concert est modifié. \n", "Information");
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
        /// Vérification pour la suppression d'un concert pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_concert_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            //int id_concert = int.Parse(txt_id_concert.Text.Trim());
            ConcertModel concert = new ConcertModel(int.Parse(txt_id_concert.Text.Trim()));
            if (Session.Role)
            {
                // Demande de confirmation de la suppression
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le concert ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.DeleteConcertById(concert);
                        datagridConcertAdmin.ItemsSource = null;
                        reset_input();
                        fetch_data();
                        MessageBox.Show("Le concert est supprimé. \n", "Information");
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
        /// /// <summary>
        /// Vérification pour l'ajout d'un groupe à un concert pour l'administration.
        /// </summary>
        private void add_groupe_concert_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            // Récupération de l'id selectionné dans la combobox
            //GroupeModel selectedGroupe = groupes.Find(match: g => g.Name == comboBox2.SelectedItem.ToString());
            //int selectedGroupId = selectedGroupe.Id;

            GroupeModel selectedGroupe = (GroupeModel)comboboxAddGroupe.SelectedItem;
            int selectedGroupId = selectedGroupe.Id;

            //int id_concert = int.Parse(txt_id_concert.Text.Trim());
            int id_concert;
            if (!int.TryParse(txt_id_concert.Text.Trim(), out id_concert))
            {
                MessageBox.Show("Merci de selectionner un concert dans la liste. \n", "Erreur");
                return;
            }

            ParticipeModel participe = new ParticipeModel
                (
                selectedGroupId,
                id_concert
                );
            if (Session.Role)
            {

                try
                {
                    DbApp.AddParticipation(participe);
                    datagridConcertAdmin.ItemsSource = null;
                    reset_input();
                    fetch_data();
                    MessageBox.Show("Le groupe est inscrit au concert. \n", "Information");
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
        /// Affiche le detail du concert dans une autre fenetre pour l'administration afin de modifier les groupes participants.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Detail_Concert_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer l'élément sélectionné dans la DataGrid
            DataRowView selectedRow = (DataRowView)datagridConcertAdmin.SelectedItem;

            // Vérifier si une ligne a été sélectionnée
            if (selectedRow != null)
            {
                // Récupérer l'ID du concert sélectionné
                int id_concert;
                if (!int.TryParse(selectedRow["id"].ToString(), out id_concert))
                {
                    MessageBox.Show("Erreur lors de la récupération de l'ID du concert.", "Erreur");
                    return;
                }

                // Ouvrir la fenêtre de détails du concert et transmettre l'ID en paramètre
                DetailConcertAdminPopup detailConcertAdminPopup = new DetailConcertAdminPopup(id_concert);
                detailConcertAdminPopup.ShowDialog();
            }
        }
    }
}
