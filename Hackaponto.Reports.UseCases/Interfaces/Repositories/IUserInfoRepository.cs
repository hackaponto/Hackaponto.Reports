namespace Hackaponto.Reports.UseCases.Interfaces.Repositories
{
    public interface IUserInfoRepository
    {
        Task<Guid> GetUserId();
    }
}
