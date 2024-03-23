using Hackaponto.Reports.Domain.Enums;
using Hackaponto.Reports.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaponto.Reports.Infrastructure.DbEntities
{
    [Table("clocking_events")]
    public class ClockingEventDbEntity
    {
        [Key, Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("date")]
        public DateOnly Date { get; set; }

        [Column("time")]
        public TimeOnly Time { get; set; }

        [Column("type")]
        public ClockingEventType Type { get; set; }

        //public static implicit operator ClockingEvent(ClockingEventDbEntity clockingEventDbEntity) => new()
        //{
        //    Id = clockingEventDbEntity.Id,
        //    UserId = clockingEventDbEntity.UserId,
        //    DateTime = new DateTime(clockingEventDbEntity.Date, clockingEventDbEntity.Time),
        //    Type = clockingEventDbEntity.Type
        //};
    }

    //public static class ClockingEventDbEntityExtensions
    //{
    //    public static List<ClockingEvent> ToDomainList(this IEnumerable<ClockingEventDbEntity> clockingEventDbEntities)
    //    {
    //        var clockingEvents = new List<ClockingEvent>();

    //        foreach (var clockingEventDbEntity in clockingEventDbEntities)
    //        {
    //            clockingEvents.Add(clockingEventDbEntity);
    //        }

    //        return clockingEvents;
    //    }
    //}
}
