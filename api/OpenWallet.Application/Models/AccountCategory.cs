using OpenWallet.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Models
{
    public class AccountCategory
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; }

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;

        public ICollection<Account> Accounts { get; init; } = new HashSet<Account>();

        public AccountCategory(string name) 
        { 
            Name = Guard.AgainstInvalidLength(name, 3, 20, nameof(name));
        }

        public AccountCategory(Guid id, string name, DateTime createdAt, DateTime updatedAt)
            : this(name)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static AccountCategory CreateSavingsCategory => new AccountCategory("Savings");
        public static AccountCategory CreateInvestmentsCategory => new AccountCategory("Investments");
        public static AccountCategory CreateExpensesCategory => new AccountCategory("Expenses");
        public static AccountCategory CreateIncomeCategory => new AccountCategory("Income");

        protected AccountCategory() { }
    }
}
