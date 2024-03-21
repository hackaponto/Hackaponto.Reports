using Hackaponto.Reports.Domain.Enums;

namespace Hackaponto.Reports.UseCases.Models
{
    public class ClockingEvent
    {
        public TimeOnly Time { get; set; }
        public ClockingEventType Type { get; set; }
    }
}