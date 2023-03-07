using System.ComponentModel.DataAnnotations;

namespace JWT_Authentication_NewAPI.Models
{
    public class LoginCredentials
    {
        [Key]
        public string UserName { get; set; }
        public string password { get; set; }

    }
}
