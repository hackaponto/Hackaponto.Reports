using Hackaponto.Reports.Application.Gateway;
using Hackaponto.Reports.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Hackaponto.Reports.Application.Configuration
{
    public static class AuthenticationConfig
    {
        public static async Task ConfigureAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            var validIssuer = configuration.GetSection("JwtSettings").GetValue<string>("Issuer");
            var validAudience = configuration.GetSection("JwtSettings").GetValue<string>("Audience");

            var httpClient = new HttpClient();
            var webKeySetJson = await httpClient.GetStringAsync($"{validIssuer}/.well-known/jwks.json");

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                        {
                            var jsonWebKeySet = new JsonWebKeySet(webKeySetJson);
                            return jsonWebKeySet?.GetSigningKeys();
                        },
                        ValidIssuer = validIssuer,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidAudience = validAudience,
                        ValidateLifetime = true,
                        RoleClaimType = "cognito:groups",
                        AudienceValidator = (audiences, securityToken, validationParameters) =>
                        {
                            var castedToken = (JsonWebToken)securityToken;
                            var clientId = new JwtSecurityTokenHandler().ReadJwtToken(castedToken.EncodedToken).Payload["client_id"].ToString();
                            return validAudience.Equals(clientId);
                        },
                        ValidateAudience = true
                    };
                });
            services.AddAuthorization();
        }
    }
}
