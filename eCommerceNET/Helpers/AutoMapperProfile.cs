using AutoMapper;
using eCommerceNET.Dtos;
using eCommerceNET.Entities;
using System.Linq;

namespace eCommerceNET.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<User, UserDto>();
			CreateMap<UserDto, User>();

			CreateMap<Product, ProductDto>()
				.AfterMap((product, productDto, context) => 
				productDto.ImagePath = GetImagePath(product.ImagePath, context.Items.TryGetValue("BaseUrl", out object baseUrl) ? baseUrl.ToString() ?? string.Empty : string.Empty));
			CreateMap<ProductDto, Product>()
				.AfterMap((productDto, product, context) =>
				product.ImagePath = GetImagePath(productDto.ImagePath, context.Items.TryGetValue("BaseUrl", out object baseUrl) ? baseUrl.ToString() ?? string.Empty : string.Empty));

			CreateMap<ProductSize, ProductSizeDto>();
			CreateMap<ProductSizeDto, ProductSize>();

			CreateMap<Order, OrderDto>();
			CreateMap<OrderDto, Order>();

			CreateMap<OrderItem, OrderItemDto>();
			CreateMap<OrderItemDto, OrderItem>();

			CreateMap<Cart, CartDto>();
			CreateMap<CartDto, Cart>();

			CreateMap<CartItem, CartItemDto>();
			CreateMap<CartItemDto, CartItem>();

			CreateMap<Comment, CommentDto>()
				.AfterMap((comment, commentDto, context) =>
				commentDto.AttachmentUrls = GetImagePath(comment.AttachmentUrls, context.Items.TryGetValue("BaseUrl", out object baseUrl) ? baseUrl.ToString() ?? string.Empty : string.Empty));
			CreateMap<CommentDto, Comment>()
				.AfterMap((commentDto, product, context) =>
				product.AttachmentUrls = GetImagePath(commentDto.AttachmentUrls, context.Items.TryGetValue("BaseUrl", out object baseUrl) ? baseUrl.ToString() ?? string.Empty : string.Empty));
		}

		private string[] GetImagePath(string imagePath, string baseUrl)
		{
			if (string.IsNullOrWhiteSpace(imagePath))
			{
				return null;
			}

			return imagePath.Split(",").Select(newImagePath => baseUrl + newImagePath).ToArray();
		}

		private string GetImagePath(string[] imagePath, string baseUrl)
		{
			if (imagePath != null)
			{
				return null;
			}

			return string.Join(",", imagePath).Replace(baseUrl, "");
		}
	}
}
