using Hackaponto.Reports.Domain.Enums;

namespace Hackaponto.Reports.Domain.Models
{
    public class ClockingEvent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public ClockingEventType Type { get; set; }

        public ClockingEvent(Guid id, DateTime date, DateTime time, string type, Guid userId)
        {
            Id = id;
            UserId = userId;
            Date = DateOnly.FromDateTime(date);
            Time = TimeOnly.FromDateTime(time);
            Type = type == "IN" ? ClockingEventType.IN : ClockingEventType.OUT;
        }

        public ClockingEvent(Guid id, Guid userId, DateTime date, DateTime time, string type)
        {
            Id = id;
            UserId = userId;
            Date = DateOnly.FromDateTime(date);
            Time = TimeOnly.FromDateTime(time);
            Type = type == "IN" ? ClockingEventType.IN : ClockingEventType.OUT;
        }
    }
}
