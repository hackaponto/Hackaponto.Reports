namespace Hackaponto.Reports.Domain.Models
{
    public class UserWorkday
    {
        public Guid UserId { get; set; }
        public DateOnly Date { get; set; }
        public List<ClockingEvent> ClockingEvents { get; set; } = [];
        public TimeSpan TotalWorkHours { get; set; }
    }
}
