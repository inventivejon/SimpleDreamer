﻿using Show_SimpleDreamer_API_Servers.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Show_SimpleDreamer_API_Servers.Server.Controllers
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