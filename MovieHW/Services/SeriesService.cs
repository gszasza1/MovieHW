﻿using MovieHW.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieHW.Services
{
    public class SeriesService
    {
        private readonly string serverUrl = "https://api.themoviedb.org/3";
        private readonly string AuthKey = "?api_key=5637779ad0397a76e1cddf7bc16c3a4d";

        //top sorozat
        public async Task<ListSeries> GetTopSeriesAsync()
        {
            string seriesTopURI = serverUrl + "/tv/top_rated" + AuthKey;
            return await GetAsync<ListSeries>(new Uri(seriesTopURI));
        }

        //Adott sorozathoz ajánlás
        public async Task<ListSeries> GetRecommendedSeriesAsync(int seriesID)
        {
            string seriesURI = serverUrl + "/tv/" + seriesID +"/recommendations" + AuthKey;
            return await GetAsync<ListSeries>(new Uri(seriesURI));
        }

        // Adott sorozat adatainak lekérése
        public async Task<SeriesDetails> GetEcaxtSeriesAsync(int seriesID)
        {
            string seriesURI = serverUrl + "/tv/" + seriesID + AuthKey;
            return await GetAsync<SeriesDetails>(new Uri(seriesURI));
        }

        //Adott sorozat adott évadának adatai
        public async Task<SeriesSeasons> GetSeriesSeasonAsync(int seriesID, int seasonID)
        {
            string seriesSeasonURI = serverUrl + "/tv/" + seriesID + "/season/" + seasonID + AuthKey;
            return await GetAsync<SeriesSeasons>(new Uri(seriesSeasonURI));
        }

        //Adott évad adott epizódának lekérése
        public async Task<Episode> GetEpisodeAsync(int seriesID, int seasonID, int episodeID)
        {
            string seriesSeasonURI = serverUrl + "/tv/" + seriesID + "/season/" + seasonID +"/episode/" + episodeID + AuthKey;
            return await GetAsync<Episode>(new Uri(seriesSeasonURI));
        }

        //Sorozat keresése string alapján
        public async Task<ListSeries> SearchSeriesAsync(string searcguery)
        {
            string searchSeriesUri = serverUrl + "/search/tv" + AuthKey + "&query=" + searcguery;
            return await GetAsync<ListSeries>(new Uri(searchSeriesUri));
        }


        //Api hívás, illetve válasz JSONból való visszakonvertálása
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
