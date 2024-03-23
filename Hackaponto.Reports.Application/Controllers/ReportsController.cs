using Hackaponto.Reports.UseCases.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaponto.Reports.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReportsController(ISendMonthlyTimesheetReportByEmailUseCase sendMonthlyTimesheetReportByEmailUseCase) : ControllerBase
    {
        private readonly ISendMonthlyTimesheetReportByEmailUseCase _sendMonthlyTimesheetReportByEmailUseCase = sendMonthlyTimesheetReportByEmailUseCase;

        [HttpGet("monthly-report/{year}/{month}")]
        public async Task SendMonthlyReport(int year, int month)
        {
            await _sendMonthlyTimesheetReportByEmailUseCase.Execute(year, month);
        }

        [HttpGet("monthly-report/last-month")]
        public async Task SendMonthlyReport()
        {
            var now = DateTime.UtcNow;
            await _sendMonthlyTimesheetReportByEmailUseCase.Execute(now.Year, now.Month);
        }
    }
}