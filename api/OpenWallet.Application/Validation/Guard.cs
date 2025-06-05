using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
