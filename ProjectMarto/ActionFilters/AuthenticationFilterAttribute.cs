using ProjectMarto.Models;
using ProjectMarto.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ProjectMarto.ActionFilters
{
    public class AuthenticationFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetObject<User>("loggedUser") == null)
            {
                context.Result = new RedirectResult("/Home/Login");
            } 
        }
    }
}
