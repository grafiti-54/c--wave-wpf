using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    public class ParticipeModel
    {
        public int IdGroupe { get; set; }
        public int IdConcert { get; set; }

        //public ParticipeModel() { }

        public ParticipeModel()
        {
        }

        public ParticipeModel(int idGroupe, int idConcert)
        {
            IdGroupe = idGroupe;
            IdConcert = idConcert;
        }
    }
}
