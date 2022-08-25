using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TigerGraphAPI.Managers.TigerGraphAPI
{
    class TGRESTManager
    {
        private string _baseURL = "";
        private string _basePath = "";
        private string _username = "";
        private string _password = "";

        public TGRESTManager(string _baseurl, string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string BaseURL
        {
            get => _baseURL;
            set => _baseURL = value;
        }

        public string BasePath
        {
            get => _basePath;
            set => _basePath = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        //http://10.10.20.101:14240/api/auth/login
        public string postLogin(Models.TigerGraphAPI.RequestToken request)
        {
            return "";
        }

    }
}
