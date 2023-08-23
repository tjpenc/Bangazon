using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

public class BangazonDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category {Id = 1, Name = "Animal"}
        });
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order {Id = 1, CustomerId = "123", IsOpen = true, PaymentTypeId = 1, TimeSubmitted = DateTime.Now}
        });
        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
        {
            new OrderProduct {Id = 1, OrderId = 1, ProductId = 1, Quantity = 1}
        });
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
            new PaymentType {Id = 1, Type = "Card"}
        });
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product {Id = 1, SellerId = "123", Name = "Dog", Description = "A new dog", Price = 12, Quantity = 1, CategoryId = 1}
        });
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User {Id = "123", Name = "John", Email = "j@email.com", IsSeller = true}
        });
    }
}


