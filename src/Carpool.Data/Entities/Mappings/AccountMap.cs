using Carpool.Application.DTOs.Account.Outputs;
using AccountModel = Carpool.Domain.Models.Account.Account;

namespace Carpool.Data.Entities.Mappings
{
    internal static class AccountMap
    {
        internal static Account ToDbEntity(this AccountModel account)
        {
            return new Account()
            {
                AccountId = account.Id,
                Name = account.Name.Value,
                Email = account.Email.Value,
                Cpf = account.Cpf.Value,
                CarPlate = account.CarPlate.Value,
                IsPassenger = account.IsPassenger ?? false,
                IsDriver = account.IsDriver ?? false
            };
        }

        internal static AccountModel ToDomainModel(this Account entity)
        {
            return new AccountModel(
                    entity.AccountId,
                    entity.Name,
                    entity.Email,
                    entity.Cpf,
                    entity.CarPlate,
                    entity.IsPassenger,
                    entity.IsDriver);
        }

        internal static AccountResult ToAccountResult(this Account entity)
        {
            return new AccountResult()
            {
                AccountId = entity.AccountId.ToString(),
                Name = entity.Name,
                Email = entity.Email,
                Cpf = entity.Cpf,
                CarPlate = entity.CarPlate,
                IsPassenger = entity.IsPassenger,
                IsDriver = entity.IsDriver
            };
        }
    }
}
