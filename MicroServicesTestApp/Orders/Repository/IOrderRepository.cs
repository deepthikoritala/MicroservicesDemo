using Orders.Models;

namespace Orders.Repository
{
    public interface IOrderRepository
    {
        void DeleteOrder(int orderId);
        Order GetOrderByID(int orderId);
        IEnumerable<Order> GetOrders();
        void InsertOrder(Order order);
        void Save();
        void UpdateOrder(Order order);
    }
}
