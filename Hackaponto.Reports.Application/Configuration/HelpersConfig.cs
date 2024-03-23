using Hackaponto.Reports.Application.Helpers;
using Pottencial.Financial.Border.Repositories.Helpers;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class HelpersConfig
    {
        public static void ConfigureHelpers(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryHelper, RepositoryHelper>();
        }
    }
}
