using Microsoft.AspNetCore.Mvc;
using Pizzaria.Filters;
using Pizzaria.Models;
using Pizzaria.Repository;
using System.Diagnostics;
namespace Pizzaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IUserRepository _userRepository;
       

        public HomeController(ILogger<HomeController> logger, IPizzaRepository pizzaRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<PizzaModel> pizzas = _pizzaRepository.GetAll();
            return View(pizzas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [LoggedUser]
        public IActionResult Update(int id)
        {
            UserModel user = _userRepository.GetId(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(user);
                    TempData["SucessMessage"] = "Usuário registrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao registrar" + ex.Message;
                return RedirectToAction("Index");
            }

        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Update(UserWithoutPassword userWithoutPassword)
        {
            try
            {
                UserModel user = null;
                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userWithoutPassword.Id,
                        AdminEnum = userWithoutPassword.AdminEnum,
                        Name = userWithoutPassword.Name,
                        Email = userWithoutPassword.Email,
                        Phone = userWithoutPassword.Phone,
                    };
                    user = _userRepository.Update(user);
                    TempData["SucessMessage"] = "As informações do usuário foram atualizadas";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Houve uma falha ao atualizar as informações do usuário " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}