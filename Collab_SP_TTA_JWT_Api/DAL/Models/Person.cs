using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class Person
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        
        public int DriverLicenseId { get; set; }
        [ForeignKey("DriverLicenseId")]
        public DriverLicense? DriverLicenses { get; set; }
    }
}
