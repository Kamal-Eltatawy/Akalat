using Aklat.Models;
using Aklat.Reposatories.OrderRepo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Aklat.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryReposatory CategoryRepo;

        public CategoryController(ICategoryReposatory _category)
        {
            this.CategoryRepo = _category;
        }
        //

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
                CategoryRepo.Save();
                return RedirectToAction("Index");//may be index page
            }

            else

            {
                return View(category); //may be create page
            }

        }


        [HttpGet]
        public IActionResult EditView(int id)
        {
            var category = CategoryRepo.GetById(id);

          
             return View(category);
         

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save( Category category)
        {
            

            if (ModelState.IsValid)
            {
                CategoryRepo.Update(category);
                CategoryRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditView",category);
            }

        }
        public ActionResult Delete(int id)
        {
            CategoryRepo.Delete(id);
            CategoryRepo.Save();
            return RedirectToAction("Index");

        }


    }
}
