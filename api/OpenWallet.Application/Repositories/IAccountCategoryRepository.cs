using OpenWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Repositories
{
    public interface IAccountCategoryRepository
    {
        Task<bool> CreateAsync(AccountCategory category, CancellationToken token = default);
        Task<AccountCategory?> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<IEnumerable<AccountCategory>> GetAllAsync(CancellationToken token = default);
        Task<bool> UpdateAsync(AccountCategory category, CancellationToken token = default);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    }
}
