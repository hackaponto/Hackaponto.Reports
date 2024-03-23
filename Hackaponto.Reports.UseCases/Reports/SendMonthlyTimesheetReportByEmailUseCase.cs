using Hackaponto.Reports.Entities.Entities;
using Hackaponto.Reports.UseCases.EmailFactories;
using Hackaponto.Reports.UseCases.Exceptions;
using Hackaponto.Reports.UseCases.Interfaces.Gateways;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;
using Hackaponto.Reports.UseCases.Interfaces.UseCases;

namespace Hackaponto.Reports.UseCases.Reports
{
    public class SendMonthlyTimesheetReportByEmailUseCase(IUserWorkdayRepository userWorkdayRepository,
        IUserInfoService userInfoRepository,
        IEmailService emailService)
        : ISendMonthlyTimesheetReportByEmailUseCase
    {
        private readonly IUserWorkdayRepository _userWorkdayRepository = userWorkdayRepository;
        private readonly IUserInfoService _userInfoService = userInfoRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task Execute(int year, int month)
        {
            var user = _userInfoService.GetUser();

            if (user.Email is null || user.Email == string.Empty)
                throw new BadRequestException("Não pudemos encontrar o seu email. Por favor, verifique seu cadastro e tente novamente.");

            var userWorkdays = _userWorkdayRepository.GetAll(user.Id, year, month);

            if (userWorkdays == null || !userWorkdays.Any())
                throw new BadRequestException("Não será possível gerar o espelho de ponto pois não há nenhum dia de trabalho para o mês.");

            var monthTimesheetReport = new MonthlyTimesheetReport(year, month, userWorkdays);

            var reportBody = MonthlyTimesheetReportEmailBodyFactory.Create(monthTimesheetReport);

            await _emailService.SendEmail(user.Email, $"Espelho de ponto - {month:00}/{year}", reportBody);
        }
    }
}
