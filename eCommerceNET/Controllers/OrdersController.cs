using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Entities;
using eCommerceNET.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace eCommerceNET.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
		private IOrderService _orderService;
		private IMapper _mapper;

		public OrdersController(IOrderService orderService, IMapper mapper)
		{
			_orderService = orderService;
			_mapper = mapper;
		}

        // GET: api/Orders
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var orders = _orderService.GetAll();
			var orderDtos = _mapper.Map<IList<OrderDto>>(orders);
			return Ok(orderDtos);
        }

        // GET: api/Orders/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var order = _orderService.GetById(id);
			var orderDto = _mapper.Map<OrderDto>(order);
			return Ok(orderDto);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto orderDto)
        {
			var order = _mapper.Map<Order>(orderDto);
			var createdOrder = _orderService.Create(order);
			var createdOrderDto = _mapper.Map<OrderDto>(createdOrder);
			return StatusCode((int)HttpStatusCode.Created, createdOrderDto);
        }

        // PATCH: api/Orders/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] OrderDto orderDto)
        {
			var order = _mapper.Map<Order>(orderDto);
			order.Id = id;
			var updatedOrder = _orderService.Update(order);
			var updatedOrderDto = _mapper.Map<OrderDto>(updatedOrder);
			return StatusCode((int)HttpStatusCode.Accepted, updatedOrderDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_orderService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
