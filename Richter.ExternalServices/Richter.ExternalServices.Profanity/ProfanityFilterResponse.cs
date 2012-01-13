using Richter.ExternalServices.Core;

namespace Richter.ExternalServices.Profanity
{
    public sealed class ProfanityFilterResponse : ServiceResponse
    {
        public int Count { get; set; }
        public string[] Expletives { get; set; }
        public bool ContainsProfanity { get; set; }
    }
}