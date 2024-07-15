using Carpool.Domain.Models.Account;

namespace Carpool.Data.InMemory
{
    public class Context
    {
        public List<Account> Accounts { get; set; }

        public Context()
        {
            Accounts = new List<Account>();
        }
    }
}
