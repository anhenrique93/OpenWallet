using Microsoft.AspNetCore.Mvc;
using OpenWallet.Api.Mapping;
using OpenWallet.Application.Services;
using OpenWallet.Contracts.Requests;
using System.Runtime.CompilerServices;

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
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest request,
            CancellationToken token)
        {
            var accountRequestDto = request.MapToAccountRequestDto();

            var accountResponseDto = await _accountService.CreateAsync(accountRequestDto, token);

            if (accountResponseDto is null) return BadRequest("Unable to create account. Invalid data or repository error.");

            var response = accountResponseDto.MapToResponse();
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Accounts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var accountResponseDto = await _accountService.GetByIdAsync(id);
            if (accountResponseDto is null) return NotFound();

            var response = accountResponseDto.MapToResponse();
            return Ok(response);
        }

        
        [HttpGet(ApiEndpoints.Accounts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var accountsResponseDto = await _accountService.GetAllAsync();

            var response = accountsResponseDto.MapToResponse();
            return Ok(response);
        }
        

        /*
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
        */

        [HttpDelete(ApiEndpoints.Accounts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var deleted = await _accountService.DeleteByIdAsync(id, token);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}