using Hackaponto.Reports.Domain.Enums;
using Hackaponto.Reports.Domain.Models;
using Hackaponto.Reports.Entities.Entities;
using Hackaponto.Reports.UseCases.Resources;
using System.Text.RegularExpressions;

namespace Hackaponto.Reports.UseCases.EmailFactories
{
    public static class MonthlyTimesheetReportEmailBodyFactory
    {
        private const string Path = "HtmlTemplates\\";

        public static string Create(MonthlyTimesheetReport report)
        {
            var monthlyTimesheetReportEmailBody = HtmlResources.MonthlyTimesheetReport;

            monthlyTimesheetReportEmailBody = Regex.Replace(monthlyTimesheetReportEmailBody, "{{userWorkdaysTable}}", CreateDailyTimesheetRowsHtml(report.Days));

            return monthlyTimesheetReportEmailBody;
        }

        private static string CreateClockingEventsHtml(List<ClockingEvent> clockingEvents)
        {
            var clockingEventsHtml = string.Empty;
            foreach (var clockingEvent in clockingEvents)
            {
                clockingEventsHtml += $"{clockingEvent.Type.ToPortuguese()}: {clockingEvent.Time:HH:mm}<br>\n";
            }
            return clockingEventsHtml;
        }

        private static string CreateDailyTimesheetRowsHtml(List<DailyTimesheet> days)
        {
            var dailyTimesheetRows = string.Empty;

            var tableRowTemplate = HtmlResources.WorkdayTableRow;
            foreach (var day in days)
            {
                var tableRow = tableRowTemplate;
                tableRow = Regex.Replace(tableRow, "{{date}}", day.Date.ToString("dd/MM/yyyy"));
                tableRow = Regex.Replace(tableRow, "{{totalHours}}", day.TotalWorkHours.ToString(@"hh\:mm"));
                tableRow = Regex.Replace(tableRow, "{{clockingEvents}}", CreateClockingEventsHtml(day.ClockingEvents));

                dailyTimesheetRows += "\n" + tableRow;
            }

            return dailyTimesheetRows;
        }
    }
}
