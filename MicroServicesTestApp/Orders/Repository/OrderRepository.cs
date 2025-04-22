using Microsoft.EntityFrameworkCore;
using Orders.DBContexts;
using Orders.Models;
using Orders.Repository;

namespace Products.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersContext _dbContext;

        public OrderRepository(OrdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteOrder(int orderId)
        {
            var product = _dbContext.Orders.Find(orderId);
            _dbContext.Orders.Remove(product);
            Save();
        }

        public Order GetOrderByID(int orderId)
        {
            return _dbContext.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }


        public void InsertOrder(Order order)
        {
            _dbContext.Add(order);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            Save();
        }

    }
}
