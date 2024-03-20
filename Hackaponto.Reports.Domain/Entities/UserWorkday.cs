namespace Hackaponto.Reports.Domain.Models
{
    public class UserWorkday
    {
        public Guid UserId { get; set; }
        public DateOnly Date { get; set; }
        public List<ClockingEvent> Registries { get; set; } = [];
        public TimeOnly TotalWorkHour { get; set; }
    }
}
