using Aklat.Reposatories.OrderProductRepo;
using Aklat.Reposatories.OrderRepo;
using Aklat.Reposatories.ProductRepo;
using Microsoft.AspNetCore.Mvc;

namespace Aklat.Areas.Admin.Controllers
{
    [Area("Admin")]
    //Authourize()
    public class OrderController : Controller
    {
        private readonly IOrderReposatory orderReposatory;

        public OrderController(IOrderReposatory orderReposatory)
        {
            this.orderReposatory = orderReposatory;
        }
        public IActionResult Index()
        {
            return View(orderReposatory.GetAllOrdersWithProductAndUserDetails());
        }
    }
}
