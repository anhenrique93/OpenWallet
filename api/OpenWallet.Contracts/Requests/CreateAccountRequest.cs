using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Requests
{
    public class CreateAccountRequest
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required string Currency { get; init; } // e.g., "USD", "EUR"
        public required string Category { get; init; } // e.g., "Checking", "Savings", "Credit Card"
        public decimal InitialAmount { get; init; }
    }
}
