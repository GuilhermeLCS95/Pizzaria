﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                if (ModelState.IsValid)
                {
                    _pizzaRepository.Add(pizza);
                    TempData["SucessMessage"] = "Pizza registrada com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(pizza);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao registrar a pizzar" + ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(PizzaModel pizza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pizzaRepository.Update(pizza);
                    TempData["SucessMessage"] = "Pizza atualizada com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(pizza);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao atualizar as informações da pizza " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
