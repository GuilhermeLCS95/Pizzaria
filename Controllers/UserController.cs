using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzaria.Filters;
using Pizzaria.Models;
using Pizzaria.Repository;
using System.Linq.Expressions;
using System.Web.Http;

namespace Pizzaria.Controllers
{
    [AdminRestriction]
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
            try
            {
                bool deleted = _userRepository.Delete(id);
                if (deleted)
                {
                    TempData["SucessMessage"] = "Usuário excluído com sucesso";
                }
                else
                {
                    TempData["ErrorMessage"] = "Falha ao excluir usuário.";
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to delete this user. " + ex.Message;
                return RedirectToAction("Index");
            }          
            
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
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
    }
}
