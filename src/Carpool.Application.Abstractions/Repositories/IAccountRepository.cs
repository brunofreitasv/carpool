using Carpool.Domain.Models.Account;

namespace Carpool.Application.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAccontByEmail(string email);
        Task Save(Account account);
    }
}
