namespace AdvWorksAPI;

public class ProductRouter : RouterBase
{
    public ProductRouter()
    {
        UrlFragment = "product";
    }

    /// <summary>
    /// Get a collection of Product objects
    /// </summary>
    /// <returns>A list of Product objects</returns>
    protected virtual List<Product> GetAll()
    {
        return new List<Product>
    {
        new Product
        {
            ProductID = 706,
            Name = "HL Road Frame - Red, 58",
            Color = "Red",
            ListPrice = 1500.0000m
        },
        new Product
        {
            ProductID = 707,
            Name = "Sport-100 Helmet, Red",
            Color = "Red",
            ListPrice = 34.9900m
        },
        new Product
        {
            ProductID = 708,
            Name = "Sport-100 Helmet, Black",
            Color = "Black",
            ListPrice = 34.9900m
        },
        new Product
        {
            ProductID = 709,
            Name = "Mountain Bike Socks, M",
            Color = "White",
            ListPrice = 9.5000m
        },
        new Product
        {
            ProductID = 710,
            Name = "Mountain Bike Socks, L",
            Color = "White",
            ListPrice = 9.5000m
        }
    };
    }

    /// <summary>
    /// GET a collection of data
    /// </summary>
    /// <returns>An IResult object</returns>
    protected virtual IResult Get()
    {
        return Results.Ok(GetAll());
    }

    /// <summary>
    /// GET a single row of data
    /// </summary>
    /// <returns>An IResult object</returns>
    protected virtual IResult Get(int id)
    {
        // Locate a single row of data
        Product? current = GetAll().Find(p => p.ProductID == id);
        if (current != null)
        {
            return Results.Ok(current);
        }
        else
        {
            return Results.NotFound();
        }
    }


    /// <summary>
    /// Add routes
    /// </summary>
    /// <param name="app">A WebApplication object</param>
    public override void AddRoutes(WebApplication app)
    {
        app.MapGet($"/{UrlFragment}", () => Get());
        app.MapGet($"/{UrlFragment}/{{id:int}}", (int id) => Get(id));
    }


}
