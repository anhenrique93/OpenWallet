using OpenWallet.Application.Models;
using OpenWallet.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Services
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<bool> CreateAsync(Account account)
        {
            return _accountRepository.CreateAsync(account);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            return _accountRepository.DeleteByIdAsync(id);
        }

        public Task<IEnumerable<Account>> GetAllAsync()
        {
            return _accountRepository.GetAllAsync();
        }

        public Task<Account?> GetByIdAsync(Guid id)
        {
            return _accountRepository.GetByIdAsync(id);
        }

        public async Task<Account?> UpdateAsync(Account account)
        {
            var accountExists = await _accountRepository.GetByIdAsync(account.Id);
            if (accountExists is null)
            {
                return null;
            }

            await _accountRepository.UpdateAsync(account);
            return account;
        }
    }
}
