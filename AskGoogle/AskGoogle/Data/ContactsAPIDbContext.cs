using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Contact>Contacts{ get; set; }
    }
}