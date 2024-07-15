using Carpool.Application.DTOs.Account.Inputs;
using Carpool.Application.DTOs.Account.Outputs;
using AccountModel = Carpool.Domain.Models.Account.Account;

namespace Carpool.Application.DTOs.Account
{
    public static class Mappings
    {
        public static AccountModel ToAccount(this SignupInput input)
        {
            return AccountModel.Create(
                input.Name,
                input.Email,
                input.Cpf,
                input.CarPlate,
                input.IsPassenger ?? false,
                input.IsDriver ?? false
            );
        }

        public static AccountResult ToAccountResult(this AccountModel account)
        {
            return new AccountResult()
            {
                AccountId = account.Id.ToString(),
                Name = account.Name.Value,
                Email = account.Email.Value,
                Cpf = account.Cpf.Value,
                CarPlate = account.CarPlate.Value,
                IsPassenger = account.IsPassenger.Value,
                IsDriver = account.IsDriver.Value,
            };
        }

        public static SignupResult ToSignupResult(this AccountModel account)
        {
            return new SignupResult()
            {
                AccountId = account.Id.ToString()
            };
        }
    }
}
