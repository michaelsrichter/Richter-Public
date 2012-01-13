using System;

namespace Richter.ExternalServices.UrlShortener.Entities
{
    public class UrlShortenerRequest
    {
        public Uri UrlToShorten { get; set; }
        public string ApiKey { get; set; }
    }
}