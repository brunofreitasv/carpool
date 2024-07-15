using Carpool.Application.Abstractions.Queries;
using Carpool.Application.DTOs.Account;
using Carpool.Application.DTOs.Account.Outputs;

namespace Carpool.Data.InMemory.Queries
{
    public class AccountInMemoryQueries : IAccountQueries
    {
        private readonly Context _context;

        public AccountInMemoryQueries(Context context)
        {
            _context = context;
        }

        public Task<AccountResult> GetAccont(string accountId)
        {
            var account = _context.Accounts.Find(a => a.Id.ToString().Equals(accountId));

            if(account == null)
                throw new Exception($"The account {accountId} does not exists or is not processed yet.");
            
            return Task.FromResult(
                account.ToAccountResult()
            );
        }
    }
}
