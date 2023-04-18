using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    public class ConcertModel
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public ConcertModel() { }

        public ConcertModel(int id, string day, string address)
        {
            Id = id;
            Day = day;
            Address = address;
        }

        public ConcertModel(int id, string day, string address, int userId)
        {
            Id = id;
            Day = day;
            Address = address;
            UserId = userId;
        }

        public ConcertModel(string day, string address, int userId)
        {
            Day = day;
            Address = address;
            UserId = userId;
        }

        public ConcertModel(string day, string address)
        {
            Day = day;
            Address = address;
       
        }

        public ConcertModel(int id) => Id = id;
    }
}
