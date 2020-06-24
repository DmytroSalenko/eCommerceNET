using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace eCommerceNET.Controllers
{
	[Authorize]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromForm] string email, [FromForm] string password, [FromForm] bool remember_me)
        {
            var user = _userService.Authenticate(email, password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = remember_me ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

			// return basic user info (without password) and token to store client side
			return Ok(new
			{
				access_token = tokenString,
				token_type = "Bearer"
			});
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Register([FromForm]string name, [FromForm]string email, [FromForm]string password, [FromForm]int? deliveryInfoId)
        {
            try
            {
                // save 
                var user = _userService.Create(name, email, password, deliveryInfoId);
				if (deliveryInfoId.HasValue)
				{
					user.DeliveryInfo = user.DeliveryInfo;
				}
				var userDto = _mapper.Map<UserDto>(user);
                return StatusCode((int)HttpStatusCode.Created, userDto);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

		[HttpGet("logout")]
		public IActionResult Logout()
		{
			var user = User as ClaimsPrincipal;
			var identity = user.Identity as ClaimsIdentity;
			var claim = (from c in user.Claims
						 where c.Type == ClaimTypes.Name
						 select c).Single();

			identity.RemoveClaim(claim);
			return StatusCode((int)HttpStatusCode.NoContent);
		}

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
			if (Request.Query.ContainsKey("_include"))
			{
				user.DeliveryInfo = user.DeliveryInfo;
			}
			var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

		[HttpGet("user")]
		public IActionResult GetCurrentUser()
		{
			var userId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
			var user = _userService.GetById(userId);
			if (Request.Query.ContainsKey("_include"))
			{
				user.DeliveryInfo = user.DeliveryInfo;
			}
			var userDto = _mapper.Map<UserDto>(user);
			return Ok(userDto);
		}

        [HttpPatch("user/{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdatePasswordDto userUpdatePasswordDto)
        {
            try
            {
                // save 
                var user = _userService.UpdatePassword(id, userUpdatePasswordDto.Password, userUpdatePasswordDto.OldPassword);
				var userDto = _mapper.Map<UserDto>(user);
                return StatusCode((int)HttpStatusCode.Accepted, userDto);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }

}
