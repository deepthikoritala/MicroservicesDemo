using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Total { get; set; }

        public int NoOfItems { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetOrders", Name = "GetOrders")]
        public IEnumerable<Order> GetOrders()
        {

            return getOrdersAsync().Result;
        }

        private async Task<List<Order>> getOrdersAsync() {
            List<Order> orders = new List<Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7234");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("/apigateway/Orders/GetOrders");
                if (response.IsSuccessStatusCode)
                {
                    orders = await response.Content.ReadFromJsonAsync<List<Order>>();
                    //Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
                    //Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return orders;
        }
    }
}