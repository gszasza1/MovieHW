using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{
    public class PersonCreditCast
    {
        public string character { get; set; }
        public string credit_id { get; set; }
        public string release_date { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public bool adult { get; set; }
        public double vote_average { get; set; }
        public string title { get; set; }
        public List<object> genre_ids { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public double popularity { get; set; }
        public int id { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
    }

    public class PersonCreditCrew
    {
        public int id { get; set; }
        public string department { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string job { get; set; }
        public string overview { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public string backdrop_path { get; set; }
        public string title { get; set; }
        public double popularity { get; set; }
        public List<object> genre_ids { get; set; }
        public double vote_average { get; set; }
        public bool adult { get; set; }
        public string release_date { get; set; }
        public string credit_id { get; set; }
    }

    public class PersonCredit
    {
        public List<PersonCreditCrew> crew { get; set; }
        public List<PersonCreditCast> cast { get; set; }
        public int id { get; set; }
    }
}
