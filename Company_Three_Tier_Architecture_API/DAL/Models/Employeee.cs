using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Three_Tier_Architecture_API.Models
{
    public class Employeee
    {
        [Key]
        public int Employeee_Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
       
    }
}
