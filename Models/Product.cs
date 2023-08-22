namespace BangazonAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
    }
}
