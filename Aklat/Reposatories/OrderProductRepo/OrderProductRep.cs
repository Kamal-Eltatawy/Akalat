using Aklat.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Aklat.Reposatories.OrderProductRepo
{
    public class OrderProductRep : IOrderProductcs
    {
        private readonly AklatContext aklatContext;
        
        public OrderProductRep(AklatContext aklatContext)
        {
            this.aklatContext = aklatContext;
        }

        public void Create(OrderProduct orderProduct)
        {
            aklatContext.Add(orderProduct);
        }

        public List<OrderProduct> getAllIcludeProductAndOrder()
        {
          return  aklatContext.OrderProducts.Include(i=>i.Product).Include(i=>i.Order).ThenInclude(i=>i.User).ToList();
        }

        public List<OrderProduct> getByOrderID(int productID)
        {
            throw new NotImplementedException();
        }

        public List<OrderProduct> getByProductID(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
