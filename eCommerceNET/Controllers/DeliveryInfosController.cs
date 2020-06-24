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
    public class DeliveryInfosController : ControllerBase
    {
		private IDeliveryInfoService _deliveryInfoService;
		private IMapper _mapper;

		public DeliveryInfosController(IDeliveryInfoService deliveryInfoService, IMapper mapper)
		{
			_deliveryInfoService = deliveryInfoService;
			_mapper = mapper;
		}

        // GET: api/DeliveryInfos
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var deliveryInfos = _deliveryInfoService.GetAll();
			var deliveryInfoDtos = _mapper.Map<IList<DeliveryInfoDto>>(deliveryInfos);
			return Ok(deliveryInfoDtos);
        }

        // GET: api/DeliveryInfos/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var deliveryInfo = _deliveryInfoService.GetById(id);
			var deliveryInfoDto = _mapper.Map<DeliveryInfoDto>(deliveryInfo);
			return Ok(deliveryInfoDto);
        }

        // POST: api/DeliveryInfos
		[AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] DeliveryInfoDto deliveryInfoDto)
        {
			var deliveryInfo = _mapper.Map<DeliveryInfo>(deliveryInfoDto);
			var createdDeliveryInfo = _deliveryInfoService.Create(deliveryInfo);
			var createdDeliveryInfoDto = _mapper.Map<DeliveryInfoDto>(createdDeliveryInfo);
			return StatusCode((int)HttpStatusCode.Created, createdDeliveryInfoDto);
        }

        // PATCH: api/DeliveryInfos/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] DeliveryInfoDto deliveryInfoDto)
        {
			var deliveryInfo = _mapper.Map<DeliveryInfo>(deliveryInfoDto);
			deliveryInfo.Id = id;
			var updatedDeliveryInfo = _deliveryInfoService.Update(deliveryInfo);
			var updatedDeliveryInfoDto = _mapper.Map<DeliveryInfoDto>(updatedDeliveryInfo);
			return StatusCode((int)HttpStatusCode.Accepted, updatedDeliveryInfoDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_deliveryInfoService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
