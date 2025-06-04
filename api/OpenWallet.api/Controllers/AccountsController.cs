using Microsoft.AspNetCore.Mvc;
using OpenWallet.Api.Mapping;
using OpenWallet.Application.Repositories;
using OpenWallet.Application.Services;
using OpenWallet.Application.ValueObjects;
using OpenWallet.Contracts.Requests;

namespace OpenWallet.Api.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(ApiEndpoints.Accounts.Create)]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request)
        {
            var account = request.MapToAccount();

            await _accountService.CreateAsync(account);
            var response = account.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = account.Id }, response);
        }

        [HttpGet(ApiEndpoints.Accounts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
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
            var accounts = await _accountService.GetAllAsync();
            var accountsResponse = accounts.MapToResponse();
            return Ok(accountsResponse);
        }

        [HttpPut(ApiEndpoints.Accounts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAccountRequest request)
        {
            var accountToUpdate = await _accountService.GetByIdAsync(id);
            if (accountToUpdate is null)
            {
                return NotFound();
            }

            var account = request.MapToAccount(
                id: id,
                createdAt: accountToUpdate.CreatedAt,
                amount: accountToUpdate.Money.Amount
            );

            var updatedAccount = await _accountService.UpdateAsync(account);
            if (updatedAccount is null) return NotFound();
            var response = updatedAccount.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Accounts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _accountService.DeleteByIdAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}