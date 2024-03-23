using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.UseCases.Interfaces.UseCases
{
    public interface IGetUserWorkdayUseCase
    {
        UserWorkday Execute(DateOnly date);
    }
}
