using Microsoft.AspNetCore.Mvc;
using OpenWallet.Api.Mapping;
using OpenWallet.Application.Repositories;
using OpenWallet.Application.ValueObjects;
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
            return CreatedAtAction(nameof(Get), new { id = account.Id }, response);
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

        [HttpPut(ApiEndpoints.Accounts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAccountRequest request)
        {
            var accountToUpdate = await _accountRepository.GetByIdAsync(id);
            if (accountToUpdate is null)
            {
                return NotFound();
            }

            var account = request.MapToAccount(
                id: id,
                createdAt: accountToUpdate.CreatedAt,
                amount: accountToUpdate.Money.Amount
            );

            var updated = await _accountRepository.UpdateAsync(account);
            if (!updated) return NotFound();
            var response = account.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Accounts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _accountRepository.DeleteByIdAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}