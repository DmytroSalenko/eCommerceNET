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
    public class OrderItemsController : ControllerBase
    {
		private IOrderItemService _orderItemService;
		private IMapper _mapper;

		public OrderItemsController(IOrderItemService orderItemService, IMapper mapper)
		{
			_orderItemService = orderItemService;
			_mapper = mapper;
		}

        // GET: api/OrderItems
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var orderItems = _orderItemService.GetAll();
			var orderItemDtos = _mapper.Map<IList<OrderItemDto>>(orderItems);
			return Ok(orderItemDtos);
        }

        // GET: api/OrderItems/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var orderItem = _orderItemService.GetById(id);
			var orderItemDto = _mapper.Map<OrderItemDto>(orderItem);
			return Ok(orderItemDto);
        }

        // POST: api/OrderItems
        [HttpPost]
        public IActionResult Post([FromBody] OrderItemDto orderItemDto)
        {
			var orderItem = _mapper.Map<OrderItem>(orderItemDto);
			var createdOrderItem = _orderItemService.Create(orderItem);
			var createdOrderItemDto = _mapper.Map<OrderItemDto>(createdOrderItem);
			return StatusCode((int)HttpStatusCode.Created, createdOrderItemDto);
        }

        // PATCH: api/OrderItems/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] OrderItemDto orderItemDto)
        {
			var orderItem = _mapper.Map<OrderItem>(orderItemDto);
			orderItem.Id = id;
			var updatedOrderItem = _orderItemService.Update(orderItem);
			var updatedOrderItemDto = _mapper.Map<OrderItemDto>(updatedOrderItem);
			return StatusCode((int)HttpStatusCode.Accepted, updatedOrderItemDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_orderItemService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
