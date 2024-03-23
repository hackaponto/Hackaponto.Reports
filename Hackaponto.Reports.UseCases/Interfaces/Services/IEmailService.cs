namespace Hackaponto.Reports.UseCases.Interfaces.Gateways
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string body);
    }
}
