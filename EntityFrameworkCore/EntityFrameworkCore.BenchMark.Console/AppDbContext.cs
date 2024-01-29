using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.BenchMark.Console;
public sealed class AppDbContext :DbContext
{
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=EFCoreTestBenchMarkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Product> Products { get; set; }
}

public sealed class ShoppingCart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product{ get; set; }
    public int Quantity { get; set; }
}

public sealed class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }    
}
