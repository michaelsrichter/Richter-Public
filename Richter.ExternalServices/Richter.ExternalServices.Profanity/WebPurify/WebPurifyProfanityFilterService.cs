using System.IO;
using System.Net;
using Richter.ExternalServices.Profanity.Interfaces;

namespace Richter.ExternalServices.Profanity.WebPurify
{
    internal class WebPurifyProfanityFilterService : IProfanityFilterService
    {
        private readonly WebPurifySettings _webPurifySettings;

        public WebPurifyProfanityFilterService(WebPurifySettings webPurifySettings)
        {
            _webPurifySettings = webPurifySettings;
        }

        #region IProfanityFilterService Members

        public object Check(ProfanityFilterRequest request)
        {
            string url = string.Format(_webPurifySettings.Url,
                                       _webPurifySettings.ApiKey, request.Text);
            string xml = GetXml(url);
            return xml;
        }

        #endregion

        private static string GetXml(string url)
        {
            var req = (HttpWebRequest) WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            string xml;
            using (var sr = new StreamReader(resp.GetResponseStream()))
            {
                xml = sr.ReadToEnd();
            }
            return xml;
        }
    }
}