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
    public class PersonService
    {

        private readonly string serverUrl = "https://api.themoviedb.org/3";
        private readonly string AuthKey = "?api_key=5637779ad0397a76e1cddf7bc16c3a4d";


        public async Task<Actor> GetPersonAsync(int personId)
        {
            string personURI = serverUrl + "/person/" + personId + AuthKey;
            return await GetAsync<Actor>(new Uri(personURI));
        }
        public async Task<MoviePeople> GetMoviePeopleAsync(int movieId)
        {
            string personURI = serverUrl + "/movie/" + movieId + "/credits" + AuthKey;
            return await GetAsync<MoviePeople>(new Uri(personURI));
        }

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
