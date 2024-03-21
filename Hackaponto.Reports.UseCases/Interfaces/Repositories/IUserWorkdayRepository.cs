using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.UseCases.Interfaces.Repositories
{
    public interface IUserWorkdayRepository
    {
        List<UserWorkday> Get(Guid userId, int year, int month);
    }
}
