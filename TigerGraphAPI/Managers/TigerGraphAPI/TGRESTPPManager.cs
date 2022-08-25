using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TigerGraphAPI.Models.REST;
using Newtonsoft.Json;
/// <summary>
/// 
/// This Library was written for TigerGraph v3.6.1 by Christopher Powell
/// 
/// </summary>
namespace TigerGraphAPI.Managers.TG
{
    class TGRESTPPManager
    {
        private string _baseURL = ""; 
        private string _basePath = "";
        private string _authtoken = "";


        public TGRESTPPManager(string _baseurl, string DB = "MyGraph", string authtoken = "", string lifetime = "120")
        {
            // Set base URL
            this.BaseURL = _baseurl;

            // Get Request Token
            Models.TigerGraphAPI.RequestToken RT = new Models.TigerGraphAPI.RequestToken();
            RT.graph = DB;
            RT.secret = authtoken;
            RT.lifetime = lifetime;

            // Get RequestToken
            Models.TigerGraphAPI.ResponseRequestToken result = this.postRequestToken(RT);

            // Set request token
            this.AuthToken = result.token;
        }

        public string AuthToken
        {
            get => _authtoken;
            set => _authtoken = value;
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
        public CallRestOutput testEndPoint(string endpointPath, string method)
        {
            // Create response object
            CallRestOutput outpt = new CallRestOutput();

            // Create request object
            CallRestInput inpt = new CallRestInput();

            // Setup request
            inpt.URL = _baseURL + _basePath + endpointPath;
            inpt.Method = method;

            REST.RestManager RESTMgr = new REST.RestManager();

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            return RestResult;
        }

        public Models.TigerGraphAPI.ResponseRequestToken postRequestToken(Models.TigerGraphAPI.RequestToken request)
        {

            // Create response object
            CallRestOutput outpt = new CallRestOutput();

            // Create request object
            CallRestInput inpt = new CallRestInput();

            // Setup request
            inpt.URL = _baseURL + _basePath + "/restpp/requesttoken";
            inpt.Method = "POST";

            REST.RestManager RESTMgr = new REST.RestManager();
             
            // Set payload
            inpt.BodyData = JsonConvert.SerializeObject(request);

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            // Get result object
            Models.TigerGraphAPI.ResponseRequestToken result = new Models.TigerGraphAPI.ResponseRequestToken();

            // Build response object and return
            result = JsonConvert.DeserializeObject<Models.TigerGraphAPI.ResponseRequestToken>(RestResult.Output);

            return result;
        }

        public Models.TigerGraphAPI.ResponseEcho getEcho()
        {

            // Create response object
            CallRestOutput outpt = new CallRestOutput();

            // Create request object
            CallRestInput inpt = new CallRestInput();

            // Setup request
            inpt.URL = _baseURL + _basePath + "/restpp/echo";
            inpt.Method = "GET";
            inpt.BearerToken = AuthToken;

            REST.RestManager RESTMgr = new REST.RestManager();

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            // Get result object
            Models.TigerGraphAPI.ResponseEcho result = new Models.TigerGraphAPI.ResponseEcho();

            // Build response object and return
            result = JsonConvert.DeserializeObject<Models.TigerGraphAPI.ResponseEcho>(RestResult.Output);

            return result;
        }

        public Models.TigerGraphAPI.ResponsegetEndpoints getEndpoints()
        {

            // Create response object
            CallRestOutput outpt = new CallRestOutput();

            // Create request object
            CallRestInput inpt = new CallRestInput();

            // Setup request
            inpt.URL = _baseURL + _basePath + "/restpp/endpoints/";
            inpt.Method = "GET";
            inpt.BearerToken = AuthToken;

            REST.RestManager RESTMgr = new REST.RestManager();

            // Get results of Rest call
            CallRestOutput RestResult = RESTMgr.CallREST(inpt);

            // Get result object
            Models.TigerGraphAPI.ResponsegetEndpoints result = new Models.TigerGraphAPI.ResponsegetEndpoints();

            // Build response object and return
            result = JsonConvert.DeserializeObject<Models.TigerGraphAPI.ResponsegetEndpoints>(RestResult.Output);

            return result;
        }
    }
}
