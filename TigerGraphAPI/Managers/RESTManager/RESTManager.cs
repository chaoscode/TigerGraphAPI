using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using TigerGraphAPI.Models.REST;


/// <summary>
/// RESTManager written by Christopher Powell
/// </summary>
namespace TigerGraphAPI.Managers.REST
{
    public class RestManager
    {               
        public CallRestOutput CallREST(CallRestInput inpt, string username = null, string password = null, int HTTPTimeOut = 3000, int POSTReadTimeOut = 3000, int POSTWriteTimeOut = 3000, Nullable<SecurityProtocolType> TLSVersion = null, bool IgnoreCertErrors = false)
        {

            // Self signed cert bypass
            if (IgnoreCertErrors)
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateRemoteCertificate);
            }

            // Create return object
            CallRestOutput result = new CallRestOutput();

            // This sets the TLS version. A TLS error looks like a timeout
            if (TLSVersion != null) {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)TLSVersion;
            }

            // Create URI object
            Uri uri = new Uri(inpt.URL);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            // Set response URL
            result.URL = inpt.URL;

            // Set request method
            result.requestMethod = inpt.Method;

            // Fix missing cookies
            request.CookieContainer = new CookieContainer();

            // Add cookies to request if needed
            if ((inpt.Cookies != null))
            {
                foreach (Cookie cookie in inpt.Cookies)

                    request.CookieContainer.Add(cookie);
            }

            // Set HTTP call TimeOut based on ReadTimeOut
            request.Timeout = HTTPTimeOut;

            // Set method
            request.Method = inpt.Method;

            // Set application type
            request.ContentType = "application/json";

            // If we need auth use it
            if (!string.IsNullOrWhiteSpace(username))
            {
                request.Headers.Add("Username: " + username);
                request.Headers.Add("Password: " + password);
                request.PreAuthenticate = true;
            }

            // Auth Header 
            if (!string.IsNullOrWhiteSpace(inpt.BearerToken))
            {
                request.Headers.Add("Authorization: Bearer " + inpt.BearerToken);
            }

            // Custom Header support
            if (inpt.CustomHeaderList.Count > 0)
            {
                foreach (var header in inpt.CustomHeaderList)
                    request.Headers.Add(header.Key + ":" + header.Value);
            }

            // Give the ability to set referer
            if ((!string.IsNullOrEmpty(inpt.Referer)))
                request.Referer = inpt.Referer;

            // GET does not have a request body
            if (inpt.Method != "GET")
            {

                // Encode JSON data for transmission 
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] byteData = encoding.GetBytes(inpt.BodyData);

                // Setup the request content
                request.ContentLength = byteData.Length;

                // Open REST Service and Write data  
                try
                {

                    // Get Stream
                    using (Stream postStream = request.GetRequestStream())
                    {

                        // Write to Stream
                        postStream.Write(byteData, 0, byteData.Length);

                        // Make sure the postStream closes
                        postStream.Close();
                    }
                }
                catch (WebException WebEx)
                {

                    // Web Exception
                    result.Output = WebEx.Source + " : " + WebEx.Message;
                    result.HTTPStatus = WebEx.Status;
                    result.Success = false;
                    if (WebEx.Response != null)
                    {
                        using (HttpWebResponse errResp = (HttpWebResponse)WebEx.Response)
                        {
                            using (Stream resstrm = errResp.GetResponseStream())
                            {
                                using (StreamReader sr = new StreamReader(resstrm))
                                {
                                    result.Output = sr.ReadToEnd();
                                }
                            }
                        }
                    }
                    else
                        result.Output = WebEx.Source + " : " + WebEx.Message;
                }
                catch (Exception ex)
                {

                    // Error
                    result.Output = ex.Source + " : " + ex.Message;
                    result.Success = false;
                }
            }

            try
            {

                // Get response  
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    // Get the response stream into a reader  
                    using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
                    {

                        // Put response into output string
                        result.Output = responseStream.ReadToEnd();
                    }

                    result.statusCode = response.StatusCode.ToString();
                    result.Cookies = response.Cookies;
                }
            }
            catch (WebException ex)
            {

                // Error
                result.Success = false;

                // Get error response object
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                result.HTTPStatus = ex.Status;

                // Set response code if it exists
                if (res != null)
                {
                    result.statusCode = res.StatusCode.ToString();
                }
                
                // Get response text
                if (ex.Response != null)
                {
                    if (inpt.ReturnNonErrorStatus)
                        result.HTTPStatus = (WebExceptionStatus)((HttpWebResponse)ex.Response).StatusCode;
                    using (HttpWebResponse errResp = (HttpWebResponse)ex.Response)
                    {
                        using (Stream resstrm = errResp.GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(resstrm))
                            {
                                result.Output = sr.ReadToEnd();
                            }
                        }
                    }
                }
                else
                    // return exception if no response text
                    result.Output = ex.Source + " : " + ex.Message;
            }
            catch (Exception ex)
            {

                // Error
                result.Output = ex.Source + " : " + ex.Message;
                result.Success = false;
            }

            // return results
            return result;
        }

        private static bool ValidateRemoteCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors policyErrors)
        {

            // Accept any cert and ignore all errors. 
            return true;
        }
    }

}
