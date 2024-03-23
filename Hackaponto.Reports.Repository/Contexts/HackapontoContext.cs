using Hackaponto.Reports.Infrastructure.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Hackaponto.Reports.Infrastructure.Contexts
{
    public class HackapontoContext(DbContextOptions<HackapontoContext> options) : DbContext(options)
    {
        public DbSet<ClockingEventDbEntity> ClockingEvents { get; set; }
        public DbSet<UserWorkdayDbEntity> UserWorkdays { get; set; }
    }
}
