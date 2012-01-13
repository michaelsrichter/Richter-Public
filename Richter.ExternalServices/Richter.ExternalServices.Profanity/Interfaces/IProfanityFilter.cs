namespace Richter.ExternalServices.Profanity.Interfaces
{
    public interface IProfanityFilter
    {
        ProfanityFilterResponse ContainsProfanity(ProfanityFilterRequest request);
    }
}