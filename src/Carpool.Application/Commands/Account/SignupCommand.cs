using Carpool.Application.Abstractions.Commands.Account;
using Carpool.Application.Abstractions.Gateway;
using Carpool.Application.Abstractions.Repositories;
using Carpool.Application.DTOs.Account.Inputs;
using Carpool.Application.DTOs.Account.Outputs;
using Carpool.Application.DTOs.Account;

namespace Carpool.Application.Commands.Account
{
    public class SignupCommand(
        IAccountRepository accountRepository,
        IMailerGateway mailerGateway
        ) 
        : ISignupCommand
    {
        public async Task<SignupResult> Execute(SignupInput input)
        {
            var existingAccount = await accountRepository.GetAccontByEmail(input.Email);

            if (existingAccount != null)
                throw new ApplicationException("Account already exists");

            var account = input.ToAccount();
            await accountRepository.Save(account);

            if(mailerGateway != null)
                await mailerGateway.SendEmail(account.Email.Value, "Welcome!", "");

            return account.ToSignupResult();
        }
    }
}
