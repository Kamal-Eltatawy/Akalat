using Aklat.Models;
using Aklat.Reposatories.ProductRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aklat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductReposatory productReposatory;
        private readonly ICategoryReposatory categoryReposatory;

        public HomeController(IProductReposatory productReposatory ,ICategoryReposatory categoryReposatory)
        {
            this.productReposatory = productReposatory;
            this.categoryReposatory = categoryReposatory;
        }

        public IActionResult Index()
        {
            
            return View(categoryReposatory.GetAll());
        }
        public IActionResult HomeProductShow(int catID)
        {
            return PartialView("_Products", productReposatory.GetAll().Where(i => i.CategoryId == catID)); //tolist()
        }
        public IActionResult index2()
        {
            return PartialView();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}