using Microsoft.AspNetCore.Mvc;
using OpenWallet.Api.Mapping;
using OpenWallet.Application.Repositories;
using OpenWallet.Contracts.Requests;

namespace OpenWallet.Api.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost(ApiEndpoints.Accounts.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            var account = request.MapToAccount();

            await _accountRepository.CreateAsync(account);
            var response = account.MapToResponse();
            return Created($"/{ApiEndpoints.Accounts.Create}/{account.Id}", response);
        }

        [HttpGet(ApiEndpoints.Accounts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account is null)
            {
                return NotFound();
            }

            var response = account.MapToResponse();
            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Accounts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _accountRepository.GetAllAsync();
            var accountsResponse = accounts.MapToResponse();
            return Ok(accountsResponse);
        }
    }
}