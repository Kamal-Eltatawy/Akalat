using Aklat.Models;
using Aklat.Models.Context;

namespace Aklat.Reposatories.ProductRepo
{
    public class ProductReposatory : IProductReposatory
    {
        private readonly AklatContext context;
        public ProductReposatory(AklatContext aklatContext)
        {
            this.context = aklatContext;
        }
        public void Create(Product product)
        {
           context.Products.Add(product);

        }

        public void Delete(int id)
        {
           context.Remove(GetById(id));

        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();

        }

        public Product GetById(int ID)
        {
            return context.Products.FirstOrDefault(c => c.Id == ID);
        }

        public int Save()
        {
           return context.SaveChanges();

        }

        public void Update(int id  ,Product product)
        {
           context.Update(product);

        }
    }
}
