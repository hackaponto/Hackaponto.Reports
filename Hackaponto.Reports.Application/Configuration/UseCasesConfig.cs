using Hackaponto.Reports.UseCases;
using Hackaponto.Reports.UseCases.Interfaces.UseCases;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class UseCasesConfig
    {
        public static void ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<ISendMonthlyTimesheetReportByEmailUseCase, SendMonthlyTimesheetReportByEmailUseCase>();
        }
    }
}
