using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public bool IsOpen { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
