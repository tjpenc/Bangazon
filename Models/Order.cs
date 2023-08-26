using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]

        [ForeignKey("User")]
        public string CustomerId { get; set; }
        public User User { get; set; }
        public bool IsOpen { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<Product> Products { get; set; }
    }
}
