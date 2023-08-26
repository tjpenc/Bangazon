using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]

        [ForeignKey("User")]
        public string SellerId { get; set; }
        public User User { get; set; }
        
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<Order> Orders { get; set; }
    }
}
