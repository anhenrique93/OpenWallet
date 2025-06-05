using OpenWallet.Application.Models;
using OpenWallet.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Services
{
    public class AccountCategoryService : IAccountCategoryService
    {

        private readonly IAccountCategoryRepository _accountCategoryRepository;

        public AccountCategoryService(IAccountCategoryRepository accountCategoryRepository)
        {
            _accountCategoryRepository = accountCategoryRepository;
        }

        public Task<bool> CreateAsync(AccountCategory category)
        {
            return _accountCategoryRepository.CreateAsync(category);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            return _accountCategoryRepository.DeleteByIdAsync(id);
        }

        public Task<IEnumerable<AccountCategory>> GetAllAsync()
        {
            return _accountCategoryRepository.GetAllAsync();
        }

        public Task<AccountCategory?> GetByIdAsync(Guid id)
        {
            return _accountCategoryRepository.GetByIdAsync(id);
        }

        public async Task<AccountCategory?> UpdateAsync(AccountCategory category)
        {
            var categoryExists = await _accountCategoryRepository.GetByIdAsync(category.Id);
            if (categoryExists is null)
            {
                return null;
            }

            await _accountCategoryRepository.UpdateAsync(category);
            return category;
        }
    }
}
