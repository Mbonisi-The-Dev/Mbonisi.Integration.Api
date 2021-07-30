﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Models
{
    public class Joke
    {
        public List<string> Categories { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
