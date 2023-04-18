using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    /// <summary>
    /// Model pour les utilisateurs.
    /// </summary>
    public class UserModel
    {
        public int Id_user { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; } = false;

        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserModel(string email, string password, bool role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        public UserModel(string email, bool role)
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
        {
            Email = email;
            Role = role;
        }
    }
}
