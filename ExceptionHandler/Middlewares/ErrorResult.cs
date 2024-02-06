using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;

namespace ExceptionHandler.Middlewares;
//3
public class ErrorResult
{
    public ErrorResult(string message)
    {
        Message = message;
    }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
