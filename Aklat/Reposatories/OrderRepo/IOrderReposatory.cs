using Aklat.Models;

namespace Aklat.Reposatories.OrderRepo
{
    public interface IOrderReposatory
    {
        public List<Order> GetAll();
        public List<Order> GetAllOrdersWithProductAndUserDetails();
        public Order GetById(int ID);
        public List<Order> GetByUser(string UserId);
        public void Create(Order order);
        public void Update(Order order);
        public void Delete(int id);
        public int Save();




    }
}
