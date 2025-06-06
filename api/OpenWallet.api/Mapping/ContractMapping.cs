using OpenWallet.Application.DTOs.Account;
using OpenWallet.Contracts.Requests;
using OpenWallet.Contracts.Responses;

namespace OpenWallet.Api.Mapping
{
    public static class ContractMapping
    {
        public static CreateAccountRequestDto MapToAccountRequestDto(this CreateAccountRequest request)
        {
            return new CreateAccountRequestDto(
                request.Name,
                request.Description,
                request.Currency,
                request.InitialAmount,
                request.CategoryId
            );
        }

        public static AccountResponse MapToResponse(this AccountResponseDto dto)
        {
            var money = new MoneyResponse
            {
                Amount = dto.Money.Amount,
                Currency = dto.Money.Currency.Code,
                Symbol = dto.Money.Currency.Symbol,
                Name = dto.Money.Currency.Name
            };

            return new AccountResponse
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Money = money,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }
    }
}