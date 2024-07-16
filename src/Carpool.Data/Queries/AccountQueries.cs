using Carpool.Application.Abstractions.Queries;
using Carpool.Application.DTOs.Account.Outputs;
using Carpool.Data.Entities.Mappings;

namespace Carpool.Data.Queries
{
    public class AccountQueries : IAccountQueries
    {
        private readonly Context _context;

        public AccountQueries(Context context)
        {
            _context = context;
        }

        public async Task<AccountResult> GetAccont(string accountId)
        {
            var accountEntity = await _context.Accounts.FindAsync(new Guid(accountId));

            if (accountEntity == null)
                throw new Exception($"The account {accountId} does not exists or is not processed yet.");

            return accountEntity.ToAccountResult();
        }
    }
}
