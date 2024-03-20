using Hackaponto.Reports.Domain.Models;
using Hackaponto.Reports.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class DbContextsConfig
    {
        public static void AddPostgresDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<DbContext<ClockingEvent>>(ConfigureDbContext);
            services.AddDbContext<DbContext<UserWorkday>>(ConfigureDbContext);
        }

        private static void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase");
        }
    }
}
