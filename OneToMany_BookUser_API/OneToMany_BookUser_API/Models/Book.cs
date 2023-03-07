using System.ComponentModel.DataAnnotations;

namespace OneToMany_BookUser_API.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        public string? Book_Name { get; set; }
        public string? Author { get; set; }
        public DateTime Published_Time { get; set; }
        public int ISBN { get; set; }
    }
}
