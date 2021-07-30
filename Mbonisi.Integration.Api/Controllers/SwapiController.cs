

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
    }
}
