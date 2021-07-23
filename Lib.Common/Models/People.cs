using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Models
{
    public class People
    {
        public string Name { get; set; } 
        public string Gender { get; set; } 
        public string BirthYear { get; set; }
        public string SkinColor { get; set; }
        public string Height { get; set; }  
     
        public string Homeworld { get; set; }      
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public List<string> Films { get; set; }
        public List<string> Species { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Starships { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
