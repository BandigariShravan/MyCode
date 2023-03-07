// See https://aka.ms/new-console-template for more information
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // JWT Creation
        var SecretKey = "This is Shravan 4567Authentication";
        var Header = new JwtHeader(new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
            SecurityAlgorithms.HmacSha256));

        Console.WriteLine("Enter UserName:");
        var Name=Console.ReadLine();
        Console.WriteLine("Enter Email");
        var Email=Console.ReadLine();
        var issuer = "Google";
        var audience = "HackerRank";
        var claims = new List<Claim>();
        claims.Add(new Claim("Name", Name));// $"(Name)"));
        claims.Add(new Claim("Email", Email));// $"(Email)"));

        var startTime=DateTime.Now;
        var endTime = DateTime.Now.AddMinutes(10);

        var payLoad=new JwtPayload(issuer,audience,claims, startTime, endTime);
        var jwt=new JwtSecurityToken(Header, payLoad);

        var encodeJWT=new JwtSecurityTokenHandler().WriteToken(jwt);
        Console.WriteLine(encodeJWT);
    }
}