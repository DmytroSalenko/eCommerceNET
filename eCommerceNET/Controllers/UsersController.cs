using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceNET.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private IUserService _userService;
		private IMapper _mapper;

		public UsersController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet("{id}/carts")]
		public IActionResult GetCarts(int id)
		{
			var userCart = _userService.GetById(id).Cart;

			if (userCart == null)
			{
				return NoContent();
			}

			var userCartDto = _mapper.Map<CartDto>(userCart);
			return Ok(userCartDto);
		}
	}
}
