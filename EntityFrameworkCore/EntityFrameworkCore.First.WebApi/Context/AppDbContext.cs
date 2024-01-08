using EntityFrameworkCore.First.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.First.WebApi.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=CAGLA\\SQLEXPRESS;Initial Catalog=FirstToDoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //optionsBuilder.UseNpgsql("");
        //optionsBuilder.UseSqlite("");
    }
    public DbSet<Todo>Todos { get; set; }
    
}


//public class A
//{
//    private int age { get; set; }
//    public int Id { get; set; }
//    public void Method() { }
//} 

//public interface IInterface
//{
//    string Name { get; set; }
//    void Method2();
//}

//public class  B: A // inherit
//{
    
//}

//public class C : IInterface //implement
//{
   
//    public string Name { get ; set ; }
   

//    public void Method2()
//    {
        
//    }
//}

//public class D:A, IInterface //inherit and implement
//{
    
//    public string Name { get ; set; }

//    public void Method2()
//    {
        
//    }
//}