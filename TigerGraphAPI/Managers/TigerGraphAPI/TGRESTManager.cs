using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TigerGraphAPI.Models.REST;
using TigerGraphAPI.Models.TigerGraphAPI.Core;
using TigerGraphAPI.Models.TigerGraphAPI.Core.Auth;
using TigerGraphAPI.Models.TigerGraphAPI.Core.Search;
/// <summary>
/// This is not started
/// </summary>
namespace TigerGraphAPI.Managers.TigerGraphAPI
{
    class TGRESTManager
    {
        private string _domain = "";
        private string _baseURL = "";
        private string _basePath = "api/";
        private string _username = "";
        private string _password = "";
        private string _sessionid = "";

        public TGRESTManager(string baseurl, string username, string password)
        {
            //Parse baseurl for the IP. This is needs to set the session cookies domain correctly
            Uri rootUri = new Uri(baseurl);

            // Setup values for connection
            BaseURL = baseurl;
            Username = username;
            Password = password;
            Domain = rootUri.Host;

            // Generate session
            ResponseAuth result = postLogin(username, password);
        }

        public string Domain
        {
            get => _domain;
            set => _domain = value;
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

        public string SessionID
        {
            get => _sessionid;
            set => _sessionid = value;
        }

        //http://10.10.20.101:14240/api/auth/login
        public ResponseAuth postLogin(string username, string password)
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
            RequestAuth request = new RequestAuth();
            request.username = username;
            request.password = password;

            REST.RestManager RESTMgr = new REST.RestManager();

            // Set payload
            inpt.BodyData = JsonConvert.SerializeObject(request);

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            // Get result object
            ResponseAuth result = new ResponseAuth();

            // Build response object and return
            result = JsonConvert.DeserializeObject<ResponseAuth>(RestResult.Output);

            // Setup Session
            SessionID = RestResult.Cookies.FirstOrDefault(t => t.Name == "TigerGraphApp").Value;

            return result;
        }

        //Request URL: http://10.10.20.101:14240/api/log/search?pattern=%25
        //Request Method: GET
        public searchResponse getSearch(string pattern = "%")
        {

            // Create response object
            CallRestOutput outpt = new CallRestOutput();

            // Create request object
            CallRestInput inpt = new CallRestInput();

            // Setup request
            inpt.URL = _baseURL + _basePath + "log/search" + "?pattern=" + pattern;
            inpt.Method = "GET";
            inpt.contentType = "application/json";
            inpt.Referer = _baseURL;

            // Apply Session to request
            inpt = setSession(inpt);

            // Create REST Manager 
            REST.RestManager RESTMgr = new REST.RestManager();

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            // Get result object
            searchResponse result = new searchResponse();

            // Build response object and return
            result = JsonConvert.DeserializeObject<searchResponse>(RestResult.Output);

            return result;
        }

        //Request URL: http://10.10.20.101:14240/api/ts3/api/datapoints?from=1662051475&to=1662051591&what=cpu
        //Request Method: GET

        private CallRestInput setSession(CallRestInput inpt)
        {
            // Init cookies property if null
            if (inpt.Cookies == null)
            {
                inpt.Cookies = new CookieCollection();
            }

            // Create Session Cookie
            Cookie sessionCookie = new Cookie();
            sessionCookie.Name = "TigerGraphApp";
            sessionCookie.Value = SessionID;
            sessionCookie.Domain = Domain;

            // Add Cookie to request
            inpt.Cookies.Add(sessionCookie);
            
            return inpt;
        }

    }
}
