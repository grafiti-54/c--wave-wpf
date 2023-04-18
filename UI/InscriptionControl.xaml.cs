using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour InscriptionControl.xaml
    /// </summary>
    public partial class InscriptionControl : UserControl
    {
        public InscriptionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vérification du format de l'adresse email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        private void btn_inscription_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Adresse email invalide.", "Erreur");
                return;
            }
            try
            {
                UserModel user = new UserModel(txt_email.Text.Trim(), txt_password.Password.Trim());
                DbApp.RegisterUser(user);
                //new Connexion().Show();
                //this.Hide();
                MessageBox.Show("Inscription réussi. Vous pouvez vous connecter. \n", "Information");
            }
            catch
            {
                MessageBox.Show("Erreur lors de votre inscription.", "Erreur");
            }
        }


    }
}
