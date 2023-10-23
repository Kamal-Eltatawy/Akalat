using Aklat.Models;
using Aklat.Models.Context;

namespace Aklat.Reposatories.CategoryRepo
{
    public class CategoryReposatory : ICategoryReposatory
    {
        private readonly AklatContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoryReposatory(AklatContext aklatContext, IWebHostEnvironment webHostEnvironment)
        {
            this.context = aklatContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.ID == id);
        }

        public void Create(Category category) // make sure if category is a view model or not
        {
         

            context.Categories.Add(category);

        }

        public void Delete(int id)
        {
           context.Remove(GetById(id));
        }



        public void Update(Category category)
        {
           context.Update(category);
        }



        public int Save()
        {
           return context.SaveChanges();
        }

     
    }
}
