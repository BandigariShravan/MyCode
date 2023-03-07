using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryAPIDBContext:DbContext
    {
        public LibraryAPIDBContext(DbContextOptions<LibraryAPIDBContext> options):base(options) { }
        public DbSet<Library> Libraries1 { get; set; }
    }
}
