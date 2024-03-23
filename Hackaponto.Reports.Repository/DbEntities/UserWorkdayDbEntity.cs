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

    //public static class UserWorkdayDbEntityExtensions
    //{
    //    public static List<UserWorkday> ToDomainList(this IEnumerable<UserWorkdayDbEntity> userWorkdayDbEntities)
    //    {
    //        var userWorkdays = new List<UserWorkday>();

    //        foreach (var userWorkdayDbEntity in userWorkdayDbEntities)
    //        {
    //            userWorkdays.Add(userWorkdayDbEntity);
    //        }

    //        return userWorkdays;
    //    }
    //}
}
