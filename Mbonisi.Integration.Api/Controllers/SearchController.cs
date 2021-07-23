using Lib.Services.Interfaces;
using Lib.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Mbonisi.Integration.Api.Controllers
{
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<List<Search>>> Search(string name)
        {
            List<Search> search = await _searchService.GetSearch(name);
            return search;
        }
    }
}
