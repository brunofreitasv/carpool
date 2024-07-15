
namespace Carpool.Application.Abstractions.Gateway
{
    public interface IMailerGateway
    {
        Task SendEmail(string recipient, string subject, string body);
    }
}
