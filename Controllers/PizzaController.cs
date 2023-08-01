using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;
using Pizzaria.Repository;

namespace Pizzaria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
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
        public IActionResult Update(int id)
        {
           PizzaModel pizza = _pizzaRepository.GetId(id);
            return View(pizza);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            PizzaModel pizza = _pizzaRepository.GetId(id);
            return View(pizza);
        }
        public IActionResult Delete(int id) 
        {
            _pizzaRepository.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(PizzaModel pizza)
        {
            _pizzaRepository.Add(pizza);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(PizzaModel pizza)
        {
            _pizzaRepository.Update(pizza);
            return RedirectToAction("Index");
        }
    }
}
