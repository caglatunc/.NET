using Cache.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Cache.WebAPI.Context;

public class ApplicaitonDbContext : DbContext
{
    public ApplicaitonDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; } = null!;
}
