using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string SellerId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
