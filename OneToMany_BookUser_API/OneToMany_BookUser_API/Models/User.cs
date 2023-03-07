using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToMany_BookUser_API.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string? Full_Name { get; set; }
        public bool Enabled { get; set; }
        public DateTime Last_Login { get; set; }
        public int Book_Id { get; set; }
        [ForeignKey("Book_Id")]
        public Book? Book { get; set; }
    }
}
