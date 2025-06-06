using FluentValidation;
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
        private readonly IValidator<CreateAccountRequestDto> _accountRequestDtoValidator;

        public AccountService(IAccountRepository accountRepository, IAccountCategoryRepository accountCategoryRepository, IValidator<CreateAccountRequestDto> accountRequestDtoValidator)
        {
            _accountRepository = accountRepository;
            _accountCategoryRepository = accountCategoryRepository;
            _accountRequestDtoValidator = accountRequestDtoValidator;
        }

        public async Task<AccountResponseDto> CreateAsync(CreateAccountRequestDto accountDto, CancellationToken token = default)
        {
            await _accountRequestDtoValidator.ValidateAndThrowAsync(accountDto, token);

            var accountCategory = await _accountCategoryRepository.GetByIdAsync(accountDto.AccountCategoryId, token);

            if (accountCategory is null)
                throw new DomainException("Invalid account category.");

            var currency = Currency.Create(accountDto.Currency);
            var money = Money.Create(accountDto.Amount, currency);

            var account = new Account(
                name: accountDto.Name,
                description: accountDto.Description,
                category: accountCategory,
                money: money
            );

            var result = await _accountRepository.CreateAsync(account, token);

            if (!result) throw new DomainException("Unable to create account. Repository error.");

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
        public async Task<AccountResponseDto?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var account = await _accountRepository.GetByIdAsync(id, token);

            if (account is null) return null;

            return new AccountResponseDto
           (
               account.Id,
               account.Name,
               account.Description,
               account.Money,
               account.Category.Name,
               account.CreatedAt,
               account.UpdatedAt
           );
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            return await _accountRepository.DeleteByIdAsync(id, token);
        }

        public async Task<IEnumerable<AccountResponseDto>> GetAllAsync(CancellationToken token = default)
        {
            var accounts = await _accountRepository.GetAllAsync(token);
            return accounts.Select(account => new AccountResponseDto
            (
                account.Id,
                account.Name,
                account.Description,
                account.Money,
                account.Category.Name,
                account.CreatedAt,
                account.UpdatedAt
            ));
        }

        public async Task<AccountResponseDto> UpdateAsync(Account account, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
