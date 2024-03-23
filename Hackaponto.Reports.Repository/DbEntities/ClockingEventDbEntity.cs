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
    }
}
