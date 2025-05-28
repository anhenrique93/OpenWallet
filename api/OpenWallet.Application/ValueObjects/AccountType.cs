namespace OpenWallet.Application.ValueObjects
{
    public record AccountType
    {
        public string Name { get; init; } // e.g., "United States Dollar", "Euro"
        private AccountType() { }

        public static AccountType Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !ValidAccountTypes.Contains(name.ToUpper()))
                throw new ArgumentException("Account type cannot be empty.", nameof(name));

            return new AccountType
            {
                Name = Normalize(name)
            };
        }

        private static string Normalize(string s) => System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLowerInvariant());

        private static readonly HashSet<string> ValidAccountTypes = new()
        {
            "CHECKING",
            "SAVINGS",
            "CREDIT CARD",
            "INVESTMENT",
            "LOAN",
            "CASH"
        };
    }
}