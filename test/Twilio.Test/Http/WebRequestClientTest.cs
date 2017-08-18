﻿#if NET35

using NUnit.Framework;using System;
using System.Net;
using NSubstitute;
using System.Runtime.Serialization;
using System.IO;
using Twilio.Http;
using Moq;


namespace Twilio.Tests.Http{    public class MockedWebRequestCreate : IWebRequestCreate
    {
        public WebRequest Request;
        public WebResponse Response;

        public WebRequest Create(Uri uri)
        {
            Console.WriteLine("Create Request");
            //return this.Request;
            return null;
        }

        public void Respond(HttpStatusCode statusCode, string content="")
        {
            //HttpWebResponse = new Mock<HttpWebResponse>(MockBehavior.Loose);
            Console.WriteLine("Setup response");
        }
    }    [TestFixture]    public class WebRequestClientTest : TwilioTest    {        private MockedWebRequestCreate _mockHttp;        public WebRequestClient TwilioClient;        [SetUp]        public void Init()
        {
            this._mockHttp = new MockedWebRequestCreate();
            WebRequest.RegisterPrefix("unittest://", this._mockHttp);
            this.TwilioClient = new WebRequestClient();
        }        [Test]        public void TestMakeRequestSuccess()        {
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
            this._mockHttp.Respond(HttpStatusCode.OK, "{'test': 'val'}");            var response = this.TwilioClient.MakeRequest(new Request(HttpMethod.Get, "unittest://api.twilio.com/v1/Resource.json"));            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);            Assert.AreEqual("{'test': 'val'}", response.Content);        }        [Test]        public void TestMakeRequestReturnsNon200()        {            // throws WebException for >= 300            // Response is set if we got one else we should throw        }        [Test]        public void TestMakeRequestThrowsOnConnectionError()        {        }        [Test]        public void TestMakeRequestWithParams()        {        }        [Test]        public void TestMakeRequestAddsHeaderAndUserAgent()        {        }    }}#endif