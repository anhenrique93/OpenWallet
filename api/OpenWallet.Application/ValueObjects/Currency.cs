using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.ValueObjects
{
    public record Currency
    {
        public string Code { get; init; } // e.g., "USD", "EUR"
        public string Symbol { get; init; } // e.g., "$", "€"
        public string Name { get; init; } // e.g., "United States Dollar", "Euro"
        private Currency() { }

        public static Currency Create(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || !ValidCodes.Contains(code.ToUpper()))
                throw new ArgumentException($"Invalid currency code: {code}. Valid codes are: {string.Join(", ", ValidCodes)}", nameof(code));

            return new Currency
            {
                Code = code.ToUpper(),
                Symbol = GetSymbol(code.ToUpper()),
                Name = GetName(code.ToUpper())
            };
        }

        private static readonly HashSet<string> ValidCodes = new()         {
            "USD", "EUR", "GBP", "JPY", "AUD", "CAD", "CHF", "CNY", "SEK", "NZD", "BRL"
        };

        private static string GetSymbol(string code) => code switch
        {
            "USD" => "$",
            "EUR" => "€",
            "GBP" => "£",
            "JPY" => "¥",
            "AUD" => "A$",
            "CAD" => "C$",
            "CHF" => "CHF",
            "CNY" => "¥",
            "SEK" => "kr",
            "NZD" => "$",
            "BRL" => "R$",
            _ => throw new ArgumentException($"Unsupported currency code: {code}", nameof(code))
        };

        private static string GetName(string code) => code switch
        {
            "USD" => "United States Dollar",
            "EUR" => "Euro",
            "GBP" => "British Pound Sterling",
            "JPY" => "Japanese Yen",
            "AUD" => "Australian Dollar",
            "CAD" => "Canadian Dollar",
            "CHF" => "Swiss Franc",
            "CNY" => "Chinese Yuan Renminbi",
            "SEK" => "Swedish Krona",
            "NZD" => "New Zealand Dollar",
            "BRL" => "Brazilian Real",
            _ => throw new ArgumentException($"Unsupported currency code: {code}", nameof(code))
        };

        public override string ToString() => $"{Name} ({Symbol})";
    }
}