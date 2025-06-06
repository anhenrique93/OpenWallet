using OpenWallet.Application.DTOs.Account;
using OpenWallet.Application.Models;
using OpenWallet.Application.Repositories;
using OpenWallet.Application.ValueObjects;

namespace OpenWallet.Application.Services
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IAccountCategoryRepository _accountCategoryRepository;

        public AccountService(IAccountRepository accountRepository, IAccountCategoryRepository accountCategoryRepository)
        {
            _accountRepository = accountRepository;
            _accountCategoryRepository = accountCategoryRepository;
        }

        public async Task<AccountResponseDto> CreateAsync(CreateAccountRequestDto accountDto)
        {
            var accountCategory = await _accountCategoryRepository.GetByIdAsync(accountDto.AccountCategoryId);

            if (accountCategory is null)
            {
                return null;
            }

            var currency = Currency.Create(accountDto.Currency);
            var money = Money.Create(accountDto.Amount, currency);


            var account = new Account(
                name: accountDto.Name,
                description: accountDto.Description,
                category: accountCategory,
                money: money
            );

            var result = await _accountRepository.CreateAsync(account);

            if (!result) return null;

            return new AccountResponseDto
            (
                account.Id,
                account.Name,
                account.Description,
                account.Money,
                accountCategory.Name,
                account.CreatedAt,
                account.UpdatedAt
            );
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountResponseDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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
