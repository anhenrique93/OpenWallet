using OpenWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> CreateAsync(Account account);
        Task<Account?> GetByIdAsync(Guid id);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<bool> UpdateAsync(Account account);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
