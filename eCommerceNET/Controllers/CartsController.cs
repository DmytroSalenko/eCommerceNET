using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Entities;
using eCommerceNET.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace eCommerceNET.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
		private ICartService _cartService;
		private IMapper _mapper;

		public CartsController(ICartService cartService, IMapper mapper)
		{
			_cartService = cartService;
			_mapper = mapper;
		}

        // GET: api/Carts
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var carts = _cartService.GetAll();
			var cartDtos = _mapper.Map<IList<CartDto>>(carts);
			return Ok(cartDtos);
        }

        // GET: api/Carts/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var cart = _cartService.GetById(id);
			var cartDto = _mapper.Map<CartDto>(cart);
			return Ok(cartDto);
        }

		// GET: api/Carts/5/Items
		[HttpGet("{id}/items")]
		public IActionResult GetItems(int id)
		{
			var cartItems = _cartService.GetById(id).CartItems;

			if (Request.Query.ContainsKey("_expand"))
			{
				foreach (var item in cartItems)
				{
					item.Product = item.Product;
					item.Size = item.Size;
				}
			}

			var cartItemDtos = _mapper.Map<IList<CartItemDto>>(cartItems);
			return Ok(cartItemDtos);
		}


		// POST: api/Carts
		[HttpPost]
        public IActionResult Post([FromBody] CartDto cartDto)
        {
			var cart = _mapper.Map<Cart>(cartDto);
			var createdCart = _cartService.Create(cart);
			var createdCartDto = _mapper.Map<CartDto>(createdCart);
			return StatusCode((int)HttpStatusCode.Created, createdCartDto);
        }

        // PATCH: api/Carts/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] CartDto cartDto)
        {
			var cart = _mapper.Map<Cart>(cartDto);
			cart.Id = id;
			var updatedCart = _cartService.Update(cart);
			var updatedCartDto = _mapper.Map<CartDto>(updatedCart);
			return StatusCode((int)HttpStatusCode.Accepted, updatedCartDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_cartService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
