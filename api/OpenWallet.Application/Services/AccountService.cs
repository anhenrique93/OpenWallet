using FluentValidation;
using OpenWallet.Application.DTOs.Account;
using OpenWallet.Application.Models;
using OpenWallet.Application.Repositories;
using OpenWallet.Application.Validator;
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

        public async Task<AccountResponseDto> CreateAsync(CreateAccountRequestDto accountDto)
        {
            await _accountRequestDtoValidator.ValidateAndThrowAsync(accountDto);

            var accountCategory = await _accountCategoryRepository.GetByIdAsync(accountDto.AccountCategoryId);

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

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountResponseDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Account?> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
