using Hackaponto.Reports.Application.Settings;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class SettingsValuesConfig
    {
        public static void ConfigureSettingsValues(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.Configure<DbConnection>(configuration.GetSection("DbConnection"));
        }
    }
}
