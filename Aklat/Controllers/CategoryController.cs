using Aklat.Models;
using Aklat.Reposatories.OrderRepo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aklat.Controllers
{ 
    public class CategoryController : Controller
    {
        private readonly ICategoryReposatory CategoryRepo;

        public CategoryController(ICategoryReposatory _category)
        {
            this.CategoryRepo = _category;
        }


        public IActionResult Index()
        {
            return View(CategoryRepo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                CategoryRepo.Create(category);
                return RedirectToAction("");//may be index page
            }
            
            else 

            { 
                return View("category"); //may be create page
            }
            
        }


    }
}
