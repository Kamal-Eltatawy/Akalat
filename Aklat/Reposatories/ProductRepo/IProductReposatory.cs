using Aklat.Models;

namespace Aklat.Reposatories.ProductRepo
{
    public interface IProductReposatory
    {
        public List<Product> GetAll();
        public Product GetById(int ID);
      
        public void Create(Product product);
        public void Update(int id, Product  product);
        public void Delete(int id);
        public int Save();
    }
}
