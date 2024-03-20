using Hackaponto.Reports.Domain.Enums;

namespace Hackaponto.Reports.Domain.Models
{
    public class ClockingEvent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public ClockingEventType Type { get; set; }
    }
}
