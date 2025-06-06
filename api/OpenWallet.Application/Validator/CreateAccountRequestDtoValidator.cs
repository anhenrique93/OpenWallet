using FluentValidation;
using OpenWallet.Application.DTOs.Account;

namespace OpenWallet.Application.Validator
{
    public class CreateAccountRequestDtoValidator : AbstractValidator<CreateAccountRequestDto>
    {
        public CreateAccountRequestDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Account name is required.")
                .MaximumLength(30).WithMessage("Account name must not exceed 30 characters.")
                .MinimumLength(3).WithMessage("Account name must be at least 3 characters long.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Account description is required.")
                .MaximumLength(1000).WithMessage("Account description must not exceed 1000 characters.")
                .MinimumLength(10).WithMessage("Account description must be at least 10 characters long.");

            RuleFor(dto => dto.Currency)
                .NotEmpty().WithMessage("Currency code is required.");

            _ = RuleFor(dto => dto.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount must be greater than or equal to zero if provided.");

            RuleFor(dto => dto.AccountCategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
        }
    }
}
