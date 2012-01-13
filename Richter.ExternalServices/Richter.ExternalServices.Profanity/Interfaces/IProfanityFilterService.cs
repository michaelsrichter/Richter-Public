namespace Richter.ExternalServices.Profanity.Interfaces
{
    public interface IProfanityFilterService
    {
        object Check(ProfanityFilterRequest request);
    }
}