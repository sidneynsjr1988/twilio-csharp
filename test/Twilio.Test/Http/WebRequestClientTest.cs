#if NET35

using NUnit.Framework;using System;
using System.Net;
using NSubstitute;
using System.Runtime.Serialization;

namespace Twilio.Tests.Http{    public class MockedWebRequestCreate : IWebRequestCreate
    {
        public WebRequest Request = Substitute.For<HttpWebRequest>();

        public WebRequest Create(Uri uri)
        {
            return this.Request;
        }
    }    public class MockResponse : HttpWebResponse
    {
        public MockResponse(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public 
    }    [TestFixture]    public class WebRequestClientTest : TwilioTest    {        private MockedWebRequestCreate _mockHttp;        private void Respond(HttpStatusCode status, String content="")
        {
            WebResponse resp = Substitute.For<HttpWebResponse>();
            resp.StatusCode.Returns(status);
            this._mockHttp.Request.GetResponse().Returns()
        }        [SetUp]        public void Init()
        {
            this._mockHttp = new MockedWebRequestCreate();
            WebRequest.RegisterPrefix("http://api.fake.com", this._mockHttp);
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

            this._mockHttp.Request.GetResponse().Returns()        }        [Test]        public void TestMakeRequestReturnsNon200()        {            // throws WebException for >= 300            // Response is set if we got one else we should throw        }        [Test]        public void TestMakeRequestThrowsOnConnectionError()        {        }        [Test]        public void TestMakeRequestWithParams()        {        }        [Test]        public void TestMakeRequestAddsHeaderAndUserAgent()        {        }    }}#endif