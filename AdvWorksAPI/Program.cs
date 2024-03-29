using AdvWorksAPI;

var builder = WebApplication.CreateBuilder(args);


// Add Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
        builder.Expire(TimeSpan.FromSeconds(10)));
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add "Router" classes as a service
// Add your "Router" classes as services
builder.Services.AddScoped<RouterBase, ProductRouter>();
builder.Services.AddScoped<RouterBase, CustomerRouter>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//*************************************
// Add Routes from all "Router Classes"
//*************************************
using (var scope = app.Services.CreateScope())
{
    // Build collection of all RouterBase classes
    var services = scope.ServiceProvider.GetServices<RouterBase>();

    // Loop through each RouterBase class
    foreach (var item in services)
    {
        // Invoke the AddRoutes() method to add the routes
        item.AddRoutes(app);
    }

    // Make sure this is called within the application scope
    app.Run();
}

