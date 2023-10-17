
using Aklat.Reposatories.ProductRepo;
using Microsoft.AspNetCore.Mvc;

namespace Aklat.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductReposatory productReposatory;

        public HomeController(IProductReposatory productReposatory)
        {
            this.productReposatory = productReposatory;
        }

        public IActionResult Index()
        {
            return View();
        }
       


    }
}
