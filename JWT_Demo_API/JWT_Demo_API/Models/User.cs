using Microsoft.AspNetCore.Identity;

namespace JWT_Demo_API.Models
{
    public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}