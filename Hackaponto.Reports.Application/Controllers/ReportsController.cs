using Hackaponto.Reports.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Hackaponto.Reports.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController(ILogger<ReportsController> logger, SendMonthlyTimesheetReportByEmailUseCase sendMonthlyTimesheetReportByEmailUseCase) : ControllerBase
    {
        private readonly ILogger<ReportsController> logger = logger;
        private readonly SendMonthlyTimesheetReportByEmailUseCase sendMonthlyTimesheetReportByEmailUseCase = sendMonthlyTimesheetReportByEmailUseCase;

        [HttpGet("monthly-report/{year}/{month}")]
        public async Task SendMonthlyReport(int year, int month)
        {
            sendMonthlyTimesheetReportByEmailUseCase.Execute(year, month);
        }
    }
}