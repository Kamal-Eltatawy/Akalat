using Aklat.Models;
using Aklat.Reposatories.OrderRepo;
using Microsoft.AspNetCore.Mvc;

namespace Aklat.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReposatory orderReposatory;

        public OrderController(IOrderReposatory orderReposatory)
        {
            this.orderReposatory = orderReposatory;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if(ModelState.IsValid)
            {
            orderReposatory.Create(order);
                orderReposatory.Save();
              return  RedirectToAction("Index");
            }
            else { return View(order); }

        }
        public IActionResult Edit (int ID)
        {
            return View(orderReposatory.GetById(ID));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Order order)
        {
            if(ModelState.IsValid)
            {
                orderReposatory.Update(order);
                return RedirectToAction("Index");
            }
            else { return View(order); }
        }
    }
}
