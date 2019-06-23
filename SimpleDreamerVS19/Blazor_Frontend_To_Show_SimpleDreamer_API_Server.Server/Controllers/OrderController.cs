using Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Server.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly StaticRepositoryCollections staticRepositoryCollections;

        public OrderController(StaticRepositoryCollections staticRepositoryCollections)
        {
            this.staticRepositoryCollections = staticRepositoryCollections;
        }

        [HttpGet("[action]")]
        public IActionResult Orders(int customerId, int pageNumber, int pageSize, SortingParams sortingParams)
        {
            var customerOrders = staticRepositoryCollections.Orders.Where(o => o.CustomerId == customerId);
            var pageableCustomerOrders = customerOrders
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                Items = pageableCustomerOrders,
                TotalCount = customerOrders.Count()
            });
        }

        [HttpPut("[action]")]
        public ActionResult<Order> UpdateOrder([FromBody] Order order)
        {
            return order;
        }
    }
}