using Hackaponto.Reports.Entities.Entities;
using Hackaponto.Reports.UseCases.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace Hackaponto.Reports.Application.Services
{
    public class UserInfoService(IHttpContextAccessor httpContextAccessor) : IUserInfoService
    {

        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public User GetUser()
        {
            var idToken = _httpContextAccessor.HttpContext.Request.Headers["id_token"].ToString();
            new JwtSecurityTokenHandler().ReadJwtToken(idToken);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(idToken) as JwtSecurityToken;

            return new User
            {
                Id = Guid.Parse(jsonToken.Subject),
                Email = jsonToken.Payload["email"].ToString(),
            };
        }
    }
}
