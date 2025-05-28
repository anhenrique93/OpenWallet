using OpenWallet.Application.Models;
using OpenWallet.Application.ValueObjects;
using OpenWallet.Contracts.Requests;

namespace OpenWallet.Api.Mapping
{
    public static class ContractMapping
    {
        public static Account MapToAccount(this CreateAccountRequest request)
        {
            var currency = Currency.Create(request.Currency);
            var type = AccountType.Create(request.Type);
            var money = Money.Create(request.InitialBalance, currency);

            return Account.CreateNewAccount(
                name: request.Name,
                description: request.Description,
                type: type,
                money: money
            );
        }
    }
}