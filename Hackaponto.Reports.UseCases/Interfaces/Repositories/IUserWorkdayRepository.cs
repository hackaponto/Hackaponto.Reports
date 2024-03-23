using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.UseCases.Interfaces.Repositories
{
    public interface IUserWorkdayRepository
    {
        IEnumerable<UserWorkday> GetAll(Guid userId, int year, int month);
        UserWorkday Get(Guid userId, DateOnly date);
    }
}
