var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get a collection of data
app.MapGet("/product", () => 
{
    return Results.Ok(new List<Product> 
    {
        new Product 
        {
            ProductID = 706,
            Name = "HL Road Frame - Red, 58",
            Color = "Red", 
            ListPrice = 1500.00m
        },
        new Product 
        {
            ProductID = 707,
            Name = "Sport-100 Helmet, Red",
            Color = "Red", 
            ListPrice = 34.99m
        }
    });
})
.WithName("GetProducts")
.WithOpenApi();

app.Run();

public partial class Product 
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal ListPrice { get; set; }
}
