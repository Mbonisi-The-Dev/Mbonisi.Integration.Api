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
    public class ChuckController : ControllerBase
    {
        //private readonly string BaseUrlOne = "https://api.chucknorris.io/jokes/categories";

        private readonly IChuckService _chuckService;

        public ChuckController(IChuckService chuckService)
        {
            _chuckService = chuckService;
        }

        [HttpGet]
        [Route("Chuck")]
        public async Task<ActionResult<List<Chuck>>> Chuck()
        {
            List<Chuck> chuck = await _chuckService.GetCategories();
            return chuck;
        }

        [HttpGet]
        //[Route("GetJokeByCategories")]
        public async Task<ActionResult<Joke>> Search(string name)
        {
            Joke joke = await _chuckService.GetJokeByCategory(name);
            return joke;
        }


    }
}
