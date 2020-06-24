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
    public class CartItemsController : ControllerBase
    {
		private ICartItemService _cartItemService;
		private IMapper _mapper;

		public CartItemsController(ICartItemService cartItemService, IMapper mapper)
		{
			_cartItemService = cartItemService;
			_mapper = mapper;
		}

        // GET: api/CartItems
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var cartItems = _cartItemService.GetAll();
			var cartItemDtos = _mapper.Map<IList<CartItemDto>>(cartItems);
			return Ok(cartItemDtos);
        }

        // GET: api/CartItems/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var cartItem = _cartItemService.GetById(id);
			var cartItemDto = _mapper.Map<CartItemDto>(cartItem);
			return Ok(cartItemDto);
        }

        // POST: api/CartItems
        [HttpPost]
        public IActionResult Post([FromBody] CartItemDto cartItemDto)
        {
			var cartItem = _mapper.Map<CartItem>(cartItemDto);
			var createdCartItem = _cartItemService.Create(cartItem);
			var createdCartItemDto = _mapper.Map<CartItemDto>(createdCartItem);
			return StatusCode((int)HttpStatusCode.Created, createdCartItemDto);
        }

        // PATCH: api/CartItems/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] CartItemDto cartItemDto)
        {
			var cartItem = _mapper.Map<CartItem>(cartItemDto);
			cartItem.Id = id;
			var updatedCartItem = _cartItemService.Update(cartItem);
			var updatedCartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);
			return StatusCode((int)HttpStatusCode.Accepted, updatedCartItemDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_cartItemService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
