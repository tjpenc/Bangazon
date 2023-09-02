using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7268")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Check for user
app.MapGet("/api/users/check/{uid}", (BangazonDbContext db, string uid) =>
{
    User user = db.Users.FirstOrDefault(u => u.UID == uid);
    if (user == null)
    {
        return Results.NotFound(null);
    }
    return Results.Ok(user);
});

app.MapPost("/api/users", (BangazonDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Ok(user);
});

app.MapGet("/api/sellers", (BangazonDbContext db) =>
{
    List<User> users = db.Users.Where(u => u.IsSeller == true).ToList();
    if (users.Count == 0)
    {
        return Results.NotFound(null);
    }
    return Results.Ok(users);
});

// Products API Calls
app.MapGet("/api/products", (BangazonDbContext db) =>
{
    if (db.Products == null)
    {
        Results.NotFound("There are no products");
    }

    return Results.Ok(db.Products
        .Include(p => p.User)
        .Include(p => p.Category));
});

app.MapGet("/api/products/recent", (BangazonDbContext db) =>
{
    List<Product> products = db.Products.OrderByDescending(p => p.TimeCreated).Take(20).ToList();
    if (products.Count > 0)
    {
        return Results.Ok(products);
    }
    else
    {
        return Results.NotFound("No products are for sale");
    }
});

app.MapGet("api/products/{id}", (BangazonDbContext db, int id) =>
{
    Product product = db.Products.FirstOrDefault(p => p.Id == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});

app.MapGet("/api/products/seller/{sellerId}", (BangazonDbContext db, string sellerId) =>
{
    List<Product> products = db.Products.Where(p => p.SellerId == sellerId)
    .Include(p => p.Category)
    .ToList();
    if (products.Count > 0)
    {
        return Results.Ok(products);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/products/{id}", (BangazonDbContext db, int id) =>
{
    Product product = db.Products.FirstOrDefault(p => p.Id == id);
    if (product == null)
    {
        return Results.NotFound("Please select a valid product");
    }
    db.Products.Remove(product);
    db.SaveChanges();
    return Results.Ok();
});

app.MapPost("/api/products", (BangazonDbContext db, Product product) =>
{
    try
    {
        product.TimeCreated = DateTime.Now;
        db.Products.Add(product);
        db.SaveChanges();
        return Results.Created($"/api/products/{product.Id}", product);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Please enter valid data");
    }
});

app.MapPut("/api/products/{id}", (BangazonDbContext db, int id, Product product) =>
{
    Product productToUpdate = db.Products.FirstOrDefault(p => p.Id == id);
    if (productToUpdate == null)
    {
        return Results.NotFound("Product Not Found");
    }
    productToUpdate.Name = product.Name;
    productToUpdate.Price = product.Price;
    productToUpdate.Description = product.Description;
    productToUpdate.Quantity = product.Quantity;
    productToUpdate.CategoryId = product.CategoryId;
    db.SaveChanges();
    return Results.Ok(productToUpdate);
});

app.MapGet("/api/products/categories/{id}", (BangazonDbContext db, int id) =>
{
    List<Product> products = db.Products.Where(p => p.CategoryId == id).ToList();
    if (products.Count > 0)
    {
        return Results.Ok(products);
    }
    else
    {
        return Results.NotFound("No products are found in this category");
    }
});

// Customer Orders API Calls

app.MapGet("/api/customer/{id}/closedorders", (BangazonDbContext db, string id) =>
{
    List<Order> orders = db.Orders.Where(o => o.CustomerId == id && o.IsOpen == false).ToList();
    if (orders.Count > 0)
    {
        return Results.Ok(orders);
    }
    else
    {
        return Results.NotFound("There are no closed orders for this user");
    }
});

app.MapGet("/api/customer/{id}/openorders", (BangazonDbContext db, string id) =>
{
    List<Order> cart = db.Orders.Where(o => o.IsOpen == true && o.CustomerId == id)
        .Include(o => o.Products)
        .ToList();

    if (cart.Count > 0)
    {
        return Results.Ok(cart);
    }
    else
    {
        return Results.NotFound("There is no open order");
    }
});

app.MapGet("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    List<Order> order = db.Orders.Where(o => o.Id == id).ToList();
    if (order == null)
    {
        return Results.NotFound("There is no open order");

    }
    return Results.Ok(db.Orders
        .Include(o => o.Products));
});

app.MapGet("/api/order/history/seller/{id}", (BangazonDbContext db, string id) =>
{
    List<Product> products = db.Products
        .Include(p => p.Orders)
        .Where(p => p.SellerId == id).ToList();

    return products;
});

app.MapGet("/api/order/sellers/{id}", (BangazonDbContext db, int id) =>
{
    Order order = db.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id);
    if (order == null)
    {
        return Results.NotFound("Order not found");
    }

    return Results.Ok(order);
});

app.MapPost("/api/orders", (BangazonDbContext db, Order order) =>
{
    try
    {
        order.TimeSubmitted = DateTime.Now;
        order.IsOpen = true;
        db.Orders.Add(order);
        db.SaveChanges();
        return Results.Created($"/api/products/{order.Id}", order);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Please enter valid data");
    }
});

app.MapPut("/api/orders/{id}", (BangazonDbContext db, int id) =>
{
    Order order = db.Orders.FirstOrDefault(o => o.Id == id);
    if (order == null)
    {
        Results.NotFound("No product was found");
    }

    order.TimeSubmitted = DateTime.Now;
    order.IsOpen = false;
    db.SaveChanges();
    return Results.Ok(order);
});

// Users API Calls

app.MapGet("/api/users/{id}", (BangazonDbContext db, string id) =>
{
    User user = db.Users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound("User not found");
    }

    return Results.Ok(user);
});

app.MapGet("/api/users/orders/{id}", (BangazonDbContext db, int id) =>
{
    Order order = db.Orders.FirstOrDefault(o => o.Id == id);
    User user = db.Users.FirstOrDefault(u => u.Id == order.CustomerId);
    if (user == null)
    {
        return Results.NotFound("User not found");
    }

    return Results.Ok(user);
});

app.MapGet("/api/users/products/{id}", (BangazonDbContext db, int id) =>
{
    Product product = db.Products.FirstOrDefault(p => p.Id == id);
    User user = db.Users.FirstOrDefault(u => u.Id == product.SellerId);
    if (user == null)
    {
        return Results.NotFound("User not found");
    }

    return Results.Ok(user);
});

// POST an OrderProduct
app.MapPost("/api/order_products", (BangazonDbContext db, OrderProduct orderProduct) =>
{
    try
    {
        db.OrderProducts.Add(orderProduct);
        db.SaveChanges();
        return Results.Created($"/api/order_products/{orderProduct.Id}", orderProduct);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Please enter valid data");
    }
});

app.MapDelete("/api/order_products/{id}", (BangazonDbContext db, int id) =>
{
    OrderProduct orderProduct = db.OrderProducts.FirstOrDefault(op => op.Id == id);
    if (orderProduct == null)
    {
        return Results.NotFound("Cannot remove item from cart");
    }
    db.OrderProducts.Remove(orderProduct);
    db.SaveChanges();
    return Results.Ok("Removed item from cart");
});

// Category API Calls

app.MapGet("/api/categories", (BangazonDbContext db) =>
{
    return db.Categories;
});

app.MapGet("/api/categories/{id}", (BangazonDbContext db, int id) =>
{
    Category category = db.Categories.FirstOrDefault(c => c.Id == id);
    if (category == null)
    {
        return Results.NotFound("Category not found");
    }
    return Results.Ok(category);
});

app.MapPost("/api/categories", (BangazonDbContext db, Category category) =>
{
    db.Categories.Add(category);
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/api/categories/{id}", (BangazonDbContext db, int id) =>
{
    Category category = db.Categories.FirstOrDefault(c => c.Id == id);
    if (category == null)
    {
        return Results.NotFound("Category not found");
    }
    db.Categories.Remove(category);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();

