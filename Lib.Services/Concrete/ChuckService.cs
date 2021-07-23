using Lib.Common.Models;
using Lib.Services.Interfaces;
using Lib.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Lib.Services.Concrete
{
    public class ChuckService: IChuckService
    {
        private readonly string BaseUrl = "https://api.chucknorris.io/jokes/categories";
        public ChuckService()
        {

        }
        public async Task<List<Chuck>> GetCategories()
        {
            List<Chuck> mbChuck = new List<Chuck>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"");

                if (response.IsSuccessStatusCode)
                {
                    dynamic jokesCat  = response.Content.ReadAsStringAsync();
                    jokesCat.Wait();
                    var jokesVar = jokesCat.Result;
                    JArray jokesResult = JArray.Parse(jokesVar);
                    List<string> jokesString = jokesResult.Select(c => (string)c).ToList();

                    for(int i = 0; i < jokesString.Count; i ++)
                    {
                        //List<string> jString = new List<string>();
                        //jString.Add(jokesString[i]);
                        mbChuck.Add( new Chuck { Category = jokesString[i] });
                        Console.WriteLine(mbChuck);
                    }

                    //foreach(var item in jokesCat)
                    //{                           
                    //}                    

                    //var jokesArray = jokesResult["items"].Value<JArray>();


                    //dynamic jokesCat = response.Content.ReadAsStringAsync();
                    //jokesCat.Wait();
                    //string jokesString = jokesCat.Result;
                    //dynamic jokesArray = JsonConvert.DeserializeObject<dynamic>(jokesString);            

                    //Console.WriteLine(jokesArray);
                    //mbChuck = jokesArray.Split(",").ToList();
                    //Console.WriteLine(mbChuck);

                }
                else
                {
                    throw new Exception("Server error try after some time ");
                }
            }
            return mbChuck;
        }
    }  
}
