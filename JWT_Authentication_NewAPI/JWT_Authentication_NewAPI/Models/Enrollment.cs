using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_Authentication_NewAPI.Models
{
    public class Enrollment
    {
        [Key]
        public int Enrollment_Id { get; set; }
        
        public int Student_Id { get; set; }
        [ForeignKey("Student_Id")]
        public Student Student { get; set; }

       
        public int Course_Id { get; set; }
        [ForeignKey("Course_Id")]
        public Course Course { get;set; }
    }
}