using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphAPI.Models.TigerGraphAPI
{

    public class ResponseRequestToken
    {
        public string code { get; set; }
        public int expiration { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }

}
