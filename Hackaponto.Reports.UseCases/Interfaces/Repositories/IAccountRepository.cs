namespace Hackaponto.Reports.UseCases.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        string GetEmailById(Guid userId);
    }
}
