using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
