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
        modelBuilder.Entity<Order>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Orders)
            .UsingEntity<OrderProduct>();

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category {Id = 1, Name = "Catz"},
            new Category {Id = 2, Name = "Sport"},
            new Category {Id = 3, Name = "Hiking"},
            new Category {Id = 4, Name = "Dogz"}
        });
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order {Id = 1, CustomerId = "1", IsOpen = true, PaymentTypeId = 3, TimeSubmitted = DateTime.Now},
            new Order {Id = 3, CustomerId = "2", IsOpen = true, PaymentTypeId = 2, TimeSubmitted = DateTime.Now},
            new Order {Id = 4, CustomerId = "2", IsOpen = false, PaymentTypeId = 2, TimeSubmitted = DateTime.Now},
            new Order {Id = 5, CustomerId = "4", IsOpen = false, PaymentTypeId = 2, TimeSubmitted = DateTime.Now},
            new Order {Id = 6, CustomerId = "4", IsOpen = false, PaymentTypeId = 2, TimeSubmitted = DateTime.Now}
        });
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
            new PaymentType {Id = 1, Type = "Visa"},
            new PaymentType {Id = 2, Type = "Mastercard"},
            new PaymentType {Id = 3, Type = "Barter System"}
        });
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product {Id = 1, SellerId = "123", Name = "Dog", Description = "A new dog", Price = 12, Quantity = 1, CategoryId = 1, TimeCreated = DateTime.Now},
            new Product {Id = 2, SellerId = "123", Name = "Cat", Description = "A new cat", Price = 13, Quantity = 1, CategoryId = 4, TimeCreated = DateTime.Now},
            new Product {Id = 3, SellerId = "2", Name = "Tent", Description = "A new tent", Price = 200, Quantity = 5, CategoryId = 3, TimeCreated = DateTime.Now},
            new Product {Id = 4, SellerId = "2", Name = "Hiking Boots", Description = "New boots", Price = 150, Quantity = 2, CategoryId = 3, TimeCreated = DateTime.Now},
            new Product {Id = 5, SellerId = "3", Name = "Lantern", Description = "A new lantern", Price = 40, Quantity = 20, CategoryId = 3, TimeCreated = DateTime.Now},
            new Product {Id = 6, SellerId = "3", Name = "Baseball", Description = "A new baseball", Price = 15, Quantity = 1, CategoryId = 2, TimeCreated = DateTime.Now},
            new Product {Id = 7, SellerId = "3", Name = "Football", Description = "A new football", Price = 10, Quantity = 20, CategoryId = 2, TimeCreated = DateTime.Now}
        });
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User {Id = "123", Name = "Amogus", Email = "amogus@email.com", IsSeller = true},
            new User {Id = "2", Name = "Hammy", Email = "hammy@email.com", IsSeller = true},
            new User {Id = "3", Name = "Sandra", Email = "sandra@email.com", IsSeller = true},
            new User {Id = "4", Name = "Crystal", Email = "crystal@email.com", IsSeller = false}
        });
    }
}


