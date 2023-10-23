using Akalat.GeneralSettings;
using Aklat.Models;
using Aklat.Reposatories.OrderRepo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Admin.Aklat.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryReposatory CategoryRepo;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly string _imagepath;

        public CategoryController(ICategoryReposatory _category, IWebHostEnvironment webHostEnvironment)
        {
            this.CategoryRepo = _category;
            this.webHostEnvironment = webHostEnvironment;
            _imagepath = $"{webHostEnvironment.WebRootPath}{GeneralVariables.ImgCategoryPath}";
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
        public async Task <IActionResult> Create(Category category,IFormFile File)
        {
            if (File != null)
            {
                var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(category.File.FileName)}";

                var path = Path.Combine(_imagepath, CoverName);
                using var stream = System.IO.File.Create(path);
                await File.CopyToAsync(stream);
                category.ImageUrl = CoverName;


            }


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
