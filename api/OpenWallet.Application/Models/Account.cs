using OpenWallet.Application.ValueObjects;

namespace OpenWallet.Application.Models
{
    public class Account
    {
        protected Account() { } // EF Core

        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Money Money { get; private set; }
        public AccountType Type { get; private set; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; private set; }

        public Account (string name, string description, AccountType type, Money money)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Type = type;
            Money = money;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
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
        public void UpdateType(AccountType type)
        {
            Type = type;
            UpdatedAt = DateTime.UtcNow;
        }
        public void AddMoney(Money other)
        {
            Money = Money.Add(other);
            UpdatedAt = DateTime.UtcNow;
        }
        public void SubtractMoney(Money other)
        {
            Money = Money.Subtract(other);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}