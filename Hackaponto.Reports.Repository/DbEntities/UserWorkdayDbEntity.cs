using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.Infrastructure.DbEntities
{
    public class UserWorkdayDbEntity
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TotalWorkHours { get; set; }

        public static implicit operator UserWorkday(UserWorkdayDbEntity userWorkdayDbEntity) => new UserWorkday()
        {
            UserId = userWorkdayDbEntity.UserId,
            Date = DateOnly.FromDateTime(userWorkdayDbEntity.Date),
            TotalWorkHours = userWorkdayDbEntity.TotalWorkHours,
        };
    }
}
