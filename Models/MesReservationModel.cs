using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    public class MesReservationModel
    {
        public int IdUser { get; set; }
        public string NomGroupe { get; set; }
        public string DateConcert { get; set; }
        public string AdresseConcert { get; set; }


        public MesReservationModel(int idUser, string nomGroupe, string dateConcert, string adresseConcert)
        {
            IdUser = idUser;
            NomGroupe = nomGroupe;
            DateConcert = dateConcert;
            AdresseConcert = adresseConcert;
        }
    }
}
