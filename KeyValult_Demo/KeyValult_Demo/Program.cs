// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

string Client_Id = "8f6bd982-92c3-4de0-985d-0e287c55e379";
string Base_URI = "https://shravankey.vault.azure.net/";
string client_secret = "a75cacc08a9a42f0a6bd4548436602a6";

var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(
    async (string auth, string res, string scope) =>
    {
        var authContext = new AuthenticationContext(auth);
        var credential = new ClientCredential(Client_Id, client_secret);
        AuthenticationResult result = await authContext.AcquireTokenAsync(res, credential);
        if (result==null)
        {
            throw new InvalidOperationException("Failed to retriieve token");
        }
        return result.AccessToken;
    }
    ));
var secretData = await client.GetSecretAsync(Base_URI, "ConnectionString");
Console.WriteLine("Secret:"+ secretData.Value);
Console.ReadKey();
