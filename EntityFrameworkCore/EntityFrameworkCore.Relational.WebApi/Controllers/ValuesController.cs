using EntityFrameworkCore.Relational.WebApi.Context;
using EntityFrameworkCore.Relational.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Relational.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ValuesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ValuesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("Add")]
    public IActionResult Add(string name)
    {
        Category category = new()
        {
            Id = Guid.NewGuid(),
            Name = name,
        };

        _context.Add(category);
        _context.SaveChanges();
        return Ok(new {Id= category.Id});
    }
}
