using System.Collections.Generic;

namespace Richter.ExternalServices.Translator
{
    public interface ITranslatorService
    {
        TranslationResponse Translate(TranslationRequest translationRequest);
        IDictionary<string, string> SourceLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages);
        IDictionary<string, string> TargetLanguages(TranslationRequest translationRequest, bool addAdditionalLanguages);
        string TranslatorAppId { get; set; }
    }
}