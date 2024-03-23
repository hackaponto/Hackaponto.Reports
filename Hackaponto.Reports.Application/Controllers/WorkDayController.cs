using Hackaponto.Reports.Domain.Models;
using Hackaponto.Reports.UseCases.Interfaces.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaponto.Reports.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("work-day")]
    public class WorkDayController(IGetUserWorkdayUseCase getUserWorkdayUseCase) : ControllerBase
    {
        private readonly IGetUserWorkdayUseCase _getUserWorkdayUseCase = getUserWorkdayUseCase;

        [HttpGet("{year}/{month}/{day}")]
        public ActionResult<UserWorkday> GetWorkingDay(int year, int month, int day)
        {
            var result = _getUserWorkdayUseCase.Execute(new DateOnly(year, month, day));
            return new ActionResult<UserWorkday>(result);
        }
    }
}
