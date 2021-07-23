using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Models;

namespace Lib.Services.Interfaces
{
    public interface ISearchService
    {
        public Task<List<Search>> GetSearch(string name);
    }
}
