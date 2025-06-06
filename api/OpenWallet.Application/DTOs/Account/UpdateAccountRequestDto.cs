namespace OpenWallet.Application.DTOs.Account
{
    public record UpdateAccountRequestDto(string Name, string Description, string Currency, string Category);
}