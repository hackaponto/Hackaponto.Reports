using Hackaponto.Reports.Domain.Models;

namespace Hackaponto.Reports.Entities.Entities
{
    public class MonthlyTimesheetReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public TimeSpan TotalWorkHours { get; set; } = TimeSpan.Zero;
        public List<DailyTimesheet> Days { get; set; } = [];

        public MonthlyTimesheetReport(int year, int month, IEnumerable<UserWorkday> userWorkdays)
        { 
            Year = year;
            Month = month;

            foreach(UserWorkday day in userWorkdays)
            {
                Days.Add(day);
                TotalWorkHours.Add(day.TotalWorkHours);
            }
        }
    }
}