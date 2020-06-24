using eCommerceNET.Entities;
using eCommerceNET.Helpers;
using eCommerceNET.Services.Abstract;
using System.Collections.Generic;

namespace eCommerceNET.Services.Concrete
{
	public class CartItemService : ICartItemService
	{
		private DataContext _context;

		public CartItemService(DataContext context)
		{
			_context = context;
		}

		public IEnumerable<CartItem> GetAll()
		{
			return _context.CartItems;
		}

		public CartItem GetById(int id)
		{
			return _context.CartItems.Find(id);
		}

		public CartItem Create(CartItem cartItem)
		{
			_context.CartItems.Add(cartItem);
			_context.SaveChanges();

			return cartItem;
		}

		public CartItem Update(CartItem cartItemParam)
		{
			var cartItem = _context.CartItems.Find(cartItemParam.Id);

			cartItem.Quantity = cartItemParam.Quantity;

			_context.CartItems.Update(cartItem);
			_context.SaveChanges();

			return cartItem;
		}

		public void Delete(int id)
		{
			var cartItem = _context.CartItems.Find(id);
			_context.CartItems.Remove(cartItem);
			_context.SaveChanges();
		}
	}
}
