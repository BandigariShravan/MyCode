using LibraryAPIUsingLinq.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPIUsingLinq.Data
{
    public class LibraryAPIDBContext : DbContext
    {
        public LibraryAPIDBContext(DbContextOptions<LibraryAPIDBContext> options) : base(options) { }
        public DbSet<Library> LibrariesUsingLinq { get; set; }
    }
}
