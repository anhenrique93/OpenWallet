using OpenWallet.Application.DTOs.Account;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Services
{
    public interface IAccountService
    {
        Task<AccountResponseDto> CreateAsync(CreateAccountRequestDto accountDto, CancellationToken token = default);
        Task<AccountResponseDto?> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<IEnumerable<AccountResponseDto>> GetAllAsync(CancellationToken token = default);
        Task<Account?> UpdateAsync(Account account, CancellationToken token = default);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    }
}