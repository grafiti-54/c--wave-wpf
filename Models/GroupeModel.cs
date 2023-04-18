using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    public class GroupeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

        // Constructeur par défaut
        public GroupeModel()
        {
        }

        // Constructeur avec paramètres
        public GroupeModel(string name, string address, string phone, int userId)
        {
            Name = name;
            Address = address;
            Phone = phone;
            UserId = userId;
        }

        public GroupeModel(int id, string name, string address, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }

        public GroupeModel(int id, string name, string address, string phone, int userId)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            UserId = userId;
        }

        public GroupeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public GroupeModel(string name)
        {
            Name = name;
        }
    }
}
