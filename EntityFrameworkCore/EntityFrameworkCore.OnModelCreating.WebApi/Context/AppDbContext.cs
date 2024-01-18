using EntityFrameworkCore.OnModelCreating.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.OnModelCreating.WebApi.Context;

public sealed class AppDbContext:DbContext
{
     public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p=>p.Name).IsRequired().HasColumnType("varchar(200)");
        modelBuilder.Entity<Product>().HasIndex(p=>p.Name).IsUnique(true);
        modelBuilder.Entity<Product>().Property(p=>p.Price).IsRequired().HasColumnType("money");
        modelBuilder.Entity<Product>().Property(p=>p.CategoryId).IsRequired();
        modelBuilder.Entity<Product>().HasOne(p=>p.Category).WithMany().HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.NoAction);
    }
}
