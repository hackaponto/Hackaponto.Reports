using Hackaponto.Reports.Domain.Models;
using Hackaponto.Reports.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class DbContextsConfig
    {
        public static void ConfigureDbContexts(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<HackapontoContext>(options =>
                    ConfigureDbContext(options, configuration));
        }

        private static void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, ConfigurationManager configuration)
        {
            var postgresConnection = configuration.GetSection("DbConnection");
            optionsBuilder
                .UseNpgsql("" +
                $"Host={postgresConnection.GetValue<string>("Host")};" +
                $"Database={postgresConnection.GetValue<string>("Database")};" +
                $"Username={postgresConnection.GetValue<string>("Username")};" +
                $"Password={postgresConnection.GetValue<string>("Password")};");
        }
    }
}
