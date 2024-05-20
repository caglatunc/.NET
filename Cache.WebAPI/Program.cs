using Cache.WebAPI.Context;
using Cache.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicaitonDbContext>(options =>
{
    options.UseInMemoryDatabase("MyDb");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();//MemoryCache kullanmak için

var scoped = builder.Services.BuildServiceProvider();
ApplicaitonDbContext context = scoped.GetRequiredService<ApplicaitonDbContext>();//DbContext'in instance'ýný almak için
IMemoryCache memoryCache = scoped.GetRequiredService<IMemoryCache>();//MemoryCache'in instance'ýný almak için

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("SeedData", () =>
{
    var redisConnection = ConnectionMultiplexer.Connect("localhost:6379");
    var redisCache = redisConnection.GetDatabase();

    redisCache.KeyDelete("products");

    memoryCache.Remove("products");

    List<Product> products = new List<Product>();

    for (int i = 0; i < 1000; i++)
    {
        Product product = new()
        {
            Name = "Product " + i
        };
        products.Add(product);
    }
    context.Products.AddRange(products);
    context.SaveChanges();

    return new { Message = "Product SeedData is success" };
});


app.MapGet("GetAllProductsCacheRedis", async (CancellationToken cancellationToken) =>
{

    var redisConnection = ConnectionMultiplexer.Connect("localhost:6379");
    var redisCache = redisConnection.GetDatabase();

    List<Product>? products = null;
    RedisValue redisValue =  redisCache.StringGet("products");

    if (!redisValue.IsNullOrEmpty)
    {
        products = JsonSerializer.Deserialize<List<Product>>(redisValue);
    }

    if (products is null)
    {
        products = await context.Products.ToListAsync(cancellationToken);

        redisCache.StringSet("products", JsonSerializer.Serialize(products), TimeSpan.FromMinutes(20));
    }

    return products.Count();
});

app.MapGet("GetAllProductsCacheMemory", async (CancellationToken cancellationToken) =>
{
    List<Product>? products;
    memoryCache.TryGetValue("products", out products);

    if(products is null)
    {
        products = await context.Products.ToListAsync(cancellationToken);

        memoryCache.Set("products", products, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
        });
    }

    return products.Count();
});

app.MapGet("GetAllProducts", async(int pageNumber = 1, int pageSize = 10, CancellationToken cancellation = default) =>
{
    List<Product> products = await context.Products.Skip(pageSize* pageNumber).Take(pageSize).ToListAsync(cancellation);
  
    decimal count = await context.Products.CountAsync(cancellation);
    decimal totalPageNumbers = Math.Ceiling(count / pageSize);
    bool isFirstPage = pageNumber == 1 ? true : false;
    bool isLastPage = pageNumber == totalPageNumbers ? true : false;

    var response = new
    {
        Data = products,
        Count = count,
        TotalPageNumbers = totalPageNumbers,
        IsFirstPage = isFirstPage,
        IsLastPage = isLastPage,
        PageNumber = pageNumber,
        PageSize = pageSize
    };

    return response;
});

app.Run();


