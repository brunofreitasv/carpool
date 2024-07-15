using Carpool.Application.Abstractions.Repositories;
using Carpool.Domain.Models.Account;

namespace Carpool.Data.InMemory.Repositories
{
    public class AccountInMemoryRepository : IAccountRepository
    {
        private readonly Context _context;

        public AccountInMemoryRepository(Context context)
        {
            _context = context;
        }

        public Task<Account> GetAccontByEmail(string email)
        {
            var account = _context.Accounts.Find(a => a.Email.Value.Equals(email));
            return Task.FromResult(account);
        }

        public Task Save(Account account)
        {
            _context.Accounts.Add(account);
            return Task.CompletedTask;
        }
    }
}
