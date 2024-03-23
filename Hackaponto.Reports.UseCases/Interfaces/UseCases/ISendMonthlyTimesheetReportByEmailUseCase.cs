namespace Hackaponto.Reports.UseCases.Interfaces.UseCases
{
    public interface ISendMonthlyTimesheetReportByEmailUseCase
    {
        Task Execute(int year, int month);
    }
}
