using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzaria.Models;

namespace Pizzaria.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("userLogged");

            if (string.IsNullOrEmpty(userSession))
            {
                return View("_LayoutUserSessionNull");
            }         


            UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);
           
            return View(user);
        }
    }
}
