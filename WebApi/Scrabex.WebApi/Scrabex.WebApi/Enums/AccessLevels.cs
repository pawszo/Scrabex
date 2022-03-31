namespace Scrabex.WebApi.Enums
{
    [Flags] public enum AccessLevels : int
    {
        Anon = 0,
        AnonConsent = 1,
        Unconfirmed = 2,
        Standard = 3,
        Elevated = 4,
        Super = 5
    }
}