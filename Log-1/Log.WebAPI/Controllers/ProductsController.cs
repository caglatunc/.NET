using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Log.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController: ControllerBase
{
    [HttpGet]
    public IActionResult Create(string name)
    {
        //var log = new LoggerConfiguration()
        //    .WriteTo.File("./log.txt", rollingInterval: RollingInterval.Minute)
        //    .CreateLogger();

        Serilog.Log.Information("Create metodu çalıştı. Name: {name}");
        //Kayıt işlemleri

        Serilog.Log.Information("Create metodu başarılı bir şekilde çalıştı.");

        return NoContent();
    }

    [HttpGet]
    public IActionResult Update(int id, string name)
    {
        //Update işlemleri

        return NoContent();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        //Delete işlemleri

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        //GetAll İşlemleri

        return NoContent();
    }
}
