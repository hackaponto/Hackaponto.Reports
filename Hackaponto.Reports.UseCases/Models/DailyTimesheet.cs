using Hackaponto.Reports.Domain.Enums;
using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.Entities.Entities
{
    public class DailyTimesheet
    {
        public int Day { get; set; }
        public TimeSpan TotalWorkhours { get; set; }
        public List<ClockingEvent> ClockingEvents { get; set; } = [];

        public DailyTimesheet(UserWorkday userWorkday)
        {
            Day = userWorkday.Date.Day;
            TotalWorkhours = userWorkday.TotalWorkHours;
            ClockingEvents.AddRange(userWorkday.ClockingEvents);
        }

        public static implicit operator DailyTimesheet(UserWorkday userWorkday)
            => new(userWorkday);
    }
}
