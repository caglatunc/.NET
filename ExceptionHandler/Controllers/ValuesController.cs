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
        try
        {
            int x = 0;
            int y = 0;
            int z = x / y;
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Hata alındı!" });
        }

        return Ok();
    }
}
