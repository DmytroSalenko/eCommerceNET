using eCommerceNET.Services.Abstract;
using eCommerceNET.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceNET.Services
{
	public static class RegisterService
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductSizeService, ProductSizeService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IDeliveryInfoService, DeliveryInfoService>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<ICartItemService, CartItemService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IOrderItemService, OrderItemService>();
		}
	}
}
