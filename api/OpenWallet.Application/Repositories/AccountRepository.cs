using OpenWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly List<Account> _accounts = new();

        public Task<bool> CreateAsync(Account account)
        {
            _accounts.Add(account);
            return Task.FromResult(true);
        }

        public Task<Account?> GetByIdAsync(Guid id)
        {
            var account = _accounts.SingleOrDefault(x => x.Id == id);
            return Task.FromResult(account);
        }

        public Task<IEnumerable<Account>> GetAllAsync()
        {
            return Task.FromResult(_accounts.AsEnumerable());
        }
        public Task<bool> UpdateAsync(Account account)
        {
            var accountIndex = _accounts.FindIndex(x => x.Id == account.Id);
            if (accountIndex == -1)
            {
                return Task.FromResult(false);
            }
            _accounts[accountIndex] = account;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            var removedCount = _accounts.RemoveAll(x => x.Id == id);
            var accountRemoved = removedCount > 0;
            return Task.FromResult(accountRemoved);
        }
    }
}
