using System;
using Richter.ExternalServices.Core;

namespace Richter.ExternalServices.UrlShortener.Entities
{
    public class UrlShortenerResponse : ServiceResponse
    {
        public Uri ShortUrl { get; set; }

    }
}