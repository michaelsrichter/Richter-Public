using System;
using System.IO;
using System.Net;
using System.Web;
using Richter.ExternalServices.UrlShortener.Entities;
using Richter.ExternalServices.UrlShortener.Interfaces;

namespace Richter.ExternalServices.UrlShortener.Bitly
{
    public class UrlShortenerService : IUrlShortenerService
    {
        public UrlShortenerResponse Request(UrlShortenerRequest request)
        {
            var resp = new UrlShortenerResponse {Created = DateTime.Now, Success = false};
            try
            {
                var req =
                    (HttpWebRequest)
                    WebRequest.Create(string.Format(request.ApiKey,
                                                    HttpUtility.UrlEncode(request.UrlToShorten.ToString())));
                req.Accept = "application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
                req.Method = "GET";
                var res = req.GetResponse();
                var stream = res.GetResponseStream();
                if (stream != null)
                    using (var read = new StreamReader(stream))
                    {
                        resp.Message = read.ReadToEnd();
                    }
                resp.Success = true;
                resp.ShortUrl = new Uri(resp.Message);
            }
            catch (Exception ex)
            {
                resp.Error = ex.ToString();
            }
            return resp;
        }
    }
}