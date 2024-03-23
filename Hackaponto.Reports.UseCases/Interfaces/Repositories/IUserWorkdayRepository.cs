using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.UseCases.Interfaces.Repositories
{
    public interface IUserWorkdayRepository
    {
        IEnumerable<UserWorkday> Get(Guid userId, int year, int month);
    }
}
