using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    public class ReservationModel
    {
        public int IdUser { get; set; }
        public int IdConcert { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }


        public ReservationModel(int idUser, int idConcert, string name, string firstName, string phone)
        {
            IdUser = idUser;
            IdConcert = idConcert;
            Name = name;
            FirstName = firstName;
            Phone = phone;
        }

        public ReservationModel(int idUser, int idConcert)
        {
            IdUser = idUser;
            IdConcert = idConcert;
        }
    }
}
