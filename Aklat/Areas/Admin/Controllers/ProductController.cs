using Aklat.Reposatories.ProductRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aklat.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IProductReposatory productRepoo;

        public ICategoryReposatory CategoryReposatory;

        public ProductController(IProductReposatory productRepoo, ICategoryReposatory categoryReposatory)
        {
            this.productRepoo = productRepoo;
            this.CategoryReposatory = categoryReposatory;
        }
        
        public IActionResult Index()
        {
            return View(productRepoo.GetAllAndCat());

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["cat"] = CategoryReposatory.GetAll();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Create(Product product, IFormFile File)
        {
            if (File != null)
            { 
                string imageName = Guid.NewGuid().ToString() + ".jpg";
            string filePathImage = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/ProductPhoto", imageName);
            using (var stream = System.IO.File.Create(filePathImage))
            {
                await File.CopyToAsync(stream);
            }
            product.Photo = imageName;
        }

            ViewData["cat"] = CategoryReposatory.GetAll();

            if (ModelState.IsValid)
            {
                productRepoo.Create(product);
                productRepoo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["cat"] = CategoryReposatory.GetAll();


            return View(productRepoo.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            ViewData["cat"] = CategoryReposatory.GetAll();

            if (ModelState.IsValid)
            {
                productRepoo.Update(id, product);
                productRepoo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

        }
        public ActionResult Delete(int id)
        {
            productRepoo.Delete(id);
            productRepoo.Save();
            return RedirectToAction("Index");

        }


    }

}
