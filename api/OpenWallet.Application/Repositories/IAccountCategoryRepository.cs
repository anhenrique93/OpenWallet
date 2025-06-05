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
        Task<bool> CreateAsync(AccountCategory category);
        Task<AccountCategory?> GetByIdAsync(Guid id);
        Task<IEnumerable<AccountCategory>> GetAllAsync();
        Task<bool> UpdateAsync(AccountCategory category);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
