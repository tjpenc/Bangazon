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

// All Api Calls for products
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

app.MapGet("/api/orders", (BangazonDbContext db) =>
{
    return db.Orders
        .Include(o => o.Products);
});
app.Run();

