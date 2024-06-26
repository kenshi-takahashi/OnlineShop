using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private static List<ReadOrdersDTO> _orders = new List<ReadOrdersDTO>
        {
            new ReadOrdersDTO { Id = 1, Name = "Order 1" },
            new ReadOrdersDTO { Id = 2, Name = "Order 2" }
        };

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadOrdersDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReadOrdersDTO>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetAllOrders()
        {
            try
            {
                return Ok(_orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadOrdersDTO), 201)]
        [ProducesResponseType(500)]
        public IActionResult CreateOrder(CreateOrdersDTO orderDto)
        {
            try
            {
                var newOrder = new ReadOrdersDTO
                {
                    Id = _orders.Max(o => o.Id) + 1,
                    Name = orderDto.Name
                };
                _orders.Add(newOrder);
                return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdateOrder(int id, UpdateOrdersDTO orderDto)
        {
            try
            {
                var order = _orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                order.Name = orderDto.Name;
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var order = _orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                _orders.Remove(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
