namespace OpenWallet.Application.DTOs.Account
{
    public record CreateAccountRequestDto(
        string Name, 
        string Description, 
        string Currency, 
        decimal Amount,
        Guid AccountCategoryId
    );
}