using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Filters;

namespace Pizzaria.Filters
{
    public class LayoutFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            bool userLoggedIn = context.HttpContext.User.Identity.IsAuthenticated;

            string layout = userLoggedIn ? "_Layout" : "_LayoutNotLogged";

            if (context.Result is ViewResult viewResult)
            {
                viewResult.ViewData["Layout"] = layout;
            }
        }

        
    }
}
