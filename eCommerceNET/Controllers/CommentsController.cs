using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Entities;
using eCommerceNET.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace eCommerceNET.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
		private ICommentService _commentService;
		private IMapper _mapper;
		private readonly IHostingEnvironment _hostingEnvironment;

		public CommentsController(ICommentService commentService, IMapper mapper, IHostingEnvironment hostingEnvironment)
		{
			_commentService = commentService;
			_mapper = mapper;
			_hostingEnvironment = hostingEnvironment;
		}

        // GET: api/Comments
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
			var comments = _commentService.GetAll();
			var commentDtos = _mapper.Map<IList<CommentDto>>(comments,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return Ok(commentDtos);
        }

        // GET: api/Comments/5
		[AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
			var comment = _commentService.GetById(id);
			var commentDto = _mapper.Map<CommentDto>(comment,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return Ok(commentDto);
        }

        // POST: api/Comments
        [HttpPost]
        public IActionResult Post([FromBody] CommentDto commentDto)
        {
			var comment = _mapper.Map<Comment>(commentDto,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			var createdComment = _commentService.Create(comment);
			var createdCommentDto = _mapper.Map<CommentDto>(createdComment,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return StatusCode((int)HttpStatusCode.Created, createdCommentDto);
        }

		// POST: api/Comments/UploadImage
		[HttpPost("uploadImage")]
		[Consumes("multipart/form-data")]
		public IActionResult UploadImage()
		{
			if (HttpContext.Request.Form.Files.Any())
			{
				var file = HttpContext.Request.Form.Files.First();
				var fileName = new StringValues();

				if (HttpContext.Request.Form.TryGetValue("name", out fileName))
				{
					var uniqueFileName = GetUniqueFileName(fileName);
					var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
					var filePath = Path.Combine(uploads, uniqueFileName);

					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						file.CopyTo(fileStream);
					}

					return StatusCode((int)HttpStatusCode.Created, $"{Request.Scheme}://{Request.Host}/uploads/{uniqueFileName}");
				}
			}

			return NoContent();
		}

		// POST: api/Comments/DeleteImage
		[HttpPost("deleteImage")]
		public IActionResult DeleteImage([FromBody] dynamic fileUrlObject)
		{
			// Hack. Json parser does not parse link to string
			// Declare parameter as dynamic and cast it to string
			var fileUrlString = (string)fileUrlObject.fileUrl;

			var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
			var filePath = Path.Combine(uploads, fileUrlString);

			if (!string.IsNullOrWhiteSpace(fileUrlString) && System.IO.File.Exists(filePath))
			{
				System.IO.File.Delete(filePath);
				return StatusCode((int)HttpStatusCode.NoContent);
			}

			return NotFound();
		}

		// PATCH: api/Comments/5
		[HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] CommentDto commentDto)
        {
			var comment = _mapper.Map<Comment>(commentDto,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			comment.Id = id;
			var updatedComment = _commentService.Update(comment);
			var updatedCommentDto = _mapper.Map<CommentDto>(updatedComment,
				opt => opt.Items["BaseUrl"] = $"{Request.Scheme}://{Request.Host}/");
			return StatusCode((int)HttpStatusCode.Accepted, updatedCommentDto);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			_commentService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
        }

		private string GetUniqueFileName(string fileName)
		{
			fileName = Path.GetFileName(fileName);
			return Path.GetFileNameWithoutExtension(fileName)
					  + "_"
					  + Guid.NewGuid().ToString().Substring(0, 4)
					  + Path.GetExtension(fileName);
		}
	}
}
