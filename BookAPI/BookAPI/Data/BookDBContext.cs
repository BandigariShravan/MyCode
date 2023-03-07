using BookAPI.Models;
using BookUserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Migrations
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookUser> bookUsers { get; set; }
    }
}