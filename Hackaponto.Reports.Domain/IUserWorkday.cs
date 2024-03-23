using Hackaponto.Reports.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaponto.Reports.Entities
{
    public interface IUserWorkday
    {
        public Guid UserId { get; set; }
        public DateOnly Date { get; set; }
        public List<ClockingEvent> ClockingEvents { get; set; }
        public TimeSpan TotalWorkHours { get; set; }
    }
}
