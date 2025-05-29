using OpenWallet.Application.Models;
using OpenWallet.Application.ValueObjects;
using OpenWallet.Contracts.Requests;
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
    }
}