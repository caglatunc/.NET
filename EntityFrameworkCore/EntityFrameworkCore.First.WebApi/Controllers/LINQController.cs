using EntityFrameworkCore.First.WebApi.Context;
using EntityFrameworkCore.First.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.First.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LINQController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
       //AppDbContext context = new();
       //List<Todo> todos = context.Todos.ToList();
       // // context.Set<Todo>().ToList();Eğer context klasöründe   public DbSet<Todo>Todos { get; set; } tanımlaması yapılasada yapılmasada bu şekilde de kullanılabilr.

       // List<string> names = new();
       // names.Add("Cagla");
       // names.Remove("Cagla");
       //List<string> newNames =  names.Where(p => p == "Cagla").ToList();
       // string newName = names.FirstOrDefault(p => p == "Cagla");
       // string newName2 = names.SingleOrDefault(p => p == "Cagla");
       // string newName3 = names.Where(p=> p == "Cagla").FirstOrDefault();

       // List<Example> examples = new();
       // var newExample = examples.Select(s=> new NewExample()
       // {
       //     Name = string.Join("",s.FirstName, s.LastName),
       //     Age = s.Age,
       //     City = "Istanbul"

       // }).ToList();


       // int result = examples.Sum(s => s.Age);
       // int count = examples.Count();

       // AppDbContext context = new();
       // var todos =context.Todos.AsQueryable();

       // todos.Where(p => p.IsCompleted);

        return Ok();
    }
}

public class  Example
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class NewExample
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string City { get; set; } = string.Empty;    
}