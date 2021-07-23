using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Common.Models;

namespace Lib.Services.Interfaces
{
    public interface IPeopleService
    {
        public Task<List<People>> GetPeople();

        public Task<List<People>> SearchPeople(string name);


    }
}
