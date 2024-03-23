using Hackaponto.Reports.UseCases.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaponto.Reports.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReportsController(ILogger<ReportsController> logger, ISendMonthlyTimesheetReportByEmailUseCase sendMonthlyTimesheetReportByEmailUseCase, IConfiguration config) : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger = logger;
        private readonly ISendMonthlyTimesheetReportByEmailUseCase _sendMonthlyTimesheetReportByEmailUseCase = sendMonthlyTimesheetReportByEmailUseCase;

        [HttpGet("monthly-report/{year}/{month}")]
        public async Task SendMonthlyReport(int year, int month)
        {
            await _sendMonthlyTimesheetReportByEmailUseCase.Execute(year, month);
        }
    }
}