using EntityFrameworkCore.Relational.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Relational.WebApi.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; } 
    public DbSet<AdditionalProduct> AdditionalProducts { get; set; }
}
