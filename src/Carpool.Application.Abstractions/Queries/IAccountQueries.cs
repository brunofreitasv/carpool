using Carpool.Application.DTOs.Account.Outputs;

namespace Carpool.Application.Abstractions.Queries
{
    public interface IAccountQueries
    {
        Task<AccountResult> GetAccont(string accountId);
    }
}
