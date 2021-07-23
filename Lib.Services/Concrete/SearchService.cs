using Lib.Common.Models;
using Lib.Services.Interfaces;
using Lib.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;



namespace Lib.Services.Concrete
{
    public class SearchService : ISearchService
    {
        private readonly string BaseUrlOne = "https://swapi.dev/api/people";
        private readonly string BaseUrlTwo  = "https://api.chucknorris.io/jokes/search?";


        //private readonly ISearchService _searchService;

        public SearchService()
        {
        }

        public async Task<List<Search>> GetSearch(string name)
        {
            List<Search> searchList = new List<Search>();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlOne);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  

                HttpResponseMessage response = await client.GetAsync($"?search={name}");
                if (response.IsSuccessStatusCode)
                {
                    dynamic searchListPeople = await response.Content.ReadAsStringAsync();
                    //searchListPeople.Wait();
                    Console.WriteLine(searchListPeople);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlTwo);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync($"?query={name}");
                if (response.IsSuccessStatusCode)
                {
                    dynamic jokesCat = response.Content.ReadAsStringAsync();
                    //jokesCat.Wait();
                    Console.WriteLine(jokesCat);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //create the search tasks to be executed
            //    var tasks = new[]{
            //            GetSearch(BaseUrlOne, client),
            //            GetSearch(BaseUrlTwo, client),                        
            //    };

            //    // Await the completion of all the running tasks. 
            //    var responses = await Task.WhenAll(tasks); // returns IEmumerable<WalmartModel>

            //    var results = responses.Where(r => r != null); //filter out any null values
            //}
            return searchList;
        }
    }
}
