namespace Aklat.Reposatories.OrderProductRepo
{
    public interface IOrderProductcs
    {
        public List<OrderProduct> getByProductID(int productID);
        public List<OrderProduct> getByOrderID(int productID);
        public List <OrderProduct> getAllIcludeProductAndOrder();

    }
}
