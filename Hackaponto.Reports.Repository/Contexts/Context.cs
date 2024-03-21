using Hackaponto.Reports.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackaponto.Reports.Infrastructure.Contexts
{
    public class Context : DbContext
    {
        public DbSet<ClockingEvent> ClockingEvents { get; set; }
        public DbSet<UserWorkday> UserWorkdays { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
