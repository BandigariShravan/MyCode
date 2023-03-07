using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company_Three_Tier_Architecture_API.Models
{
    public class Company
    {
        [Key]
        public int Company_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
       
        [ForeignKey("Employeee_Id")]
        public int Employeee_Id { get; set; }
        //public virtual ICollection<Company>? Employees { get; set; }
    }
}