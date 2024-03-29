﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{

    //Filmhez tartozó emberek osztályai
    public class Cast
    {
        public int cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string profile_path
        {
            get
            { return profilePath; }
            set { profilePath = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string profilePath;
    }

    public class Crew
    {
        public string credit_id { get; set; }
        public string department { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string job { get; set; }
        public string name { get; set; }
        public string profile_path
        {
            get
            { return profilePath; }
            set { profilePath = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string profilePath;
    }

    public class MoviePeople
    {
        public int id { get; set; }
        public List<Cast> cast { get; set; }
        public List<Crew> crew { get; set; }
    }
}
