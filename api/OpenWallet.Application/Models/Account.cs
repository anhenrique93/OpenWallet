using OpenWallet.Application.Helpers;
using OpenWallet.Application.ValueObjects;

namespace OpenWallet.Application.Models
{
    public class Account
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; }
        public string Description { get; init; }
        public Money Money { get; init; }
        public Guid CategoryId { get; init; }
        public AccountCategory Category { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

        // Constructor for NEW account (e.g., when creating a new account)
        public Account(string name, string description, AccountCategory category, Money money)
        {
            Name = Guard.AgainstInvalidLength(name, 3, 128, nameof(name));
            Description = Guard.AgainstInvalidLength(description, 10, 1000, nameof(description)); 
            Category = category;
            Money = money;
            CategoryId = category.Id;
        }

        // Constructor for EXISTING account (e.g., loaded from database)
        public Account(Guid id, string name, string description, Money money, AccountCategory category, DateTime createdAt, DateTime updatedAt)
            : this(name, description, category, money)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        protected Account() { }
    }
}
