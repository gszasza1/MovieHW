using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{

    //filmek listájához kapcsolódó osztályok
    public class ListMovies
    {
        public int page { get; set; }
        public List<GetMovieFromList> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class GetMovieFromList
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public string title { get; set; }
        public double popularity { get; set; }
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }
}
