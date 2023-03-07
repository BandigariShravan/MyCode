using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get;set; }
    }
}