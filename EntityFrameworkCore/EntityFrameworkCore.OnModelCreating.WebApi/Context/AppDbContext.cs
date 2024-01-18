using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.OnModelCreating.WebApi.Context;

public sealed class AppDbContext:DbContext
{
     public AppDbContext(DbContextOptions options) : base(options)
    {

    }
}
