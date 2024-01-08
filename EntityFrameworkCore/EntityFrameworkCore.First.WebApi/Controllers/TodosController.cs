using EntityFrameworkCore.First.WebApi.Context;
using EntityFrameworkCore.First.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.First.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    [HttpGet]
    public IActionResult Add(string work, DateTime dateToBeCompleted)
    {
        Todo todo = new()
        {
            Work = work,
            DateToBeCompleted = dateToBeCompleted,
            CreationDate = DateTime.Now
        };

        AppDbContext context = new();

        //context.Todos.Add(todo);
        context.Add(todo);
        context.SaveChanges();

        return Ok(new { Id = todo.Id });


    }
}
