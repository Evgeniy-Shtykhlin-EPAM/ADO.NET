using TaskLibrary.Entities;

namespace TaskLibrary.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public Order GetOrderById(int id);
        public void UpdateOrder(Order order);
        public void AddOrder(Order order);
        public void DeleteOrder(int id);
        public List<Order> GetOrdersFilteredByProductId(int productId);
        public int DeleteOrdersInBulkByProductId(int productId);
    }
}
