using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using Orders.Repository;
using System.Transactions;

namespace Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderRepository _ordersRepository;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepository ordersRepository)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
        }

        [HttpGet("GetOrders", Name = "GetOrders")]
        public IActionResult GetOrders()
        {
            var orders = _ordersRepository.GetOrders();
            return new OkObjectResult(orders);
        }

        [HttpGet("GetOrderByID/{id}", Name = "GetOrderByID")]
        public IActionResult Get(int id)
        {
            var order = _ordersRepository.GetOrderByID(id);
            return new OkObjectResult(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            using (var scope = new TransactionScope())
            {
                _ordersRepository.InsertOrder(order);
                scope.Complete();
                return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (order != null)
            {
                using (var scope = new TransactionScope())
                {
                    _ordersRepository.UpdateOrder(order);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ordersRepository.DeleteOrder(id);
            return new OkResult();
        }
    }
}