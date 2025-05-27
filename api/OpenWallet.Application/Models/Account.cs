using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Models
{
    public class Account
    {
        public required Guid Id { get; init; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Currency { get; set; }
        public required string Type { get; set; } // e.g., "Checking", "Savings", "Credit Card" TODO: Create a AccountCategory class
        public required decimal Balance { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}