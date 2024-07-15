using Carpool.Application.DTOs.Account.Inputs;
using Carpool.Application.DTOs.Account.Outputs;

namespace Carpool.Application.Abstractions.Commands.Account
{
    public interface ISignupCommand : ICommand<SignupInput, SignupResult>
    {
    }
}
