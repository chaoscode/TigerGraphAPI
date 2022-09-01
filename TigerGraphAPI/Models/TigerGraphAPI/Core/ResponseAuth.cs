using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphAPI.Models.TigerGraphAPI.Core
{
    public class ResponseAuth
    {
        public bool error { get; set; }
        public string message { get; set; }
        public Results results { get; set; }
    }

    public class Results
    {
        public string name { get; set; }
        public Roles roles { get; set; }
        public Privileges privileges { get; set; }
        public Secrets secrets { get; set; }
        public bool isSuperUser { get; set; }
    }

    public class Roles
    {
        public string[] _1 { get; set; }
        public string[] MyGraph { get; set; }
    }

    public class Privileges
    {
        public string[] _1 { get; set; }
        public string[] MyGraph { get; set; }
    }

    public class Secrets
    {
    }

}
