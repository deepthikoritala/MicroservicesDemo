using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Client.Controllers
{

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
        public IEnumerable<OrderDTO> GetOrders()
        {

            return getOrdersAsync().Result;
        }

        private async Task<List<OrderDTO>> getOrdersAsync() {
            List<OrderDTO> orders = new List<OrderDTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7234");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("/apigateway/Orders/GetOrders");
                if (response.IsSuccessStatusCode)
                {
                    orders = await response.Content.ReadFromJsonAsync<List<OrderDTO>>();
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