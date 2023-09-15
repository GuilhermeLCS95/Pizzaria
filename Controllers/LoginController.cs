using Microsoft.AspNetCore.Mvc;
using Pizzaria.Helper;
using Pizzaria.Models;
using Pizzaria.Repository;

namespace Pizzaria.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _userSession;
        public LoginController(IUserRepository userRepository, IUserSession userSession)
        {
            _userRepository = userRepository;
            _userSession = userSession;
        }
        public IActionResult Index()
        {
            if (_userSession.SearchUserSession() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult LogOut()
        {
            _userSession.DeleteUserSession();
            return RedirectToAction("Index", "Login");
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
                            _userSession.CreateUserSession(user);
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
