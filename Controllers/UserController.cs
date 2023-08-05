using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;
using Pizzaria.Repository;

namespace Pizzaria.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
           UserModel user = _userRepository.GetId(id);
            return View(user);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            UserModel user = _userRepository.GetId(id);
            return View(user);
        }
        public IActionResult Delete(int id) 
        {
            _userRepository.Delete(id);
            return RedirectToAction("Index");
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
        [HttpPost]
        public IActionResult Update(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Update(user);
                    TempData["SucessMessage"] = "Usuário atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao atualizar as informações do usuário " + ex.Message;
                return RedirectToAction("Index");
            }
            
        }
    }
}
