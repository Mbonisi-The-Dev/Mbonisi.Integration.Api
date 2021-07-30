using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Models
{
    public class ChuckRoot
    {
        public int total { get; set; }
        public List<Joke> result { get; set; }
    }
}
