using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Models;

namespace Lib.Services.Interfaces
{
    public interface IChuckService
    {
        public Task<List<Chuck>> GetCategories();
        public Task<Joke> GetJokeByCategory(string category);
        public Task<List<Joke>> SearchJoke(string name);

    }
}
