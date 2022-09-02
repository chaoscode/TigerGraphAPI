using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphAPI.Models.TigerGraphAPI.Core.Search
{



    public class searchResponse
    {
        public bool error { get; set; }
        public string message { get; set; }
        public Results results { get; set; }
    }

    public class Results
    {
        public M1[] m1 { get; set; }
    }

    public class M1
    {
        public string line { get; set; }
        public string path { get; set; }
        public int offset { get; set; }
        public int lineNumber { get; set; }
    }

}
