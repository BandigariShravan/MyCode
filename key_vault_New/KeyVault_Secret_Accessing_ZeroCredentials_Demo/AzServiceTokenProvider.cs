using Azure.Core;
using Azure.Identity;

namespace KeyVault_Secret_Accessing_ZeroCredentials_Demo
{
    public class AzServiceTokenProvider
    {
        private static AccessToken _accessToken;
        public static string GetAccessToken(IConfiguration _configuration)
        {
            var tokenconfidential = new DefaultAzureCredential();
            _accessToken = tokenconfidential.GetToken(
                new TokenRequestContext(scopes: new string[] { "http://database.windows.net" }, null, null, _configuration["ConnectionString"]));
            return _accessToken.Token;
        }
    }
}
