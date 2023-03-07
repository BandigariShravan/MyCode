using System.ComponentModel.DataAnnotations;

namespace JWT_Authentication_NewAPI.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Email { get; set; }
        public string Student_Phone { get; set; }
    }
}
