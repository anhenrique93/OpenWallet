using OpenWallet.Application.Models;
using OpenWallet.Application.ValueObjects;
using OpenWallet.Contracts.Requests;
using OpenWallet.Contracts.Responses;
using System.Runtime.CompilerServices;

namespace OpenWallet.Api.Mapping
{
    public static class ContractMapping
    {
        public static Account MapToAccount(this CreateAccountRequest request)
        {
            var type = AccountType.Create(request.Type);
            var currency = Currency.Create(request.Currency);
            var money = Money.Create(request.InitialBalance, currency);

            return new Account(
                name: request.Name,
                description: request.Description,
                type: type,
                money: money
            );
        }

        public static AccountResponse MapToResponse(this Account account)
        {
            var moneyResponse = new MoneyResponse
            {
                Amount = account.Money.Amount,
                Currency = account.Money.Currency.Code,
                Symbol = account.Money.Currency.Symbol,
                Name = account.Money.Currency.Name
            };

            return new AccountResponse
            {
                Id = account.Id,
                Name = account.Name,
                Description = account.Description,
                Type = account.Type.Name,
                Money = moneyResponse,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            };
        }

        public static AccountsResponse MapToResponse(this IEnumerable<Account> accounts)
        {
            return new AccountsResponse
            {
                Items = accounts.Select(MapToResponse),
            };
        }
    }
}