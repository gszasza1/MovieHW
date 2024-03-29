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
    public class MovieService
    {

        private readonly string serverUrl = "https://api.themoviedb.org/3";     //baseURL
        private readonly string AuthKey = "?api_key=5637779ad0397a76e1cddf7bc16c3a4d";  //Autentikációs Kulcs

        //Top filmek lekérése
        public async Task<ListMovies> GetTopratedMoviesAsync()
        {
            string topMovieUri = serverUrl + "/movie/top_rated" + AuthKey;
            return await GetAsync<ListMovies>(new Uri(topMovieUri));
        }

        //Adott filmhez való ajánlás
        public async Task<ListMovies> GetRecommendationMoviesAsync(int movieID)
        {
            string recommendMovieUri = serverUrl + "/movie/" +movieID + "/recommendations" + AuthKey;
            return await GetAsync<ListMovies>(new Uri(recommendMovieUri));
        }

        //Kedvelt filmek
        public async Task<ListMovies> GetPoplarMoviesAsync(int MovieId)
        {
            string popularMovieUri = serverUrl + "/movie/" + MovieId + AuthKey;
            return await GetAsync<ListMovies>(new Uri(popularMovieUri));
        }

        //Egy aditt film adatainak lekérése
        public async Task<MovieDetails> GetExactMovieAsync(int movieID)
        {
            string exactMovieUri = serverUrl + "/movie/" + movieID + AuthKey;
            return await GetAsync<MovieDetails>(new Uri(exactMovieUri));
        }

        //Filmek keresése adott string alapján
        public async Task<ListMovies> SearchMovieAsync(string searcguery)
        {
            string searchMovieUri = serverUrl + "/search/movie" + AuthKey+ "&query="+ searcguery;
            return await GetAsync<ListMovies>(new Uri(searchMovieUri));
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
