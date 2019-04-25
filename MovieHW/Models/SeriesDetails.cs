using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Models
{
    public class CreatedBy
    {
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path
        {
            get
            { return profilePicture; }
            set { profilePicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string profilePicture;
    }


    public class LastEpisodeToAir
    {
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string production_code { get; set; }
        public int season_number { get; set; }
        public int show_id { get; set; }
        public string still_path { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Network
    {
        public string name { get; set; }
        public int id { get; set; }
        public string logo_path
        {
            get
            { return logoPicture; }
            set { logoPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string logoPicture;
        public string origin_country { get; set; }
    }
    

    public class Season
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public int season_number { get; set; }
    }

    public class SeriesDetails
    {
        public string backdrop_path { get; set; }
        public List<CreatedBy> created_by { get; set; }
        public List<int> episode_run_time { get; set; }
        public string first_air_date { get; set; }
        public List<Genres> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public bool in_production { get; set; }
        public List<string> languages { get; set; }
        public string last_air_date { get; set; }
        public LastEpisodeToAir last_episode_to_air { get; set; }
        public string name { get; set; }
        public object next_episode_to_air { get; set; }
        public List<Network> networks { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public List<string> origin_country { get; set; }
        public string original_language { get; set; }
        public string original_name { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path
        {
            get
            { return posterPicture; }
            set { posterPicture = "https://image.tmdb.org/t/p/w500" + value; }
        }

        private string posterPicture;
        public List<ProductionCompanies> production_companies { get; set; }
        public List<Season> seasons { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }
}
