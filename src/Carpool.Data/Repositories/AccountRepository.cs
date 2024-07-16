using Carpool.Application.Abstractions.Repositories;
using Carpool.Data.Entities.Mappings;
using Carpool.Domain.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Carpool.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public async Task<Account> GetAccontByEmail(string email)
        {
            var accountEntity = await _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
            return accountEntity != null ? accountEntity.ToDomainModel() : null;
        }

        public async Task Save(Account account)
        {
            await _context.Accounts.AddAsync(account.ToDbEntity());
            await _context.SaveChangesAsync();
        }
    }
}
