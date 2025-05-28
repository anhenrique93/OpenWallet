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

            return Account.CreateNewAccount(
                name: request.Name,
                description: request.Description,
                currency: currency,
                type: type,
                balance: request.InitialBalance
            );
        }
    }
}