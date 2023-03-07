using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeeId { get; set; }
        [Required(ErrorMessage = "Please provide  a Employee Name")]
        public string? EmployeeName { get; set; }
        [Required(ErrorMessage = "Please provide some Salary")]
        public double Salary { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }
    }
}