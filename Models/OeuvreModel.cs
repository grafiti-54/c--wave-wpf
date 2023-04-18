using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveWpf.Models
{
    public class OeuvreModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public int UserId { get; set; }
        public int GroupeId { get; set; }

        public OeuvreModel() { }

        public OeuvreModel(int id, string title, string duration, int userId, int groupeId)
        {
            Id = id;
            Title = title;
            Duration = duration;
            UserId = userId;
            GroupeId = groupeId;
        }

        public OeuvreModel(int id, string title, string duration, int groupeId)
        {
            Id = id;
            Title = title;
            Duration = duration;
            GroupeId = groupeId;
        }

        public OeuvreModel(string title, string duration, int userId, int groupeId)
        {
            Title = title;
            Duration = duration;
            UserId = userId;
            GroupeId = groupeId;
        }

        public OeuvreModel(string title)
        {
            Title = title;
        }

        public OeuvreModel(string title, string duration)
        {
            Title = title;
            Duration = duration;
        }
    }
}
