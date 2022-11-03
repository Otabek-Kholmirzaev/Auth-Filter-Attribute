using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.Api.Filters;

public class AuthFilterAttribute : ActionFilterAttribute
{
	public override void OnActionExecuting(ActionExecutingContext context)
	{
		if (!context.HttpContext.Request.Headers.ContainsKey("Key"))
		{
			context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
			context.HttpContext.Response.WriteAsync("Unauthorized");
		}
    }
}
