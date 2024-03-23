using Hackaponto.Reports.UseCases.Interfaces.UseCases;
using Hackaponto.Reports.UseCases.Reports;
using Hackaponto.Reports.UseCases.UserWorkDay;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class UseCasesConfig
    {
        public static void ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<ISendMonthlyTimesheetReportByEmailUseCase, SendMonthlyTimesheetReportByEmailUseCase>();
            services.AddScoped<IGetUserWorkdayUseCase, GetUserWorkdayUseCase>();

        }
    }
}
