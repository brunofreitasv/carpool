using Carpool.Application.Abstractions.Commands.Account;
using Carpool.Application.Abstractions.Gateway;
using Carpool.Application.Abstractions.Queries;
using Carpool.Application.Abstractions.Repositories;
using Carpool.Application.Commands.Account;
using Carpool.Data.InMemory.Queries;
using Carpool.Data.InMemory.Repositories;
using Carpool.Gateway.Mailer;

namespace Carpool.API
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMailerGateway, MailerGatewayFake>();
        }

        public static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ISignupCommand, SignupCommand>();
        }

        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IAccountQueries, AccountInMemoryQueries>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountInMemoryRepository>();
        }

        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddSingleton<Data.InMemory.Context>();
        }
    }
}
