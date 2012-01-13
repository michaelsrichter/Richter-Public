using Richter.ExternalServices.UrlShortener.Entities;

namespace Richter.ExternalServices.UrlShortener.Interfaces
{
    public interface IUrlShortenerService
    {
        UrlShortenerResponse Request(UrlShortenerRequest request);
    }
}