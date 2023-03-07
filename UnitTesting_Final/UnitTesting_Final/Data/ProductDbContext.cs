using Microsoft.EntityFrameworkCore;
using UnitTesting_Final.Models;

namespace UnitTesting_Final.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
