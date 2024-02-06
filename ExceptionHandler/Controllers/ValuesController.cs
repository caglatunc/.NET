using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandler.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        //1
        //try
        //{
        //    int x = 0;
        //    int y = 0;
        //    int z = x / y;
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest(new { Message = "Hata alındı!" });
        //}

        //int x = 0;
        //int y = 0;
        //int z = x / y;

        //throw new ArgumentException("Argumen hatası");
        //throw new Exception("Argumen hatası");
        //throw new UnauthorizedAccessException("Argumen hatası");

        return Ok();
    }
}
