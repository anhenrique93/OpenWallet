using Microsoft.AspNetCore.Mvc;
using OpenWallet.Api.Mapping;
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

        [HttpPost(ApiEndpoints.Accounts.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            var account = request.MapToAccount();

            var result = await _accountRepository.CreateAsync(account);
            return Created($"{ApiEndpoints.Accounts.Create}/{account.Id}", account);
        }
    }
}