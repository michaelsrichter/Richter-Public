using System;
using NUnit.Framework;
using Richter.ExternalServices.UrlShortener.Bitly;
using Richter.ExternalServices.UrlShortener.Entities;

namespace Richter.ExternalServices.Tests.UrlShortener.Bitly
{
    [TestFixture]
    public class TestBiltyService
    {
        [Test]
        public void TestUrlShortenerBitlyService()
        {
            var request = new UrlShortenerRequest()
                              {
                                  ApiKey = "INSERTAPIKEYHERE",
                                  UrlToShorten = new Uri("http://www.google.com")
                              };
            var service = new UrlShortenerService();
            var response = service.Request(request);
            Assert.AreEqual("EXPECTEDURLHERE", response.ShortUrl.ToString());
        }
    }
}