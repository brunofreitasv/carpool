using Ardalis.ApiEndpoints;
using Carpool.Application.Abstractions.Commands.Account;
using Carpool.Application.DTOs.Account.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.API.Endpoints.Account
{
    public class PostSignup(ISignupCommand signupCommand) : EndpointBaseAsync
         .WithRequest<SignupInput>
         .WithActionResult<string>

    {
        [HttpPost("signup")]
        public override async Task<ActionResult<string>> HandleAsync(SignupInput input, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await signupCommand.Execute(input);
                return Ok(result.AccountId);
            }
            catch (Exception ex) 
            {
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}
