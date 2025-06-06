using OpenWallet.Application.Models;

namespace OpenWallet.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> CreateAsync(Account account, CancellationToken token = default);
        Task<Account?> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<IEnumerable<Account>> GetAllAsync(CancellationToken token = default);
        Task<bool> UpdateAsync(Account account, CancellationToken token = default);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    }
}
