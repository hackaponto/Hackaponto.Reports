using Hackaponto.Reports.Domain.Enums;

namespace Hackaponto.Reports.Domain.Models
{
    public class ClockingEvent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateTime { get; set; }
        public ClockingEventType Type { get; set; }
    }
}
