using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.Presentation.Filters;
internal class TestFilterAttribute : Attribute, IActionFilter, IAuthorizationFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
       //loglama
       //caching
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //authorization
    }
}
