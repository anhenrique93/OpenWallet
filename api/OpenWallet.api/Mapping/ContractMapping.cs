using OpenWallet.Application.Models;
using OpenWallet.Contracts.Requests;
using System.Runtime.CompilerServices;

namespace OpenWallet.Api.Mapping
{
    public static class ContractMapping
    {
        public static Account MapToAccount(this CreateAccountRequest request)
        {
            return Account.CreateNewAccount(
                name: request.Name,
                description: request.Description,
                currency: request.Currency,
                type: request.Type,
                balance: request.InitialBalance
            );
        }
    }
}