using Microsoft.AspNetCore.Mvc;
using Pizzaria.Models;
using Pizzaria.Repository;

namespace Pizzaria.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IPurchaseListRepository _purchaseRepository;

        public CartController(ICartRepository cartRepository, IPurchaseListRepository purchaseRepository)
        {
            _cartRepository = cartRepository;
            _purchaseRepository = purchaseRepository;
        }


        public IActionResult Index()
        {
            List<PurchaseListModel> purchases = _purchaseRepository.GetAll();
            return View(purchases);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            PurchaseListModel purchase = _purchaseRepository.GetId(id);
            return View(purchase);
        }

    }
}
