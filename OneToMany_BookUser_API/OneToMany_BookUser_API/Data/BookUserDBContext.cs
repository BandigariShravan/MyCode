using Microsoft.EntityFrameworkCore;
using OneToMany_BookUser_API.Models;

namespace OneToMany_BookUser_API.Data
{
    public class BookUserDBContext:DbContext
    {
        public BookUserDBContext(DbContextOptions<BookUserDBContext> dbContextOptions):base(dbContextOptions) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
