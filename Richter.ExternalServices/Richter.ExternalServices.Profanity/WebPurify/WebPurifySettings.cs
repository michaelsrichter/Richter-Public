namespace Richter.ExternalServices.Profanity.WebPurify
{
    public class WebPurifySettings
    {
        public virtual string ApiKey { get { return "Test Key"; } }
        public virtual string Url { get { return "http://www.webpurify.com/services/rest/?method=webpurify.live.return&api_key={0}&text={1}"; } }
    }

    public class MyWebPurifySettings : WebPurifySettings
    {
        public override string ApiKey { get { return "1234567"; } }
    }
}