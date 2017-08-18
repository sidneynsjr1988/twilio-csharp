#if NET35
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using Twilio.Exceptions;
using Newtonsoft.Json;

namespace Twilio.Http
{

    /// <summary>
    /// Sample client to make requests
    /// </summary>
    public class WebRequestClient : HttpClient
    {
        private const string PlatVersion = " (.NET 3.5)";

        /// <summary>
        /// Make an HTTP request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(Request request)
        {

            var httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                var stream = httpRequest.GetRequestStream();
                stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
                stream.Close();
            }

            this.LastRequest = request;
            this.LastResponse = null;
            try
            {
                var response = (HttpWebResponse) httpRequest.GetResponse();
                var content = GetResponseContent(response);
                this.LastResponse = new Response(response.StatusCode, content);
            }
            catch (WebException e)
            {
                if (e.Response == null)
                {
                    // Network or connection error
                    throw;
                }
                // Non 2XX status code
                var errorResponse = (HttpWebResponse) e.Response;
                this.LastResponse = new Response(errorResponse.StatusCode, GetResponseContent(errorResponse));
            }
            return this.LastResponse;
        }

        private string GetResponseContent(HttpWebResponse response)
        {
            var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

        private static void SetUserAgent(HttpWebRequest request)
        {
            var property = typeof(HttpWebRequest).GetProperty("UserAgent");
            if (property != null)
            {
                const string libraryVersion = "twilio-csharp/" + AssemblyInfomation.AssemblyInformationalVersion + PlatVersion;
                request.UserAgent = libraryVersion;
            }
        }

        private HttpWebRequest BuildHttpRequest(Request request)
        {
            var httpRequest = (HttpWebRequest) WebRequest.Create(request.ConstructUrl());
            SetUserAgent(httpRequest);

            httpRequest.Method = request.Method.ToString();
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Accept-Encoding"] = "utf-8";

            var authBytes = Authentication(request.Username, request.Password);
            httpRequest.Headers["Authorization"] = "Basic " + authBytes;
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            return httpRequest;
        }
    }
}
#endif
