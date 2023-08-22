namespace BangazonAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public bool IsOpen { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
