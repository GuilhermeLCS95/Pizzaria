using Microsoft.AspNetCore.Mvc;
using Pizzaria.Filters;

namespace Pizzaria.Controllers
{
    [LoggedUser]
    [AdminRestriction]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
