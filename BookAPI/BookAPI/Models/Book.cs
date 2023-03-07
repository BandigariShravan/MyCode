using BookUserAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        public string? Book_Name { get; set; }
        public string? Author { get; set; }
        public DateTime Published_Time { get; set; }
        public int ISBN { get; set; }
       public virtual ICollection<BookUser>? bookUsers { get; set; }
    }
}