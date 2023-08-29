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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
    List<Product> products = db.Products.Where(p => p.SellerId == sellerId).ToList();
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
        return Results.Created($"/api/campsites/{product.Id}", product);
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
        Results.NotFound("Order not found");
    }

    return Results.Ok(order);
});

app.Run();

