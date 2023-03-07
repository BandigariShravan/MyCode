using Company_Three_Tier_Architecture_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Company_Three_Tier_Architecture_API.Data
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employeee> Employees { get; set; }
    }
}
