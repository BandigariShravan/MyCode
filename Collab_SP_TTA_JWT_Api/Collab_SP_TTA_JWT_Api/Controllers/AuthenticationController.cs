using JWT_Authentication_NewAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Collab_SP_TTA_JWT_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginCredentials login)
        {
            if (User is null)
            {
                return BadRequest("invalid Client request");
            }
            if (login.UserName == "Shravan" && login.password == "BSKMC850")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7281",
                    audience: "https://localhost:7281",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: signinCredentials
                    );
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthenticationResponse { Token = token });
            }
            return Unauthorized();
        }
    }
}