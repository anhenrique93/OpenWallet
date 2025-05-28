using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; init; }
        public Currency Currency { get; init; }
        private Money() { }

        public static Money Create(decimal? amount, Currency? currency)
        {
            if (currency == null)
                throw new ArgumentException(nameof(currency));

            return new Money { Amount = amount ?? 0m, Currency = currency };
        }

        public Money Add(Money newMoney)
        {
            if (Currency != newMoney.Currency)
                throw new InvalidOperationException("Cannot add Money with different currencies");

            return new Money { Amount = Amount + newMoney.Amount, Currency = Currency };
        }

        public Money Subtract(Money newMoney)
        {
            if (Currency != newMoney.Currency)
                throw new InvalidOperationException("Cannot add Money with different currencies");

            return new Money { Amount = Amount - newMoney.Amount, Currency = Currency };
        }
    }
}
