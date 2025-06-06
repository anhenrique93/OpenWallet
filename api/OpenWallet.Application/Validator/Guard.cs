namespace OpenWallet.Application.Helpers
{
    public static class Guard
    {
        public static string AgainstInvalidLength(string value, int min, int max, string paramName)
        {
            if (string.IsNullOrEmpty(value) || value.Length < min || value.Length > max)
            {
                throw new ArgumentException($"'{paramName}' must be between {min} and {max} characters long.");
            }
            return value;
        }

        public static decimal AgainstInitialValidAmount(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Initial amount must be a non-negative value.");
            }
            return value;
        }
    }
}