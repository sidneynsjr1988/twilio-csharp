﻿#if NET35

using NUnit.Framework;
using System.Net;
using NSubstitute;
using System.Runtime.Serialization;
using System.IO;
using Twilio.Http;

namespace Twilio.Tests.Http
    {
        public MockRequest Request;
        public MockResponse Response;

        public WebRequest Create(Uri uri)
        {
            Console.WriteLine("Create Request");
            return this.Request;
        }

        public void Respond(HttpStatusCode statusCode, string content="")
        {
            this.Response = new MockResponse(statusCode, content);
            this.Request = new MockRequest(this.Response);
            Console.WriteLine("Setup response");
        }
    }
    {
        public MockResponse MockResponse;
        private MemoryStream _payloadStream;

        public MockRequest(MockResponse response) : base(new SerializationInfo(), new StreamingContext())
        {
            this.MockResponse = response;
            this._payloadStream = new MemoryStream();
        }

        public override WebResponse GetResponse()
        {
            Console.WriteLine("GetResponse");
            return this.MockResponse;
        }

        public Stream GetRequestStream()
        {
            Console.WriteLine("Write Payload");
            return this._payloadStream;
        }

        public string GetPayloadString()
        {
            return System.Text.Encoding.UTF8.GetString(this._payloadStream.ToArray());
        }
    }
    {
        public new HttpStatusCode StatusCode;
        private string _content;

        public MockResponse(HttpStatusCode statusCode, string content="") : base(Substitute.For<SerializationInfo>(), new StreamingContext())
        {
            this.StatusCode = statusCode;
            this._content = content;

        }

        public override Stream GetResponseStream()
        {
            Console.WriteLine("Read Response");
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(this._content));

        }
    }
        {
            this._mockHttp = new MockedWebRequestCreate();
            WebRequest.RegisterPrefix("unittest://", this._mockHttp);
            this.TwilioClient = new WebRequestClient();
        }
            //try {
            //    var httpReq = WebRequest.Create(new Uri("http://kjsadfkdasjfhsdkjfln.com"));
            //    var resp = (HttpWebResponse) httpReq.GetResponse();
            //    Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
            //} catch (WebException ex)
            //{
            //    Console.WriteLine("Status: " + ex.Status);
            //    Console.WriteLine("Response: " + (ex.Response == null ? "[null]" : ex.Response.ToString()));
            //    var errorResp = (HttpWebResponse) ex.Response;
            //    Console.WriteLine("Response Code: " + errorResp?.StatusCode);
            //}
            //Assert.AreEqual(false, true);
            this._mockHttp.Respond(HttpStatusCode.OK, "{'test': 'val'}");