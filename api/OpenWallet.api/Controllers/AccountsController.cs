using Microsoft.AspNetCore.Mvc;
using OpenWallet.Application.Repositories;
using OpenWallet.Contracts.Requests;

namespace OpenWallet.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("accounts")]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            var account = new OpenWallet.Application.Models.Account
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Currency = request.Currency,
                Type = request.Type,
                Balance = request.InitialBalance,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _accountRepository.CreateAsync(account);
            return Created($"/api/accounts/{account.Id}", account);
        }
    }
}