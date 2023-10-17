using Aklat.Models;

namespace Aklat.Reposatories.CategoryRepo
{
    public interface ICategoryReposatory
    {

        public List<Category> GetAll();
        public Category GetById(int id);

        public void Create(Category category);// make sure if there is Viewmodel
        public void Update(Category category);// make sure if there is Viewmodel
        public void Delete(int id);
        public int Save();

    }
}
