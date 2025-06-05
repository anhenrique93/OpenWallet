using OpenWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Services
{
    public interface IAccountCategoryService
    {
        Task<bool> CreateAsync(AccountCategory category);
        Task<AccountCategory?> GetByIdAsync(Guid id);
        Task<IEnumerable<AccountCategory>> GetAllAsync();
        Task<AccountCategory?> UpdateAsync(AccountCategory account);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
