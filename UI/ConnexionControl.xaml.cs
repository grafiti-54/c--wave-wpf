using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logique d'interaction pour ConnexionControl.xaml
    /// </summary>
    public partial class ConnexionControl : UserControl
    {
        public ConnexionControl()
        {
            InitializeComponent();
        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            UserModel user = new UserModel(txt_email.Text.Trim(), txt_password.Password.Trim());
            bool role = DbApp.GetUserRole(txt_email.Text.Trim());
            int id = DbApp.GetUserId(txt_email.Text.Trim());

            if (DbApp.LoginUser(user))
            {
                Session.Id = id;
                Session.Email = user.Email;
                Session.Role = role;
                //Cacher les bouton inscritpion et connexion et
                MessageBox.Show("Bienvenue " + Session.Email + "!", "Information");

                // Rafraîchir la fenêtre principale
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur");
            }
        }
    }
}
