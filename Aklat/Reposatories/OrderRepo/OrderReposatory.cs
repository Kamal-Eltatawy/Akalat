using Aklat.Models;
using Aklat.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Aklat.Reposatories.OrderRepo
{
    public class OrderReposatory : IOrderReposatory
    {
        private readonly AklatContext context;
        public OrderReposatory(AklatContext aklatContext)
        {
            this.context = aklatContext;
        }
        public void Create(Order order)
        {
            context.Orders.Add(order);
        }
        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }
        public Order GetById(int ID)
        {
            return context.Orders.FirstOrDefault(o => o.ID == ID);
        }

        public List<Order> GetByUser(string UserId)
        {
            return context.Orders.Where(o => o.UserID == UserId).ToList();
        }
        public void Update(Order order)
        {
            context.Update(order);
        }
        public void Delete(int id)
        {
            context.Remove(GetById(id));

        }
        public int Save()
        {
            return context.SaveChanges();
        }

        public List<Order> GetAllOrdersWithProductAndUserDetails()
        {
            return context.Orders?.Where(o => !o.IsDeleted) ?.Include(o => o.User)?.Include(o => o.OrderProducts)?.ThenInclude(op => op.Product)?.ToList();
        }
    }
}
