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


namespace Lib.Services.Concrete
{
    public class PeopleService : IPeopleService
    {
        private readonly string BaseUrlOne = "https://swapi.dev/api/people";
        public PeopleService()
        {
        }

        public async Task<List<People>> GetPeople()
        {
            List<People> mbSwapiVersions = new List<People>();
            //Result people = new();
            Root swapiObj = new Root();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlOne);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"");

                if (response.IsSuccessStatusCode)
                {
                    dynamic peopleRes = response.Content.ReadAsStringAsync();
                    peopleRes.Wait();

                    string pResult = peopleRes.Result;
                    swapiObj = JsonConvert.DeserializeObject<Root>(pResult);
                    Console.WriteLine(swapiObj.results);
                    Console.WriteLine(swapiObj.next);
                    Console.WriteLine(swapiObj.previous);
                    Console.WriteLine(swapiObj.count);

                    string nextUrl = swapiObj.next;
                    int pageNumber = 2;
                    while (nextUrl != null && pageNumber <= 8)
                    {
                        var response2 = await client.GetAsync($"?page={pageNumber}");
                        pageNumber++;
                        dynamic peopleRes2 = response2.Content.ReadAsStringAsync();
                        peopleRes2.Wait();
                        string pResult2 = peopleRes2.Result;
                        Root swapiObj2 = JsonConvert.DeserializeObject<Root>(pResult2);
                        swapiObj.results.AddRange(swapiObj2.results);
                        Console.WriteLine(swapiObj.results);
                    }

                    foreach (var item in swapiObj.results)
                    {
                        mbSwapiVersions.Add(new People
                        {
                            Name = item.name.Trim(),
                            Gender = item.gender.Trim(),
                            BirthYear = item.birth_year.Trim(),
                            SkinColor = item.skin_color.Trim(),
                            Height = item.height.Trim(),
                            Homeworld = item.homeworld.Trim(),
                            Mass = item.mass.Trim(),
                            HairColor = item.hair_color.Trim(),
                            EyeColor = item.eye_color.Trim(),
                            Films = item.films,
                            Species = item.species,
                            Vehicles = item.vehicles,
                            Starships = item.starships,
                            Created = item.created,
                            Edited = item.edited,
                            Url = item.url.Trim(),
                        });
                    }

                }
                else
                {
                    throw new Exception("Server error try after some time.");
                }

            }
            return mbSwapiVersions;
        }

        public async Task<List<People>> SearchPeople(string name)
        {
            List<People> mbSwapiVersions = new List<People>();
            //Result people = new();
            Root swapiObj = new Root();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlOne);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"?search={name}");

                if (response.IsSuccessStatusCode)
                {
                    dynamic peopleRes = response.Content.ReadAsStringAsync();
                    peopleRes.Wait();

                    string pResult = peopleRes.Result;
                    swapiObj = JsonConvert.DeserializeObject<Root>(pResult);
                    Console.WriteLine(swapiObj.results);
                    Console.WriteLine(swapiObj.next);
                    Console.WriteLine(swapiObj.previous);
                    Console.WriteLine(swapiObj.count);

                    string nextUrl = swapiObj.next;
                    int pageNumber = 2;
                    while (nextUrl != null && pageNumber <= 8)
                    {
                        var response2 = await client.GetAsync($"?page={pageNumber}");
                        pageNumber++;
                        dynamic peopleRes2 = response2.Content.ReadAsStringAsync();
                        peopleRes2.Wait();
                        string pResult2 = peopleRes2.Result;
                        Root swapiObj2 = JsonConvert.DeserializeObject<Root>(pResult2);
                        swapiObj.results.AddRange(swapiObj2.results);
                        Console.WriteLine(swapiObj.results);
                    }

                    foreach (var item in swapiObj.results)
                    {
                        mbSwapiVersions.Add(new People
                        {
                            Name = item.name.Trim(),
                            Gender = item.gender.Trim(),
                            BirthYear = item.birth_year.Trim(),
                            SkinColor = item.skin_color.Trim(),
                            Height = item.height.Trim(),
                            Homeworld = item.homeworld.Trim(),
                            Mass = item.mass.Trim(),
                            HairColor = item.hair_color.Trim(),
                            EyeColor = item.eye_color.Trim(),
                            Films = item.films,
                            Species = item.species,
                            Vehicles = item.vehicles,
                            Starships = item.starships,
                            Created = item.created,
                            Edited = item.edited,
                            Url = item.url.Trim(),
                        });
                    }

                }
                else
                {
                    throw new Exception("Server error try after some time.");
                }

            }
            return mbSwapiVersions;
        }
    }
}
