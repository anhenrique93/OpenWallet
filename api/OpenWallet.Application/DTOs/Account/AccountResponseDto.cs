using OpenWallet.Application.Models;
using OpenWallet.Application.ValueObjects;

namespace OpenWallet.Application.DTOs.Account
{
    public record AccountResponseDto(
        Guid Id, 
        string Name, 
        string Description, 
        Money Money, 
        string Category, 
        DateTime CreatedAt, 
        DateTime UpdatedAt
    );
}
