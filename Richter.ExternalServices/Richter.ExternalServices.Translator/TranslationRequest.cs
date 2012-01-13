namespace Richter.ExternalServices.Translator
{
    public class TranslationRequest
    {
        public string TextToTranslate { get; set; }
        public string LanguageFrom { get; set; }
        public string LanguageTo { get; set; }
    }
}