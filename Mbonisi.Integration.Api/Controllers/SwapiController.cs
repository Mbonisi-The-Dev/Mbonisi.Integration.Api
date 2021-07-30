

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
using Mbonisi.Integration.Api.Models;


namespace Mbonisi.Integration.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public SwapiController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet]
        //[Route("People")]
        public async Task<ActionResult<List<People>>> People()
        {
            List<People> people = await _peopleService.GetPeople();
            return people;
        }


        //[HttpGet]
        //[Route("Search/")]
        //public async Task<ActionResult<List<People>>> SearchPeople(string name)
        //{
        //    List<People> person = await _peopleService.SearchPeople(name);
        //    return person;
        //}



        //[HttpGet]
        //[Route("Search/name:string")]
        //public async Task<IActionResult> Search(string name)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(BaseUrlOne);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = await client.GetAsync($"?search={name}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            dynamic peopleRes = response.Content.ReadAsStringAsync();
        //            peopleRes.Wait();

        //            string pResult = peopleRes.Result;
        //            Root swapiObj = JsonConvert.DeserializeObject<Root>(pResult);
        //            Console.WriteLine(swapiObj.results);
        //            Console.WriteLine(swapiObj.next);
        //            Console.WriteLine(swapiObj.previous);
        //            Console.WriteLine(swapiObj.count);

        //            return Ok("Ïtem found");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Server error try after some time.");
        //        }
        //    }

        //    return Ok("Ïtem found");
        //}
    }
}
