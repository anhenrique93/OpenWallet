using OpenWallet.Application.ValueObjects;

namespace OpenWallet.Application.Models
{
    public class Account
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Money Money { get; init; }
        public AccountType Type { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        // Constructor for NEW account (e.g., when creating a new account)
        public Account(string name, string description, AccountType type, Money money)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Type = type;
            Money = money;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Constructor for EXISTING account (e.g., loaded from database)
        public Account(Guid id, string name, string description, Money money, AccountType type, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Money = money;
            Type = type;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        protected Account() { }
    }
}
