using System;
using System.Linq;
using System.Collections.Generic;
using Richter.ExternalServices.Translator.Microsoft;
using Richter.ExternalServices.Core;
namespace Richter.ExternalServices.Translator
{
    public class MicrosoftTranslatorService : ITranslatorService
    {
        private readonly ICacheService _cacheService;
            public MicrosoftTranslatorService(ICacheService cacheService)
            {
                _cacheService = cacheService;
            }

        public TranslationResponse Translate(TranslationRequest translationRequest)
        {
            var client = new LanguageServiceClient();
            var translationResponse = new TranslationResponse();
            translationResponse.Success = false;
            try
            {
                translationResponse.Result =
                    client.Translate(TranslatorAppId, translationRequest.TextToTranslate,
                                     translationRequest.LanguageFrom, translationRequest.LanguageTo, "text/plain",
                                     "general");
                translationResponse.Success = true;
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

        public IDictionary<string, string> TargetLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages)
        {
            return GetLanguages(translationRequest, addAdditionalLanguages);
        }

        public string TranslatorAppId { get; set; }

        private IDictionary<string, string> GetLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages)
        {
            var client = new LanguageServiceClient();

            var languageCodes = _cacheService.Get("MicrosoftTranslatorService.GetLanguagesForTranslate",
                                                 () => client.GetLanguagesForTranslate(TranslatorAppId));
            var languageNames = _cacheService.Get("MicrosoftTranslatorService.GetLanguageNames",
                                                 () =>
                                                 client.GetLanguageNames(TranslatorAppId,
                                                                         translationRequest.LanguageFrom,
                                                                         languageCodes));
            var dict = new  SortedDictionary<string, string>();
            for (var i = 0; i < languageCodes.Length; i++)
            {
                dict.Add(languageCodes[i], languageNames[i]);
            }
            if (addAdditionalLanguages)
            {
                dict.Add("tl", "Filipino");
            }
            var sortedDict = (from entry in dict orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            return sortedDict;
        }
    }
}