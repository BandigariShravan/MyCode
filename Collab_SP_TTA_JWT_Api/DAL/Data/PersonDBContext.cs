using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class PersonDBContext:DbContext
    {
        public PersonDBContext(DbContextOptions options) :base (options){ }
        public DbSet<Person> Persons { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
    }
}
