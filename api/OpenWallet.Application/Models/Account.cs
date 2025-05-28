using OpenWallet.Application.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Models
{
    public class Account
    {
        protected Account() { } // EF Core

        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Currency Currency { get; private set; }
        public string Type { get; private set; } // e.g., "Checking", "Savings", "Credit Card" TODO: Create a AccountCategory class
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; private set; }

        public static Account CreateNewAccount(string name, string description, Currency currency, string type, decimal? balance)
        {
            return new Account
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Currency = currency,
                Type = type,
                Balance = balance ?? 0m, // Default to 0 if no initial balance is provided
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateName(string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateType(string type)
        {
            Type = type;
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateBalance(decimal value)
        {
            Balance += value;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}