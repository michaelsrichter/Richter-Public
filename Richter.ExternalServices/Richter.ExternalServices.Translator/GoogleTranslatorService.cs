using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Richter.ExternalServices.Translator
{
    public class GoogleTranslatorService : ITranslatorService
    {
        public TranslationResponse Translate(TranslationRequest translationRequest)
        {
            var translationResponse = new TranslationResponse {Success = false};

            const string apiUrl = "https://www.googleapis.com/language/translate/v2?key={0}&source={1}&target={2}&q={3}";
            var url = String.Format(
                apiUrl,
                TranslatorAppId,
                translationRequest.LanguageFrom,
                translationRequest.LanguageTo, translationRequest.TextToTranslate);


            try
            {
                var req = WebRequest.Create(url);

                // set the request method
                req.Method = "GET";

                // get the response
                using (var res = req.GetResponse())
                {
                    if (res != null)
                    {
                        using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                        {
                            var json = sr.ReadToEnd();
                            var jsonobject = JObject.Parse(json);
                            IEnumerable<JToken> results = jsonobject["data"]["translations"].Children();
                            var translationResults = new List<TranslationResult>();
                            foreach (var result in results)
                            {
                                var ret = JsonConvert.DeserializeObject<TranslationResult>(result.ToString());
                                translationResults.Add(ret);
                            }
                            translationResponse.Result = translationResults[0].TranslatedText;
                            translationResponse.Success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                translationResponse.Error = ex.ToString();
                translationResponse.Success = false;
            }
            return translationResponse;
        }

        public IDictionary<string, string> SourceLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages)
        {
            return GetLanguages(translationRequest, addAdditionalLanguages);
        }

        private IDictionary<string, string> GetLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages) {
            const string apiUrl = "https://www.googleapis.com/language/translate/v2/languages?key={0}&target=en";
            var url = String.Format(
                apiUrl,
                TranslatorAppId);

            var dictionary = new Dictionary<string, string>();
            try
            {
                var req = WebRequest.Create(url);

                // set the request method
                req.Method = "GET";

                // get the response
                using (var res = req.GetResponse())
                {
                    if (res != null)
                    {
                        using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                        {
                            var json = sr.ReadToEnd();
                            var jsonobject = JObject.Parse(json);
                            IEnumerable<JToken> results = jsonobject["data"]["languages"].Children();
                            dictionary = results.ToDictionary(result => result["language"].ToString(), result => result["name"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                dictionary.Add("ex", ex.Message);
            }
            return dictionary;
        }

        public IDictionary<string, string> TargetLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages)
        {
            return GetLanguages(translationRequest, addAdditionalLanguages);
        }

        public string TranslatorAppId { get; set; }
    }
}