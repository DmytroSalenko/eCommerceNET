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
    public class ProductSizesController : ControllerBase
    {
		private IProductSizeService _productSizeService;
		private IMapper _mapper;

		public ProductSizesController(IProductSizeService productSizeService, IMapper mapper)
		{
			_productSizeService = productSizeService;
			_mapper = mapper;
		}

        // GET: api/ProductSizes
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var productSizes = _productSizeService.GetAll();
			var productSizeDtos = _mapper.Map<IList<ProductSizeDto>>(productSizes);
			return Ok(productSizeDtos);
        }

		// GET: api/ProductSizes/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var productSize = _productSizeService.GetById(id);
			var productSizeDto = _mapper.Map<ProductSizeDto>(productSize);
			return Ok(productSizeDto);
        }

        // POST: api/ProductSizes
        [HttpPost]
        public IActionResult Post([FromBody] ProductSizeDto productSizeDto)
        {
			var productSize = _mapper.Map<ProductSize>(productSizeDto);
			var createdProductSize = _productSizeService.Create(productSize);
			var createdProductSizeDto = _mapper.Map<ProductSizeDto>(createdProductSize);
			return StatusCode((int)HttpStatusCode.Created, createdProductSizeDto);
        }

        // PUT: api/ProductSizes/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] ProductSizeDto productSizeDto)
        {
			var productSize = _mapper.Map<ProductSize>(productSizeDto);
			productSize.Id = id;
			var updatedProductSize = _productSizeService.Update(productSize);
			var updatedProductSizeDto = _mapper.Map<ProductSizeDto>(updatedProductSize);
			return StatusCode((int)HttpStatusCode.Accepted, updatedProductSizeDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_productSizeService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
