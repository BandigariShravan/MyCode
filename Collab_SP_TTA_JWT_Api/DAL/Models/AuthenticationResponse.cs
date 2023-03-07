using System.ComponentModel.DataAnnotations;

namespace JWT_Authentication_NewAPI.Models
{
    public class AuthenticationResponse
    {
        [Key]
        public string? Token { get; set; }
    }
}
