using Hackaponto.Reports.Application.Services;
using Hackaponto.Reports.Infrastructure.Repositories;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class RepositoriesConfig
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserWorkdayRepository, UserWorkdayRepository>();
        }
    }
}
