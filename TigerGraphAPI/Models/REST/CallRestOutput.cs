using System.Net;

namespace TigerGraphAPI.Models.REST
{
    public class CallRestOutput
    {
        public string URL { get; set; }
        public bool Success { get; set; } = true;
        public WebExceptionStatus HTTPStatus { get; set; }
        public string Output { get; set; }
        public CookieCollection Cookies { get; set; }
        public string error;
        public string statusCode;
        public string requestMethod;
    }
}
