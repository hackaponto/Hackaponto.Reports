using Microsoft.IdentityModel.Tokens;

namespace Hackaponto.Reports.Application.Gateway
{
    public class JwkGateway(string jwksUri)
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _jwksUri = jwksUri;

        public async Task<IEnumerable<SecurityKey>> GetSigningKeysAsync()
        {
            var response = await _httpClient.GetAsync(_jwksUri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var jwks = JsonWebKeySet.Create(json);
                return jwks.Keys;
            }
            else
            {
                throw new Exception($"Failed to retrieve Cognito JWKS: {response.StatusCode}");
            }
        }
    }
}
