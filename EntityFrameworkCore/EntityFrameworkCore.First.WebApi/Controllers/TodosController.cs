using EntityFrameworkCore.First.WebApi.Context;
using EntityFrameworkCore.First.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.First.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class TodosController : ControllerBase
{
    [HttpPost] //Create
    public IActionResult Add(AddTodoDto request)
    {
        Todo todo = new()
        {
            Work = request.Work,
            DateToBeCompleted =request. DateToBeCompleted,
            CreationDate = DateTime.Now
        };

        AppDbContext context = new();

        //context.Todos.Add(todo);
        context.Add(todo);
        context.SaveChanges();

        return Ok(new { Id = todo.Id });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        AppDbContext context = new();
        IEnumerable<Todo> todos = context.Todos.OrderByDescending(p=>p.CreationDate).ToList();
        return Ok(todos);
    }

    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        AppDbContext context = new();
        Todo? todo =  context.Todos.Find(id);

        if (todo is null)
        {
            return BadRequest(new {Message="Todo kaydı bulunamadı!"});
        }

        return Ok(todo);
    }


}





public sealed class AddTodoDto
{
    public string Work { get; set; } = string.Empty;
    public DateTime DateToBeCompleted { get; set; }
}