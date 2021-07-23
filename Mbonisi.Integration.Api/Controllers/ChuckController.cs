using Lib.Services.Interfaces;
using Lib.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using RestSharp;

namespace Mbonisi.Integration.Api.Controllers
{
    //[Route("api/[controller]")]
    //[Route("[controller]")]
    //[ApiController]
    public class ChuckController : ControllerBase
    {
        //private readonly string BaseUrlOne = "https://api.chucknorris.io/jokes/categories";

        private readonly IChuckService _chuckService;

        public ChuckController(IChuckService chuckService)
        {
            _chuckService = chuckService;
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<ActionResult<List<Chuck>>> Chuck()
        {
            List<Chuck> chuck = await _chuckService.GetCategories();
            return chuck;
        }

        //Search functionality
        //[HttpGet]
        //[Route("Search/name:string")]
        //public async Task<IActionResult> Search(string category)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(BaseUrlOne);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = await client.GetAsync($"?search={category}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            dynamic jokesCat = response.Content.ReadAsStringAsync();
        //            jokesCat.Wait();
        //            string jokesString = jokesCat.Result;
        //            dynamic jokesArray = JsonConvert.DeserializeObject<dynamic>(jokesString);
        //            Console.WriteLine(jokesArray);

        //            return Ok("Ïtem found");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Server error try after some time.");
        //        }
        //    }

        //    return Ok();
        //}



    }
}
