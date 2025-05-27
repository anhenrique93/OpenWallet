using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Contracts.Responses
{
    public class AccountResponse
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required string Currency { get; init; }
        public required string Type { get; init; } // e.g., "Checking", "Savings", "Credit Card" TODO: Create a AccountCategory class
        public required decimal Balance { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required DateTime UpdatedAt { get; init; }
    }
}
