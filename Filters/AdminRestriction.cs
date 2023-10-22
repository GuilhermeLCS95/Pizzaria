using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Pizzaria.Helper;
using Pizzaria.Models;

namespace Pizzaria.Filters
{
    public class AdminRestriction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("userLogged");
            if (string.IsNullOrEmpty(userSession))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login"}, {"action", "Index"} });
            }
            else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
                if (user == null) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (user.AdminEnum != Enums.AdminEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
