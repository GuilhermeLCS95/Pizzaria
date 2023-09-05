using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;
using Pizzaria.Repository;

namespace Pizzaria.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  UserModel user =  _userRepository.SearchForLogin(loginModel.Email);
                    if (user != null)
                    {
                        if (user.PasswordSearch(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["ErrorMessage"] = "E-mail e/ou senha inválido(s). Por favor, tente novamente.";
                    }
                    TempData["ErrorMessage"] = "E-mail e/ou senha inválido(s). Por favor, tente novamente.";
                }
                return View("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao acessar a conta. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
