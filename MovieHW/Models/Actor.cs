using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{

    //Színészhez kapcsolódó osztályok
    public class Actor
    {
        public string birthday { get; set; }
        public string known_for_department { get; set; }
        public object deathday { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<string> also_known_as { get; set; }
        public int gender { get; set; }
        public string biography { get; set; }
        public double popularity { get; set; }
        public string place_of_birth { get; set; }
        public string profile_path
        {
            get
            { return profilPicture; }
            set { profilPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string profilPicture;
        public bool adult { get; set; }
        public string imdb_id { get; set; }
        public object homepage { get; set; }
    }
}
