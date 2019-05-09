using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{
    //Sorozat évadához tartozó adatok
    public class SeriesCrew
    {
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string profile_path
        {
            get
            { return profilPicture; }
            set { profilPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string profilPicture;
    }

    public class GuestStar
    {
        public int id { get; set; }
        public string name { get; set; }
        public string credit_id { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public string profile_path
        {
            get
            { return profilPicture; }
            set { profilPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string profilPicture;
    }

    public class Episode
    {
        public string air_date { get; set; }
        public List<SeriesCrew> crew { get; set; }
        public int episode_number { get; set; }
        public List<GuestStar> guest_stars { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string production_code { get; set; }
        public int season_number { get; set; }
        public string still_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class SeriesSeasons
    {
        public string _id { get; set; }
        public string air_date { get; set; }
        public List<Episode> episodes { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public int season_number { get; set; }
    }
}
