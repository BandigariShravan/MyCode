using System.ComponentModel.DataAnnotations;

namespace JWT_Authentication_NewAPI.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }
        public string? Course_Name { get;set; }
    }
}
