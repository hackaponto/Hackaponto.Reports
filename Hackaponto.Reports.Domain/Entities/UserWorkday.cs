namespace Hackaponto.Reports.Domain.Models
{
    public class UserWorkday
    {
        public Guid? UserId { get; set; }
        public DateOnly Date { get; set; }
        public IEnumerable<ClockingEvent> ClockingEvents { get; set; } = [];
        public TimeSpan TotalWorkHours { get; set; }

        public UserWorkday(Guid? userId, DateTime dateTime, IEnumerable<ClockingEvent> clockingEvents, TimeSpan totalWorkHours)
        {
            UserId = userId;
            Date = DateOnly.FromDateTime(dateTime);
            ClockingEvents = clockingEvents;
            TotalWorkHours = totalWorkHours;
        }

        public UserWorkday()
        {
        }
    }
}
