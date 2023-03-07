using JWT_Demo_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace JWT_Demo_API.Data
{
    public class DBClassContext : IdentityDbContext<User>
    {
        public DBClassContext(DbContextOptions options):base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        //    modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        //}

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
