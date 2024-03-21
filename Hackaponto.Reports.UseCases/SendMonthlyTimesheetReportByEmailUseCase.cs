using Hackaponto.Reports.Entities.Entities;
using Hackaponto.Reports.UseCases.Interfaces.Gateways;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;

namespace Hackaponto.Reports.UseCases
{
    public class SendMonthlyTimesheetReportByEmailUseCase(IAccountRepository accountRepository,
        IUserWorkdayRepository userWorkdayRepository,
        IUserInfoRepository userInfoRepository,
        IEmailService emailService)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IUserWorkdayRepository _userWorkdayRepository = userWorkdayRepository;
        private readonly IUserInfoRepository _userInfoRepository = userInfoRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task Execute(int year, int month)
        {
            var userId = _userInfoRepository.GetUserId();
            var userWorkdays = _userWorkdayRepository.Get(userId.Result, year, month);
            var monthTimesheetReport = new MonthlyTimesheetReport(year, month, userWorkdays);
            _emailService.SendEmail("");
        }
    }
}
