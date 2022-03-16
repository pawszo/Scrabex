namespace Scrapex.Domain.ExtensionMethods
{
    public static class IntegerExtensionMethods
    {
        public static bool TryParseToEnum<T>(this int value, out T parsedValue) where T : struct
        {
            if (Enum.TryParse(value.ToString(), true, out parsedValue))
            {
                return true;
            }
            parsedValue = default;
            return false;
        }
    }
}
