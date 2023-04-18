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
    /// Logique d'interaction pour OeuvreAdminDashboardControl.xaml
    /// </summary>
    public partial class OeuvreAdminDashboardControl : UserControl
    {
        public OeuvreAdminDashboardControl()
        {
            InitializeComponent();
            LoadDataIntoCombobox();
            Oeuvres = new ObservableCollection<OeuvreModel>();
            fetch_data();
        }

        /// <summary>
        /// ObservableCollection : collection spéciale en WPF qui notifie automatiquement la vue lorsque son contenu est modifié, permettant ainsi à la vue de se mettre à jour.
        /// </summary>
        private ObservableCollection<OeuvreModel> oeuvres; // représente la liste des oeuvres à afficher dans la vue

        /// <summary>
        /// Lorsque la valeur de cette propriété est définie, le code met à jour la variable privée "oeuvre" avec la nouvelle valeur et déclenche l'événement "OnPropertyChanged". Cet événement est utilisé pour notifier à la vue que la collection de concerts a été mise à jour, afin qu'elle puisse afficher les changements appropriés.
        ///L'utilisation d'une ObservableCollection et de la notification de changement permet de mettre à jour la vue de manière réactive, en temps réel, chaque fois que la collection de oeuvre est modifiée.
        /// </summary>
        public ObservableCollection<OeuvreModel> Oeuvres
        {
            get { return oeuvres; }
            set
            {
                oeuvres = value;
                OnPropertyChanged("Oeuvres");
            }
        }

        /// <summary>
        /// événement qui se déclenche lorsqu'une propriété est modifiée. Dans ce cas, il est utilisé pour signaler à la vue que la propriété Oeuvre a été mise à jour et qu'elle doit être rafraîchie.
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
        /// Fonction de remise à 0 des champs du formulaire utilisé lors des différentes fonctions.
        /// </summary>
        private void reset_input()
        {
            txt_title_oeuvre.Text = "";
            txt_duree_oeuvre.Text = "";
            comboboxAddGroupe.SelectedIndex = -1;
        }

        /// <summary>
        /// Récupération des oeuvres pour l'affichage dans la datagrid.
        /// </summary>
        public void fetch_data()
        {
            SQLiteConnection con = DbApp.GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            //alias utilisé pour les binding
            //ne pas oublier AutoGenerateColumns="False" dans le fichier xaml
            cmd.CommandText = "SELECT id_oeuvre as Id, title as Title, duration as Duration, id_groupe as IdGroupe" +
                " FROM Oeuvres ORDER BY id_oeuvre desc";
            cmd.CommandType = CommandType.Text;
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagridOeuvreListe.ItemsSource = dt.DefaultView;
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
        ///Validation de l'ajout d'une oeuvre pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_oeuvre_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            //Récupération de l'id du groupe selectionné de la combobox
            GroupeModel selectedGroupe = (GroupeModel)comboboxAddGroupe.SelectedItem;
            int selectedGroupId = selectedGroupe.Id;

            OeuvreModel oeuvre = new OeuvreModel
                (
                txt_title_oeuvre.Text.Trim(),
                txt_duree_oeuvre.Text.Trim(),
                Session.Id,
                selectedGroupId
                ) ;

            if (Session.Role)
            {
                try
                {
                    DbApp.AddOeuvre(oeuvre);
                    datagridOeuvreListe.ItemsSource = null;
                    reset_input();
                    fetch_data();
                    MessageBox.Show("L'oeuvre est ajouté. \n", "Information");
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
        ///Validation de la modification d'une oeuvre pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_oeuvre_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            //Récupération de l'id du groupe selectionné de la combobox
            GroupeModel selectedGroupe = (GroupeModel)comboboxAddGroupe.SelectedItem;
            int selectedGroupId = selectedGroupe.Id;

            int idOeuvre = Int32.Parse(txt_id_oeuvre.Text);

            OeuvreModel oeuvre = new OeuvreModel
                (
                idOeuvre,
                txt_title_oeuvre.Text.Trim(),
                txt_duree_oeuvre.Text.Trim(),
                Session.Id,
                selectedGroupId
                );

            // Demande de confirmation
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier l'oeuvre ?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DbApp.UpdateOeuvre(oeuvre);
                    datagridOeuvreListe.ItemsSource = null;
                    reset_input();
                    fetch_data();
                    MessageBox.Show("L'oeuvre est modifié. \n", "Information");
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

        /// <summary>
        ///Validation pour la suppression d'une oeuvre pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_oeuvre_admin_btn_Click(object sender, RoutedEventArgs e)
        {
            
            OeuvreModel oeuvre = new OeuvreModel(txt_title_oeuvre.Text.Trim());
            if (Session.Role)
            {
                
                // Demande de confirmation
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer l'oeuvre ?",
                    "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DbApp.DeleteOeuvre(oeuvre);
                        datagridOeuvreListe.ItemsSource = null;
                        reset_input();
                        fetch_data();
                        MessageBox.Show("L'oeuvre est supprimé. \n", "Information");
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
        /// Méthode utilisé pour pré-remplir les champs des formulaires lors d'une selection dans la datagrid.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="duree"></param>
        private void setTextBoxValues(string id, string title, string duree)
        {
            txt_id_oeuvre.Text = id;
            txt_title_oeuvre.Text = title;
            txt_duree_oeuvre.Text = duree;

        }

        /// <summary>
        /// Récupération des données pour la datagrid et pré rempli les champs du formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getDataFromRowDataGrid(object sender, SelectionChangedEventArgs e)
        {
            // Récupérer l'élément sélectionné dans la DataGrid
            DataRowView selectedRow = (DataRowView)datagridOeuvreListe.SelectedItem;

            // Vérifier si une ligne a été sélectionnée            
            if (selectedRow != null)
            {
                int id = Convert.ToInt32(selectedRow["Id"]);
                int idGroupe = Convert.ToInt32(selectedRow["IdGroupe"]);

                OeuvreModel selectedOeuvre = new OeuvreModel(
                    id,
                    selectedRow["Title"].ToString(),
                    selectedRow["Duration"].ToString(),
                    idGroupe
                );
                //Pré remplir les champs du formulaire avec les élèments selectionnés dans la datagrid.
                Oeuvres = new ObservableCollection<OeuvreModel>() { selectedOeuvre };
                setTextBoxValues(id.ToString(), selectedRow["Title"].ToString(), selectedRow["Duration"].ToString());

                // Pré-remplir la combobox avec l'ID du groupe correspondant
                comboboxAddGroupe.SelectedValue = idGroupe;
            }
        }
        

        /// <summary>
        /// Champs de recherche des oeuvres pour l'administration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchOeuvreAdmin(object sender, TextChangedEventArgs e)
        {
            string searchTerm = (sender as TextBox).Text.Trim();
            string sql = "SELECT id_oeuvre as Id, title as Title, duration as Duration, id_groupe as IdGroupe FROM Oeuvres WHERE title LIKE @searchTerm ORDER BY id_oeuvre desc";

            using (SQLiteConnection con = DbApp.GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    //Cette méthode ajoute le paramètre en toute sécurité, en s'assurant que les caractères spéciaux dans la valeur sont correctement échappés
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        datagridOeuvreListe.ItemsSource = dt.DefaultView;
                    }
                }
            }
        }
    }
}
