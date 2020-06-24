using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Entities;
using eCommerceNET.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace eCommerceNET.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
		private IProductService _productService;
		private IMapper _mapper;

		public ProductsController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

        // GET: api/Products
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
			var productDtos = _mapper.Map<IList<ProductDto>>(products,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return Ok(productDtos);
        }

		// GET: api/Products/5/Sizes
		[AllowAnonymous]
		[HttpGet("{id}/sizes")]
		public IActionResult GetProductSizes(int id)
		{
			var sizes = _productService.GetById(id).Sizes;
			var sizeDtos = _mapper.Map<IList<ProductSizeDto>>(sizes);
			return Ok(sizeDtos);
		}

		// GET: api/Products/5/Comments
		[AllowAnonymous]
		[HttpGet("{id}/comments")]
		public IActionResult GetProductComments(int id)
		{
			var comments = _productService.GetById(id).Comments.OrderByDescending(comment => comment.Date);
			var commentDtos = _mapper.Map<IList<CommentDto>>(comments);
			return Ok(commentDtos);
		}

		// GET: api/Products/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var product = _productService.GetById(id);
			var productDto = _mapper.Map<ProductDto>(product, 
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
            return Ok(productDto);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto productDto)
        {
			var product = _mapper.Map<Product>(productDto,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			var createdProduct = _productService.Create(product);
			var createdProductDto = _mapper.Map<ProductDto>(createdProduct,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return StatusCode((int)HttpStatusCode.Created, createdProductDto);
        }

        // PATCH: api/Products/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] ProductDto productDto)
        {
			var product = _mapper.Map<Product>(productDto,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			product.Id = id;
			var updatedProduct = _productService.Update(product);
			var updatedProductDto = _mapper.Map<ProductDto>(updatedProduct,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return StatusCode((int)HttpStatusCode.Accepted, updatedProductDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_productService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
