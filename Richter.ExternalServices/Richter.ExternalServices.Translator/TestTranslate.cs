using NUnit.Framework;

namespace Richter.ExternalServices.Translator
{
    [TestFixture]
    public class TestTranslate
    {
        [Test]
        public void TestGoogle()
        {
            var request = new TranslationRequest()
                              {
                                  LanguageFrom = "en",
                                  LanguageTo = "ru",
                                  TextToTranslate = "Goodbye"
                              };
            var service = new GoogleTranslatorService();
            service.TranslatorAppId = "INSERTAPPIDHERE";
            var resp = service.Translate(request);

            Assert.IsNotNull(resp);
            Assert.IsNotNullOrEmpty(resp.Result);
        }
    }
}