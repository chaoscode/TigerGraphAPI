using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TigerGraphAPI.Models.REST;
/// <summary>
/// This is not started
/// </summary>
namespace TigerGraphAPI.Managers.TigerGraphAPI
{
    class TGRESTManager
    {
        private string _baseURL = "";
        private string _basePath = "api/";
        private string _username = "";
        private string _password = "";

        public TGRESTManager(string baseurl, string username, string password)
        {
            BaseURL = baseurl;
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
        public string postLogin(string username, string password)
        {

            // Create response object
            CallRestOutput outpt = new CallRestOutput();

            // Create request object
            CallRestInput inpt = new CallRestInput();

            // Setup request
            inpt.URL = _baseURL + _basePath + "auth/login";
            inpt.Method = "POST";
            inpt.contentType = "application/json";
            inpt.Referer = _baseURL;     

            //http://10.10.20.101:14240/api/auth/login
            // 
            Models.TigerGraphAPI.RequestAuth request = new Models.TigerGraphAPI.RequestAuth();
            request.username = username;
            request.password = password;

            REST.RestManager RESTMgr = new REST.RestManager();

            // Set payload
            inpt.BodyData = JsonConvert.SerializeObject(request);

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            // Get result object
            Models.TigerGraphAPI.ResponseRequestToken result = new Models.TigerGraphAPI.ResponseRequestToken();

            // Build response object and return
            result = JsonConvert.DeserializeObject<Models.TigerGraphAPI.ResponseRequestToken>(RestResult.Output);

            return "";
        }

    }
}
