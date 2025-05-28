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

            var currency = Currency.Create(request.Currency);

            return Account.CreateNewAccount(
                name: request.Name,
                description: request.Description,
                currency: currency,
                type: request.Type,
                balance: request.InitialBalance
            );
        }
    }
}