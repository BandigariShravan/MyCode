using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? CompanyAddress { get; set; }
    }
}