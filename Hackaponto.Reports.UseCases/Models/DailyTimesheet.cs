using Hackaponto.Reports.Domain.Enums;
using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.Entities.Entities
{
    public class DailyTimesheet
    {
        public DateOnly Date { get; set; }
        public TimeSpan TotalWorkHours { get; set; }
        public List<ClockingEvent> ClockingEvents { get; set; } = [];

        public DailyTimesheet(UserWorkday userWorkday)
        {
            Date = userWorkday.Date;
            TotalWorkHours = userWorkday.TotalWorkHours;
            ClockingEvents.AddRange(userWorkday.ClockingEvents);
        }

        public static implicit operator DailyTimesheet(UserWorkday userWorkday)
            => new(userWorkday);
    }
}
