using System.ComponentModel.DataAnnotations;

namespace UnitTesting_Final.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public string? Product_Description { get; set; }
        public string? Product_Price { get; set; }
        public int Product_Stock { get; set; }
    }
}
