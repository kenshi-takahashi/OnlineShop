using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;
using OnlineShop.BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersResponseDTO>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersResponseDTO>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrdersByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(CreateOrdersDTO orderDto)
        {
            var orderId = await _orderService.CreateOrdersAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrdersDTO orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }

            await _orderService.UpdateOrdersAsync(orderDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrdersAsync(id);
            return NoContent();
        }
    }
}
