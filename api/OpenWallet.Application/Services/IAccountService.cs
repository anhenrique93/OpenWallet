using OpenWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Services
{
    public interface IAccountService
    {
        Task<bool> CreateAsync(Account account);
        Task<Account?> GetByIdAsync(Guid id);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> UpdateAsync(Account account);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
