using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IBus _busService;

        public OrderController(IBus busService)
        {
            _busService = busService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            Uri uri = new Uri("rabbitmq://localhost/orderQueue");
            var endpoint = await _busService.GetSendEndpoint(uri);
            await endpoint.Send(order);
            return Ok();
        }
    }
}
