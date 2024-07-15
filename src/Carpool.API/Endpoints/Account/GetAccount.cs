using Ardalis.ApiEndpoints;
using Carpool.Application.Abstractions.Queries;
using Carpool.Application.DTOs.Account.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Endpoints.Account
{
    public class GetAccount(IAccountQueries accountQueries) : EndpointBaseAsync
        .WithRequest<string>
        .WithActionResult<AccountResult>

    {
        [HttpGet("accounts/{accountId}")]
        public override async Task<ActionResult<AccountResult>> HandleAsync(string accountId, CancellationToken cancellationToken = default)
        {
            var account = await accountQueries.GetAccont(accountId);

            if (account == null)
                return NotFound();

            return Ok(account);
        }
    }
}
