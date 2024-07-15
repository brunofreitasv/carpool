namespace Carpool.Application.Abstractions.Commands
{
    public interface ICommand<TInput, TOutput> 
        where TInput : class 
        where TOutput : class
    {
        Task<TOutput> Execute(TInput input);
    }
}