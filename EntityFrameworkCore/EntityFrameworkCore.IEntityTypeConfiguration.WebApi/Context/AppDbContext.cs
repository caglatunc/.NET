

using EntityFrameworkCore.IEntityTypeConfiguration.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityFrameworkCore.IEntityTypeConfiguration.WebApi.Context;

public sealed class AppDbContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=IEntityTypeConfigurationDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .LogTo(Console.WriteLine, LogLevel.Information);//Konsolda Sql kodlarını görmek için
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
        //modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
