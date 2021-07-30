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
        private readonly IChuckService _chuckService;
        private readonly IPeopleService _peopleService;

        public SearchService(IChuckService chuckService, IPeopleService peopleService)
        {
            _chuckService = chuckService;
            _peopleService = peopleService;
        }

        public async Task<Search> GetSearch(string name)
        {
            var searchedPeople = await _peopleService.SearchPeople(name);
            var searchedJokes = await _chuckService.SearchJoke(name);

            return new Search
            {
                People = searchedPeople,
                Jokes = searchedJokes,
            };
        }
    }
}


           