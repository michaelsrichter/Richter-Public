using System.Linq;
using System.Xml.Linq;
using Richter.ExternalServices.Profanity.Interfaces;

namespace Richter.ExternalServices.Profanity.WebPurify
{
    public class WebPurifyProfanityFilter : IProfanityFilter
    {
        private readonly IProfanityFilterService _profanityFilterService;

        public WebPurifyProfanityFilter(IProfanityFilterService profanityFilterService)
        {
            _profanityFilterService = profanityFilterService;
        }

        public ProfanityFilterResponse ContainsProfanity(ProfanityFilterRequest request)
        {
            ProfanityFilterResponse response;
            try
            {
                var x =
                    _profanityFilterService.Check(request)
                    as string;
                response = CreateProfanityFilterResponseFromXml(x);
            }
            catch (System.Exception e)
            {
                response = new ProfanityFilterResponse { Success = false, Error = e.ToString() };
                response.Success = false;
            }
            return response;
        }

        private static ProfanityFilterResponse CreateProfanityFilterResponseFromXml(string xml)
        {
            var xmlresponse = XDocument.Parse(xml);
            var count = 
                (xmlresponse.Elements("rsp").Select(x => x.Element("found").Value)).FirstOrDefault();
            var expletives = (from x in xmlresponse.Descendants("expletive") select x.Value).ToArray();
            var response = new ProfanityFilterResponse
                               {
                                   Count = int.Parse(count),
                                   Expletives = expletives,
                                   Success = true,
                                   ContainsProfanity = int.Parse(count) > 0 ? true : false
                               };
            response.Result = string.Format("count = {0}; expletives = '{1}'",
                                            response.Count,
                                            string.Join(", ", response.Expletives));
            return response;
        }
    }
}