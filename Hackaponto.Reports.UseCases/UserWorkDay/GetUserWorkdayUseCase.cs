using Hackaponto.Reports.Domain.Models;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;
using Hackaponto.Reports.UseCases.Interfaces.UseCases;

namespace Hackaponto.Reports.UseCases.UserWorkDay
{
    public class GetUserWorkdayUseCase(IUserWorkdayRepository userWorkdayRepository,
        IUserInfoService userInfoRepository) : IGetUserWorkdayUseCase
    {
        private readonly IUserWorkdayRepository _userWorkdayRepository = userWorkdayRepository;
        private readonly IUserInfoService _userInfoService = userInfoRepository;

        public UserWorkday Execute(DateOnly date)
        {
            var user = _userInfoService.GetUser();
            
            return _userWorkdayRepository.Get(user.Id, date);
        }
    }
}
