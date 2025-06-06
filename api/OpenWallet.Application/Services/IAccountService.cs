using OpenWallet.Application.DTOs.Account;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Services
{
    public interface IAccountService
    {
        Task<AccountResponseDto> CreateAsync(CreateAccountRequestDto accountDto);
        Task<AccountResponseDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<AccountResponseDto>> GetAllAsync();
        Task<Account?> UpdateAsync(Account account);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}