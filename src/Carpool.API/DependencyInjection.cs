using Carpool.Application.Abstractions.Commands.Account;
using Carpool.Application.Abstractions.Gateway;
using Carpool.Application.Abstractions.Queries;
using Carpool.Application.Abstractions.Repositories;
using Carpool.Application.Commands.Account;
using Carpool.Data.Queries;
using Carpool.Data.Repositories;
using Carpool.Gateway.Mailer;
using Microsoft.EntityFrameworkCore;

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
            services.AddScoped<IAccountQueries, AccountQueries>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Data.Context>(opt => opt.UseMySQL(connectionString));
        }
    }
}
