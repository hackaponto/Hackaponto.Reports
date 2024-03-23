using Hackaponto.Reports.Application.Services;
using Hackaponto.Reports.Infrastructure.Services;
using Hackaponto.Reports.UseCases.Interfaces.Gateways;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
