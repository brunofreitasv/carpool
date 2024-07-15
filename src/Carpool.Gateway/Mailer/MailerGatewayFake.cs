using Carpool.Application.Abstractions.Gateway;

namespace Carpool.Gateway.Mailer
{
    public class MailerGatewayFake : IMailerGateway
    {
        public Task SendEmail(string recipient, string subject, string body)
        {
            System.Diagnostics.Debug.WriteLine($"[Mailer Gateway] - Recipient: {recipient}, Subject: {subject}, Body:{body}");
            return Task.CompletedTask;
        }
    }
}
