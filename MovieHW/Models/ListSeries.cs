using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{

    public class GetSeriesFromList
    {
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public double popularity { get; set; }
        public int id { get; set; }
        public string backdrop_path { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public string first_air_date { get; set; }
        public List<object> origin_country { get; set; }
        public List<int> genre_ids { get; set; }
        public string original_language { get; set; }
        public int vote_count { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
    }

    public class ListSeries
    {
        public int page { get; set; }
        public List<GetSeriesFromList> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}
